using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace PatientScheduler.Models
{
    public class Appointment
    {
        public int Id { get; set; }

        [ForeignKey("Doctor")]
        public int DoctorId { get; set; }
        public virtual Doctor Doctor { get; set; }

        [ForeignKey("Patient")]
        public int PatientId { get; set; }

        public virtual Patient Patient { get; set; }
   

        [Required]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        
        [Required]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }

        public int Status { get; set; }
    }
}
