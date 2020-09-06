using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace src.back.Challenge.Infra.CrossCutting.Handlers
{
    public interface IHandlerExecutor
    {
        TOutput ExecuteSingle<TOutput>(object input, Type inputType = null);
        Task ExecuteSingle(object input, Type inputType = null);
        IEnumerable<TOutput> ExecuteMany<TOutput>(object input, Type inputType = null);
        IEnumerable<Task> ExecuteMany(object input, Type inputType = null);
    }
}