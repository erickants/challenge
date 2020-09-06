using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.back.Challenge.Api.Models;
using src.back.Challenge.Domain.Core.Wireup;
using src.back.Challenge.Domain.InvestmentRules.CommandResults;

namespace src.back.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/investments")]
    public class InvestmentController : ControllerBase
    {
        private readonly IRequestDispatcher _requestDispatcher;

        public InvestmentController(IRequestDispatcher requestDispatcher)
        {
            _requestDispatcher = requestDispatcher;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateInvestmentRulesModel createInvestmentRules)
        {
            var result = await _requestDispatcher.Dispatch<CreateInvestmentRulesCommandResult>
                (createInvestmentRules.MapToCommand());

            return Created(HttpContext.Request.Path.ToString(), result);
        }
    }
}