using Microsoft.AspNetCore.Identity;

namespace PatientScheduler.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string Name { get; set; }
    }
}
