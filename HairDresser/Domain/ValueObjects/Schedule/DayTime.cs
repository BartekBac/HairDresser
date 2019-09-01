using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Domain.ValueObjects.Schedule
{
    public class DayTime : ValueObject
    {
        [Range(0, 23, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Hour { get; private set; }
        [Range(0, 59, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Minute { get; private set; }
        
        public DayTime(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
        }
        private DayTime()
        {

        }

        public static bool operator ==(DayTime left, DayTime right)
        {
            if(left.Hour == right.Hour)
            {
                return left.Minute == right.Minute;
            }
            return false;
        }
        public static bool operator !=(DayTime left, DayTime right)
        {
            if (left.Hour == right.Hour)
            {
                return left.Minute != right.Minute;
            }
            return true;
        }
        public static bool operator <=(DayTime left, DayTime right)
        {
            if (left.Hour < right.Hour)
            {
                return true;
            }
            if (left.Hour == right.Hour)
            {
                return left.Minute <= right.Minute;
            }
            return false;
        }
        public static bool operator >=(DayTime left, DayTime right)
        {
            if (left.Hour > right.Hour)
            {
                return true;
            }
            if (left.Hour == right.Hour)
            {
                return left.Minute >= right.Minute;
            }
            return false;
        }
        public static bool operator <(DayTime left, DayTime right)
        {
            if (left.Hour < right.Hour)
            {
                return true;
            }
            if (left.Hour == right.Hour)
            {
                return left.Minute < right.Minute;
            }
            return false;
        }
        public static bool operator >(DayTime left, DayTime right)
        {
            if (left.Hour > right.Hour)
            {
                return true;
            }
            if (left.Hour == right.Hour)
            {
                return left.Minute > right.Minute;
            }
            return false;
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Hour;
            yield return Minute;
        }
    }
}
