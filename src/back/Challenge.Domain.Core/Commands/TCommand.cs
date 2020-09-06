namespace src.back.Challenge.Domain.Core.Commands
{
    public interface ICommand<out TResult> : ICommandResult
    {   
    }
    public interface ICommand : ICommand<ICommandResult>
    { }
}