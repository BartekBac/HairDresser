using System;
using System.Collections.Generic;
using System.Text;

namespace Application.DTOs
{
    public class ScheduleDto
    {
        public string EntityId { get; set; }
        public DayDto Monday { get; set; }
        public DayDto Tuesday { get; set; }
        public DayDto Wednesday { get; set; }
        public DayDto Thursday { get; set; }
        public DayDto Friday { get; set; }
        public DayDto Saturday { get; set; }
        public DayDto Sunday { get; set; }
    }
}
