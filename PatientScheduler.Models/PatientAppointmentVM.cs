using System;
using System.Collections.Generic;
using System.Text;

namespace PatientScheduler.Models
{
    public class PatientAppointmentVM
    {
        public Patient Patient { get; set; }
        public Appointment Appointment { get; set; }
    }
}
