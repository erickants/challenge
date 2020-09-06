using System;

namespace src.back.Challenge.Infra.Job.Options
{
    public class ScheduleOption
    {
        public int StartAt { get; set; }
        public int EndAt { get; set; }
        public bool Active { get; set; }
    }
}