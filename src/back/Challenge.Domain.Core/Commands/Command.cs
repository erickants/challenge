using System;

namespace src.back.Challenge.Domain.Core.Commands
{
    public abstract class Command<TResult>
            : ICommand<TResult>
        where TResult : ICommandResult
    {
        public DateTime Executed => DateTime.Now;

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}