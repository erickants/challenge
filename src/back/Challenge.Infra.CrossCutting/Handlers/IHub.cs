using System;
using System.Collections.Generic;
using src.back.Challenge.Domain.Core.Handlers;

namespace src.back.Challenge.Infra.CrossCutting.Handlers
{
    public interface IHub
    {
        void AddHandler<THandler, TInput, TOutput>(bool ensureUnique)
            where THandler : IHandler<TInput, TOutput>;

        IEnumerable<IHandlerWrapper> GetHandlersFor(Type input, Type output);
    }
}