using System;
using System.Collections.Generic;
using System.Text;

namespace PatientScheduler.Models
{
    public class PatientAppointmentListVM
    {
        public Patient Patient { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
      
    }
}
