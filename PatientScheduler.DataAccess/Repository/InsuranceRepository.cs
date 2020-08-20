using PatientScheduler.DataAccess.Data;
using PatientScheduler.Models;

namespace PatientScheduler.DataAccess.Repository
{
    public class InsuranceRepository : Repository<Insurance>, IInsuranceRepository
    {
        private readonly ApplicationDbContext _db;

        public InsuranceRepository(ApplicationDbContext db) :base (db)
        {
            _db = db;
        }

        public void Update(Insurance insurance)
        {
            var objFromDb = _db.Insurances.Find(insurance.Id);
            objFromDb.Name = insurance.Name;
            objFromDb.GroupNumber = insurance.GroupNumber;
            objFromDb.Phone = insurance.Phone;

            _db.SaveChanges();
        }
    }
}
