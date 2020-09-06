using System;
using src.back.Challenge.Domain.Core.Handlers;

namespace src.back.Challenge.Infra.CrossCutting.Handlers
{
    public class HandlerWrapper : IHandlerWrapper
    {
        private readonly Func<object, object, object> _lambda;
        private readonly Type _handlerType;

        private HandlerWrapper(
            Type handlerType
            , Func<object, object, object> lambda)
        {
            _handlerType = handlerType;
            _lambda = lambda;
        }

        public Type HandlerType => _handlerType;

        public object Execute(object handler, object input)
        {
            return _lambda.Invoke(handler, input);
        }

        public static IHandlerWrapper CreateFor<THandler, TInput, TOutput>()
            where THandler : IHandler<TInput, TOutput>
        {
            var type = typeof(THandler);
            var lambda = CreateLambda<TInput, TOutput>();

            return new HandlerWrapper(type, lambda);
        }

        private static Func<object, object, object> CreateLambda<TInput, TOutput>()
        {
            return (handler, input) =>
            {
                var typedHandler = handler as IHandler<TInput, TOutput>;

                return (TOutput)typedHandler.Handle((TInput)input);
            };
        }
    }
}