using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Commands;

namespace src.back.Challenge.Domain.Core.Wireup
{
    public interface IRequestDispatcher
    {
        Task<TResult> Dispatch<TCommand, TResult>(TCommand command)
            where TCommand : ICommand<TResult>
            where TResult : ICommandResult;

        Task<TResult> Dispatch<TResult>(object command)
            where TResult : ICommandResult;

    }
}