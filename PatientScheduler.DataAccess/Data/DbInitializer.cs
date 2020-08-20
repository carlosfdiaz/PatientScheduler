using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PatientScheduler.Models;
using System;
using System.Linq;

namespace PatientScheduler.DataAccess.Data
{
    public class DbInitializer : IDbInitializer
    {
        private readonly ApplicationDbContext _db;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public DbInitializer(ApplicationDbContext db, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _db = db;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async void Initialize()
        {
            try
            {
                if(_db.Database.GetPendingMigrations().Count() > 0)
                {
                    _db.Database.Migrate();
                }
            }
            catch (Exception ex)
            {

            }
            if (_db.Roles.Any(r => r.Name == Utility.UserRole)) return;
            _roleManager.CreateAsync(new IdentityRole(Utility.UserRole)).GetAwaiter().GetResult();

            _userManager.CreateAsync(new ApplicationUser
            {
                UserName = "reception@pscheduler.com",
                Email = "reception@pscheduler.com",
                Name = "Reception",
                EmailConfirmed = true
            }, "Letmein123!").GetAwaiter().GetResult();

            IdentityUser user = await _db.Users.FirstOrDefaultAsync(u => u.Email == "reception@pscheduler.com");
            await _userManager.AddToRoleAsync(user, Utility.UserRole);

            Doctor doctor1 = new Doctor(){ FirstName = "James", LastName = "Kite", Title = "Dr"};
            Doctor doctor2 = new Doctor() { FirstName = "Miranda", LastName = "Fernand", Title = "Dr" };

            _db.Doctors.Add(doctor1);
            _db.Doctors.Add(doctor2);
            await _db.SaveChangesAsync();

        }
    }
}
