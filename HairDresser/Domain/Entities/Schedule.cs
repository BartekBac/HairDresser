using Domain.ValueObjects;
using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class Schedule<T> : Entity
    {
        public T Entity { get; private set; }
        public Guid EntityId { get; private set; }
        public Day Monday { get; private set; }
        public Day Tuesday { get; private set; }
        public Day Wednesday { get; private set; }
        public Day Thursday { get; private set; }
        public Day Friday { get; private set; }
        public Day Saturday { get; private set; }
        public Day Sunday { get; private set; }

        public Schedule(Guid entityId, T entity, TimeSpan beginDayTime, TimeSpan endDayTime)
        {
            EntityId = entityId;
            Entity = entity;
            Monday = new Day(beginDayTime, endDayTime);
            Tuesday = new Day(beginDayTime, endDayTime);
            Wednesday = new Day(beginDayTime, endDayTime);
            Thursday = new Day(beginDayTime, endDayTime);
            Friday = new Day(beginDayTime, endDayTime);
            Saturday = new Day(beginDayTime, endDayTime);
            Sunday = new Day(beginDayTime, endDayTime);
        }
        public Schedule(Guid entityId, T entity, int beginHour, int beginMinute, int endHour, int endMinute)
        {
            EntityId = entityId;
            Entity = entity;
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
        public void SetEntity(Guid entityId, T entity)
        {
            Entity = entity;
            EntityId = entityId;
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
            Monday = new Day(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
            Tuesday = new Day(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
            Wednesday = new Day(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
            Thursday = new Day(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
            Friday = new Day(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
            Saturday = new Day(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
            Sunday = new Day(new TimeSpan(0, 0, 0), new TimeSpan(23, 59, 0));
        }
    }
}
