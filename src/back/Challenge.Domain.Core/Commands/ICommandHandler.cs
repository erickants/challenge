using src.back.Challenge.Domain.Core.Handlers;

namespace src.back.Challenge.Domain.Core.Commands
{
    public interface ICommandHandler<TCommand, TResult>
        : IAsyncHandler<TCommand, TResult>
        where TCommand : ICommand<TResult>
        where TResult : ICommandResult
    { }
}