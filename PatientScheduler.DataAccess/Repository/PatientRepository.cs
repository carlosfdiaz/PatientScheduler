using PatientScheduler.DataAccess.Data;
using PatientScheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace PatientScheduler.DataAccess.Repository
{
    public class PatientRepository : Repository<Patient>, IPatientRepository
    {
        private readonly ApplicationDbContext _db;

        public PatientRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Update(Patient patient)
        {
            var objFromDb = _db.Patients.FirstOrDefault(s => s.Id == patient.Id);
            objFromDb.FirstName = patient.FirstName;
            objFromDb.MiddleName = patient.MiddleName;
            objFromDb.LastName = patient.LastName;
            objFromDb.SSN = patient.SSN;
            objFromDb.Phone = patient.Phone;

            _db.SaveChanges();
        }
    }
}
