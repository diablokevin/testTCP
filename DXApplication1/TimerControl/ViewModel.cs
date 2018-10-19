using System;

namespace TimerControl
{
    public class TimerView
    {
        public enum TimerStatus
        {
            NOT_READY=0,
            MANUAL_SET=10,
            MANUAL_TIMING=11,
            MANUAL_STOP=12,
            AUTO_SET = 20,
            AUTO_TIMING = 21,
            AUTO_STOP = 22
        };

        public int? Chip_ID { get; set; }
        public TimerStatus Status { get; set; } = 0;

        public TimeSpan Time_used { get; set; } = new TimeSpan(0, 0, 0);
        public string IpAddress { get; set; }
        public int? Event_Id { get; set; }
    }

    public class EventView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public TimeSpan? Time_limit { get; set; } = new TimeSpan(0, 0, 0);
        public TimerView Timer { get; set; } = new TimerView();
        public Competitor Competitor { get; set; }              
    }

    public class Competitor
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Race_num { get; set; }
        public string Company { get; set; }
    }
}
