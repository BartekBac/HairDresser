using System;
using System.Collections.Generic;

namespace Domain.ValueObjects.Schedule
{
    public class Day : ValueObject
    {
       // public DayTime Begin { get; private set; }
       // public DayTime End { get; private set; }
        public int Begin { get; private set; }
        public int End { get; private set; }

        public Day(int begin, int end)
        {
            Begin = begin;
            End = end;
        }
        public Day(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Begin = beginHour + beginMinute;
            End = endHour + endMinute;
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
