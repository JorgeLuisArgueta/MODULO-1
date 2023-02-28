using Microsoft.AspNetCore.Mvc;
using Mapster;

//using FastDeliveriApi.Data;
using FastDeliveriApi.Entity;
using FastDeliveriApi.Repositories.Interfaces;
using FastDeliveriApi.Models;
using FastDeliveriApi.Exceptions;

namespace FastDeliveriApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersControllers : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;
    private readonly IUnitOfWork _unitOfWork;

    public CustomersControllers(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }
    
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Customer>>> Get()
    {
        var customers = await _customerRepository.GetAll();
        return Ok(customers);
    }

    [HttpPost]
    public async Task<IActionResult> CreateCustomers([FromBody] CreateCustomerRequest request, CancellationToken cancellationToken)
    {

        var customer = request.Adapt<Customer>();

        _customerRepository.Add(customer);

        await _unitOfWork.SaveChangesAsync(cancellationToken);

        var response = customer.Adapt<CustomerResponse>();

        return CreatedAtAction(
            nameof(GetCustomerById), 
            new { id = customer.Id }, 
            customer);

    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCustomers( int id, [FromBody] UpdateCustomerRequest request, CancellationToken cancellationToken)
    {
        if(request.Id != id)
        {
            throw new BadRequestException("Body Id is not equal than Url Id");
        }

        var customer = await _customerRepository.GetCustomerById(id, cancellationToken);
        if(customer is null)
        {
           throw new NotFoundException("Customer", id);
        }

        customer.ChangeName(request.Name);
        customer.ChangePhoneNumber(request.PhoneNumber);
        customer.ChangeAddress(request.Address);
        customer.ChangeEmail(request.Email);
        customer.ChangeStatus(request.Status);
        customer.incrementCreditLimit(request.CreditLimit);

        _customerRepository.Update(customer);

        await _unitOfWork.SaveChangesAsync();

        return NoContent();
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCustomerById(int id, CancellationToken cancellationToken)
    {
        var customer = await _customerRepository.GetCustomerById(id, cancellationToken);
        if(customer is null)
        {
           throw new NotFoundException("Customer", id);
        }

        var response = customer.Adapt<CustomerResponse>();

        return Ok(response);
    }
}