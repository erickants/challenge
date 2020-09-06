using System;
using System.Threading.Tasks;
using Hangfire;
using Microsoft.Extensions.Options;
using src.back.Challenge.Domain.Core.Wireup;
using src.back.Challenge.Domain.InvestmentRules.CommandResults;
using src.back.Challenge.Domain.InvestmentRules.Commands;
using src.back.Challenge.Infra.Job.Options;

namespace src.back.Challenge.Infra.Job.Schedules
{
    public class InvestmentSchedule
    {
        private readonly IRequestDispatcher _requestDispatcher;
        private readonly ScheduleOption _scheduleOption;

        public InvestmentSchedule(IRequestDispatcher requestDispatcher
            , IOptionsMonitor<ScheduleOption> options)
        {
            _requestDispatcher = requestDispatcher;
            _scheduleOption = options.CurrentValue;
        }

        public void AddIncome()
        {
            if (_scheduleOption.Active)
                RecurringJob.AddOrUpdate(() => ExecuteAsync(),
                    $"*/1 {_scheduleOption.StartAt}-{_scheduleOption.EndAt} * * *",
                    TimeZoneInfo.Local);
        }

        public async Task ExecuteAsync()
        {
            var command = new AddIncomeCommand();

            await _requestDispatcher.Dispatch<AddIncomeCommandResult>(command);
        }
    }
}