using ManDates.Models.Entities;
using System;
using System.Collections.Generic;

namespace ManDates.Models
{
    public class WeekSchedule
    {
        public int Week { get; set; }
        public IEnumerable<Tuple<Member,Member>> Pairs { get; set; }
    }
}
