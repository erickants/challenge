using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using src.back.Challenge.Api.Models;
using src.back.Challenge.Domain.BankAccounts.CommandResults;
using src.back.Challenge.Domain.BankAccounts.Commands;
using src.back.Challenge.Domain.Core.Wireup;

namespace src.back.Challenge.Api.Controllers
{
    [ApiController]
    [Route("api/bank-accounts")]
    public class BankAccountController : ControllerBase
    {
        private readonly IRequestDispatcher _requestDispatcher;
        
        public BankAccountController(IRequestDispatcher requestDispatcher)
        {
            _requestDispatcher = requestDispatcher;
        }
        
        [HttpPost]
        public async Task<IActionResult> Create(CreateBankAccountModel createBankAccount)
        {
            var command = createBankAccount.MapToCommand();
            var result = await _requestDispatcher.Dispatch<CreateBankAccountCommandResult>(command);

            return Created(HttpContext.Request.Path.ToString(), result);
        }

        [HttpPut("deposit")]
        public async Task<IActionResult> Deposit(DepositBankAccountModel depositBankAccount)
        {
            var command = depositBankAccount.MapToCommand();
            var result = await _requestDispatcher.Dispatch<DepositBankAccountCommandResult>(command);

            return Ok(result);
        }

        [HttpPut("{id:long}/transfer")]
        public async Task<IActionResult> Transfer(long id, TransferBankAccountModel transferBankAccount)
        {
            var command = transferBankAccount.MapToCommand(id);
            var result = await _requestDispatcher.Dispatch<TransferBankAccountCommandResult>(command);

            return Ok(result);
        }

        [HttpGet("{id:long}/statements")]
        public async Task<IActionResult> List(long id)
        {
            var command = new GetBankAccountStatementsCommand { BankAccountId = id };
            var result = await _requestDispatcher.Dispatch<GetBankAccountStatementsCommandResult>(command);

            return Ok(result);
        }
    }
}