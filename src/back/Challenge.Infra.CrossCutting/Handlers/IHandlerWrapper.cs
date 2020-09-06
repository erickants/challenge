using System;

namespace src.back.Challenge.Infra.CrossCutting.Handlers
{
    public interface IHandlerWrapper
    {
        Type HandlerType { get; }
        object Execute(object handler, object input);
    }
}