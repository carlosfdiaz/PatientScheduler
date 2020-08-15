using System;
using System.Collections.Generic;
using System.Text;

namespace PatientScheduler.Models
{
    public class CalendarEvent
    {
        public string Title { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }

    }
}
