using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.back.Challenge.Api.Models;
using src.back.Challenge.Domain.Core.Wireup;
using src.back.Challenge.Domain.Customers.CommandResults;
using src.back.Challenge.Domain.Customers.Commands;

namespace src.back.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/customers")]
    public class CustomerController : ControllerBase
    {
        private readonly IRequestDispatcher _requestDispatcher;

        public CustomerController(IRequestDispatcher requestDispatcher)
        {
            _requestDispatcher = requestDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCustomerModel createCustomer)
        {
            var result = await _requestDispatcher.Dispatch<CreateCustomerCommandResult>(createCustomer.MapToCommand());

            return Created(HttpContext.Request.Path.ToString(), result);
        }

        [HttpGet("{id:long}")]
        public async Task<IActionResult> Find(long id)
        {
            var command = new FindCustomerCommand { Id = id };
            var result = await _requestDispatcher.Dispatch<FindCustomerCommandResult>(command);

            return Ok(result);
        }
    }
}