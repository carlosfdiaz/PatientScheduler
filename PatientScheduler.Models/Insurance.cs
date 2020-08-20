using System.ComponentModel.DataAnnotations;


namespace PatientScheduler.Models
{
    public class Insurance
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Insurance Name")]
        public string Name { get; set; }

        [Required]
        [Display(Name = "Group Number")]
        public string GroupNumber { get; set; }

        public string Phone { get; set; }
    }
}
