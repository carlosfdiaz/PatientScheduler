using System;
using System.Collections.Generic;
using System.Text;

namespace PatientScheduler.Models
{
    public class Address
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public int Zip { get; set; }
    }
}
