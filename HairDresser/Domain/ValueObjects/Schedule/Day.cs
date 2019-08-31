using System;

namespace Domain.ValueObjects.Schedule
{
    public class Day
    {
        public DayTime Begin { get; set; }
        public DayTime End { get; set; }

        public Day()
        {
            Begin = new DayTime();
            End = new DayTime(23, 59);
        }
        public Day(DayTime begin, DayTime end)
        {
            Begin = begin;
            End = end;
        }
        public Day(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Begin = new DayTime(beginHour, beginMinute);
            End = new DayTime(endHour, endMinute);
        }
    }
}
