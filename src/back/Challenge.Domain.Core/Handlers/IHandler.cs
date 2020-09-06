using System.Threading.Tasks;

namespace src.back.Challenge.Domain.Core.Handlers
{
    public interface IHandler <TInput, TOutput>
    {
        TOutput Handle(TInput input);
    }

    public interface IAsyncHandler<TInput> : IHandler<TInput, Task>
    { }

    public interface IAsyncHandler<TInput, TOutput>
      : IHandler<TInput, Task<TOutput>>
    { }
}