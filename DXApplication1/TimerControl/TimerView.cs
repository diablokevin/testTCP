using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimerControl
{
    public class TimerView
    {
        enum TimerStatus
        {
            NOT_READY=0,
            MANUAL_SET=10,
            MANUAL_TIMING=11,
            MANUAL_STOP=12,
            AUTO_SET = 20,
            AUTOL_TIMING = 21,
            AUTOL_STOP = 22
        };

        private int chip_ID;
        private TimerStatus status = 0;
        private string name;
        private TimeSpan time_used = new TimeSpan(0, 0, 0);
        private TimeSpan time_limit = new TimeSpan(0, 0, 0);

        public int Chip_ID { get => chip_ID; set => chip_ID = value; }
        private TimerStatus Status { get => status; set => status = value; }
        public string Name { get => name; set => name = value; }
        public TimeSpan Time_used { get => time_used; set => time_used = value; }
        public TimeSpan Time_limit { get => time_limit; set => time_limit = value; }
    }
}
