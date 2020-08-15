using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientScheduler.Models
{
    public class PatientAppointmentVM
    {
        public Patient Patient { get; set; }
        public Appointment Appointment { get; set; }

        [Required]
        public DateTime StartTime { get; set; }

        [Required]
        public DateTime EndTime { get; set; }
    }
}
