using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;

namespace src.back.Challenge.Infra.CrossCutting.Handlers
{
    public class HandlerExecutor : IHandlerExecutor
    {
        private IServiceProvider _serviceProvider;
        private IHub _hub;

        public HandlerExecutor(
            IServiceProvider serviceProvider
            , IHub hub)
        {
            _hub = hub;
            _serviceProvider = serviceProvider;
        }

        public IEnumerable<TOutput> ExecuteMany<TOutput>(
            object input
            , Type inputType = null)
        {
            inputType ??= input.GetType();

            var wrappers = _hub.GetHandlersFor(inputType, typeof(TOutput));

            ThrowIfEmpty<TOutput>(input, wrappers);

            foreach (var wrapper in wrappers)
            {
                yield return (TOutput) ExecuteHandler(wrapper, input);
            }
        }

        private void ThrowIfEmpty<TOutput>(
            object input
            , IEnumerable<IHandlerWrapper> wrappers)
        {
            if (!wrappers.Any())
            {
                ThrowHandlerNotFound(input.GetType(), typeof(TOutput));
            }
        }

        public IEnumerable<Task> ExecuteMany(
            object input
            , Type inputType = null)
        {
            return ExecuteMany<Task>(input, inputType);
        }

        public TOutput ExecuteSingle<TOutput>(
            object input
            , Type inputType = null)
        {
            inputType ??= input.GetType();

            var wrappers = _hub.GetHandlersFor(inputType, typeof(TOutput));

            if (!wrappers.Any())
            {
                ThrowHandlerNotFound(input.GetType(), typeof(TOutput));
            }
            else if (wrappers.Count() != 1)
            {
                ThrowMultipleHandlersFound(input.GetType(), typeof(TOutput));
            }

            var wrapper = wrappers.Single();

            return (TOutput) ExecuteHandler(wrapper, input);
        }

        public Task ExecuteSingle(object input, Type inputType = null)
        {
            return ExecuteSingle<Task>(input, inputType);
        }

        private object ExecuteHandler(IHandlerWrapper wrapper, object input)
        {
            var handler = _serviceProvider.GetRequiredService(
                wrapper.HandlerType);

            return wrapper.Execute(handler, input);
        }

        private void ThrowHandlerNotFound(Type input, Type output)
        {
            throw new ArgumentException($"No handler registered for: {input}, {output}");
        }

        private void ThrowMultipleHandlersFound(Type input, Type output)
        {
            throw new ArgumentException($"Multiple handlers on single execution for type: {input}, {output}");
        }
    }
}