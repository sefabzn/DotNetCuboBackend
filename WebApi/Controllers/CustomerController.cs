using Entities.Concrete;
using Microsoft.AspNetCore.Mvc;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly ICustomerService _customerService;

    public CustomerController(ICustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet("GetAll")]
    public async Task<IActionResult> GetAll()
    {
        var result = await _customerService.GetAllAsync();
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    [HttpPost("Add")]
    public async Task<IActionResult> Add(Musteri customer)
    {
        var result = await _customerService.addAsync(customer);
        if (result.Success)
        {
            return Ok(result);
        }
        return BadRequest(result);
    }

    // Other CRUD actions...
}
