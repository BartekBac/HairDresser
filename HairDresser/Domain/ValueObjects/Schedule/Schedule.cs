using System;

namespace Domain.ValueObjects.Schedule
{
    public class Schedule
    {
        public Day Monday { get; private set; }
        public Day Tuesday { get; private set; }
        public Day Wednesday { get; private set; }
        public Day Thursday { get; private set; }
        public Day Friday { get; private set; }
        public Day Saturday { get; private set; }
        public Day Sunday { get; private set; }

        public Schedule()
        {
            Monday = new Day();
            Tuesday = new Day();
            Wednesday = new Day();
            Thursday = new Day();
            Friday = new Day();
            Saturday = new Day();
            Sunday = new Day();
        }
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
    }
}
