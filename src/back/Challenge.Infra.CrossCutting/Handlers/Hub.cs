using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using src.back.Challenge.Domain.Core.Handlers;
using src.back.Challenge.Infra.CrossCutting.Configurations;

namespace src.back.Challenge.Infra.CrossCutting.Handlers
{
    public class Hub : IHub
    {
        private ConcurrentDictionary<object, ConcurrentQueue<IHandlerWrapper>> _handlers;
        private readonly IEnumerable<IHandlerWrapper> EmptyList = Enumerable.Empty<IHandlerWrapper>();

        public Hub()
        {
            _handlers = new ConcurrentDictionary<object, ConcurrentQueue<IHandlerWrapper>>();

            this.ConfigureHandlers();
        }

        public void AddHandler<THandler, TInput, TOutput>(bool ensureUnique)
            where THandler : IHandler<TInput, TOutput>
        {
            var key = CreateKeyFor(typeof(TInput), typeof(TOutput));

            if (_handlers.TryGetValue(key, out var wrappers))
            {
                if (ensureUnique)
                {
                    ThrowDuplicatedHandler<THandler, TInput, TOutput>();
                }
            }
            else
            {
                wrappers = new ConcurrentQueue<IHandlerWrapper>();

                if (!_handlers.TryAdd(key, wrappers))
                {
                    throw new InvalidProgramException("Failed to add handler into handlers list.");
                }
            }

            wrappers.Enqueue(HandlerWrapper.CreateFor<THandler, TInput, TOutput>());
        }

        private void ThrowDuplicatedHandler<THandler, TInput, TOutput>()
        {
            throw new ArgumentException($"Cant register '{typeof(THandler)}' cause there's already a handler for: {typeof(TInput)}, {typeof(TOutput)}");
        }

        public IEnumerable<IHandlerWrapper> GetHandlersFor(
            Type input
            , Type output)
        {
            var key = CreateKeyFor(input, output);

            if (_handlers.TryGetValue(key, out var wrappers))
            {
                return wrappers.ToArray();
            }

            return EmptyList;
        }

        private Tuple<Type, Type> CreateKeyFor(Type inputType, Type outputType)
        {
            return Tuple.Create(inputType, outputType);
        }
    }
}