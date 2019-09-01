using System;
using System.Collections.Generic;

namespace Domain.ValueObjects.Schedule
{
    public class Schedule : ValueObject
    {
        public Day Monday { get; private set; }
        public Day Tuesday { get; private set; }
        public Day Wednesday { get; private set; }
        public Day Thursday { get; private set; }
        public Day Friday { get; private set; }
        public Day Saturday { get; private set; }
        public Day Sunday { get; private set; }

        public Schedule(DayTime beginDayTime, DayTime endDayTime)
        {
            Monday = new Day(beginDayTime, endDayTime);
            Tuesday = new Day(beginDayTime, endDayTime);
            Wednesday = new Day(beginDayTime, endDayTime);
            Thursday = new Day(beginDayTime, endDayTime);
            Friday = new Day(beginDayTime, endDayTime);
            Saturday = new Day(beginDayTime, endDayTime);
            Sunday = new Day(beginDayTime, endDayTime);
        }
        public Schedule(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Monday = new Day(beginHour, beginMinute, endHour, endMinute);
            Tuesday = new Day(beginHour, beginMinute, endHour, endMinute);
            Wednesday = new Day(beginHour, beginMinute, endHour, endMinute);
            Thursday = new Day(beginHour, beginMinute, endHour, endMinute);
            Friday = new Day(beginHour, beginMinute, endHour, endMinute);
            Saturday = new Day(beginHour, beginMinute, endHour, endMinute);
            Sunday = new Day(beginHour, beginMinute, endHour, endMinute);
        }
        private Schedule()
        {

        }

        public void SetMonday(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Monday = new Day(beginHour, beginMinute, endHour, endMinute);
        }
        public void SetTuesday(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Tuesday = new Day(beginHour, beginMinute, endHour, endMinute);
        }
        public void SetWednesday(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Wednesday = new Day(beginHour, beginMinute, endHour, endMinute);
        }
        public void SetThursday(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Thursday = new Day(beginHour, beginMinute, endHour, endMinute);
        }
        public void SetFriday(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Friday = new Day(beginHour, beginMinute, endHour, endMinute);
        }
        public void SetSaturday(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Saturday = new Day(beginHour, beginMinute, endHour, endMinute);
        }
        public void SetSunday(int beginHour, int beginMinute, int endHour, int endMinute)
        {
            Sunday = new Day(beginHour, beginMinute, endHour, endMinute);
        }
        public void ResetSchedule()
        {
            Monday = new Day(new DayTime(0, 0), new DayTime(23, 59));
            Tuesday = new Day(new DayTime(0, 0), new DayTime(23, 59));
            Wednesday = new Day(new DayTime(0, 0), new DayTime(23, 59));
            Thursday = new Day(new DayTime(0, 0), new DayTime(23, 59));
            Friday = new Day(new DayTime(0, 0), new DayTime(23, 59));
            Saturday = new Day(new DayTime(0, 0), new DayTime(23, 59));
            Sunday = new Day(new DayTime(0, 0), new DayTime(23, 59));
        }
        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Monday;
            yield return Tuesday;
            yield return Wednesday;
            yield return Thursday;
            yield return Friday;
            yield return Saturday;
            yield return Sunday;
        }
    }
}
