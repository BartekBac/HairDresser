using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Schedule : Entity
    {
        public Day Monday { get; private set; }
        public Day Tuesday { get; private set; }
        public Day Wednesday { get; private set; }
        public Day Thursday { get; private set; }
        public Day Friday { get; private set; }
        public Day Saturday { get; private set; }
        public Day Sunday { get; private set; }

        public Schedule(Guid id, Schedule schedule) : base(id)
        {
            Monday = schedule.Monday;
            Tuesday = schedule.Tuesday;
            Wednesday = schedule.Wednesday;
            Thursday = schedule.Thursday;
            Friday = schedule.Friday;
            Saturday = schedule.Saturday;
            Sunday = schedule.Sunday;
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
    }
}
