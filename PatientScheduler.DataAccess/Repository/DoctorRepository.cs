using PatientScheduler.DataAccess.Data;
using PatientScheduler.Models;


namespace PatientScheduler.DataAccess.Repository
{
    public class DoctorRepository : Repository<Doctor>, IDoctorRepository
    {
        public DoctorRepository(ApplicationDbContext db) : base(db)
        {
        }
    }
}
