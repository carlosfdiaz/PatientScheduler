using System.Collections.Generic;

namespace PatientScheduler.Models
{
    public class PatientAppointmentListVM
    {
        public Patient Patient { get; set; }
        public IEnumerable<Appointment> Appointments { get; set; }
      
    }
}
