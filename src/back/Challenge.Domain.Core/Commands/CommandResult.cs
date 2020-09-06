using System;

namespace src.back.Challenge.Domain.Core.Commands
{
    public class CommandResult : ICommandResult
    {
        public CommandResult()
        {
            
        }

        public CommandResult(object data)
        {
            Data = data;
        }

        public object Data { get; private set; }
        public DateTime Executed => DateTime.Now;

        public bool IsValid()
        {
            throw new NotImplementedException();
        }
    }
}