using System;

namespace src.back.Challenge.Domain.Core.Commands
{
    public interface ICommandResult
    {
        DateTime Executed { get; }
        bool IsValid();
    }
}