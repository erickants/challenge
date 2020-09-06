using Microsoft.Extensions.DependencyInjection;
using src.back.Challenge.Domain.Core.Wireup;
using src.back.Challenge.Infra.CrossCutting.Handlers;
using src.back.Challenge.Infra.CrossCutting.Wireup;

namespace src.back.Challenge.Infra.CrossCutting.Configurations
{
    public static partial class CommandHandlersConfiguration
    {
        public static IServiceCollection AddCommandHandlers(this IServiceCollection services)
            => services.AddTransient<IRequestDispatcher, RequestDispatcher>()
                .AddHandlers()
                .AddSingleton<IHub, Hub>()
                .AddTransient<IHandlerExecutor, HandlerExecutor>();
    }
}