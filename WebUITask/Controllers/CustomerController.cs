using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebUITask.Models;
using WebUITask.Services.Abstracts;
using WebUITask.Services.Concrets;

namespace WebUITask.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerInterface _customerRepository;

        public CustomerController(ICustomerInterface customerRepository)
        {
            _customerRepository = customerRepository;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllCustomers()
        {
            var customers = await _customerRepository.GetAll();

            return Ok(customers ?? new List<Customer>());
        }

        [HttpPost("Post")]
        public async Task<IActionResult> Post([FromBody] Customer customer)
        {

            if (customer is { })
            {
                await _customerRepository.Add(customer);

                return Ok(new
                {
                    message = "Customer added"
                });
            }
            return BadRequest();

        }
    }
}
