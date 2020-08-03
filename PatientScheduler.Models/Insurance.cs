﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace PatientScheduler.Models
{
    public class Insurance
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string GroupNumber { get; set; }

        public string Phone { get; set; }
    }
}
