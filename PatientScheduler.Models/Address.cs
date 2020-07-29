﻿using System.ComponentModel.DataAnnotations;

namespace PatientScheduler.Models
{
    public class Address
    {
        public int Id { get; set; }

        [Required]
        public string Street { get; set; }

        [Required]
        public string City { get; set; }

        [Required]
        public string State { get; set; }

        [Required]
        [MaxLength(5)]
        public string Zip { get; set; }
    }
}
