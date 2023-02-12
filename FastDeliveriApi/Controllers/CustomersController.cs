using Microsoft.AspNetCore.Mvc;
using FastDeliveriApi.Data;
using FastDeliveriApi.Entity;

namespace FastDeliveriApi.Controllers;

[ApiController]
[Route("api/customers")]
public class CustomersControllers : ControllerBase
{
    private readonly FastDeliveriDbContext _context;
    public CustomersControllers(FastDeliveriDbContext context)
    {
        _context = context;
    }
    [HttpGet]
    public ActionResult<IEnumerable<Custumer>> Get()
    {
        var customers = _context.Customers.ToString();
        return Ok(customers);
    }
}