using System;
using System.Collections.Generic;

namespace Domain.ValueObjects.Schedule
{
    public class Day : ValueObject
    {
        public DayTime Begin { get; private set; }
        public DayTime End { get; private set; }

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
        private Day()
        {

        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Begin;
            yield return End;
        }
    }
}
