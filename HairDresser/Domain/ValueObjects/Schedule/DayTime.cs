using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.ValueObjects.Schedule
{
    public class DayTime
    {
        [Range(0, 23, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Hour { get; set; }
        [Range(0, 59, ErrorMessage = "Value for {0} must be between {1} and {2}.")]
        public int Minute { get; set; }
        
        public DayTime()
        {
            Hour = 0;
            Minute = 0;
        }
        public DayTime(int hour, int minute)
        {
            Hour = hour;
            Minute = minute;
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
    }
}
