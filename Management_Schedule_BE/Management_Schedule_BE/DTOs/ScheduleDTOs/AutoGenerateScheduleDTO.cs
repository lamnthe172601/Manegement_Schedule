using System;
using System.Collections.Generic;

namespace Management_Schedule_BE.DTOs
{
    public class AutoGenerateScheduleDTO
    {
        public int ClassID { get; set; }
        public DateTime StartDate { get; set; }
        public int SlotCount { get; set; }
        public Dictionary<DayOfWeek, List<int>> DaysOfWeekSessions { get; set; } = new();
        public string Room { get; set; }
    }
} 