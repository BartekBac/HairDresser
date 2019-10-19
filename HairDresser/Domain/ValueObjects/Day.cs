using System;
using System.Collections.Generic;

namespace Domain.ValueObjects
{
    public class Day : ValueObject
    {
        public TimeSpan Begin { get; private set; }
        public TimeSpan End { get; private set; }
        public Boolean IsActive { get; private set; }

        public Day(TimeSpan begin, TimeSpan end)
        {
            Begin = begin;
            End = end;
            IsActive = true;
        }
        public Day(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Begin = new TimeSpan(beginHour, beginMinute, 0);
            End = new TimeSpan(endHour, endMinute, 0);
            IsActive = true;
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
