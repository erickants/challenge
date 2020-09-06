using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Commands;
using src.back.Challenge.Domain.Core.Wireup;
using src.back.Challenge.Infra.CrossCutting.Handlers;

namespace src.back.Challenge.Infra.CrossCutting.Wireup
{
    public class RequestDispatcher : IRequestDispatcher
    {
        private readonly IHandlerExecutor _handlerExecutor;

        public RequestDispatcher(IHandlerExecutor handlerExecutor)
        {
            _handlerExecutor = handlerExecutor;
        }

        public Task<TResult> Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            where TResult : ICommandResult
        {
            return _handlerExecutor.ExecuteSingle<Task<TResult>>(command);
        }

        public Task<TResult> Dispatch<TResult>(object command)
            where TResult : ICommandResult
        {
            return _handlerExecutor.ExecuteSingle<Task<TResult>>(command);
        }
    }
}