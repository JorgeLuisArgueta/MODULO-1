using Microsoft.AspNetCore.Mvc;
using FastDeliveriApi.Data;
using FastDeliveriApi.Entity;
using FastDeliveriApi.Repositories.Interfaces;

namespace FastDeliveriApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersControllers : ControllerBase
{
    private readonly ICustomerRepository _customerRepository;

    public CustomersControllers(ICustomerRepository customerRepository, IUnitOfWork unitOfWork)
    {
        _customerRepository = customerRepository;
        _unitOfWork = unitOfWork;
    }

    private readonly IUnitOfWork _unitOfWork;
    
    [HttpGet]
    public ActionResult<IEnumerable<Customer>> Get()
    {
        var customers = _customerRepository.GetAll();
        return Ok(customers);
    }
}