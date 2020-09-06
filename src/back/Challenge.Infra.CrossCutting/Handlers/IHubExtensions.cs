using System.Threading.Tasks;
using src.back.Challenge.Domain.Core.Handlers;

namespace src.back.Challenge.Infra.CrossCutting.Handlers
{
    public static class IHubExtensions
    {
        public static void AddCommandHandler<TCommandHandler, TCommand, TResult>(this IHub hub)
            where TCommandHandler : IHandler<TCommand, Task<TResult>>
        {
            hub.AddHandler<TCommandHandler, TCommand, Task<TResult>>(true);
        }
    }
}