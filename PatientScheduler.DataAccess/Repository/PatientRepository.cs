using Microsoft.EntityFrameworkCore;
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
            var objFromDb = _db.Patients.Include(p => p.Address).SingleOrDefault(p => p.Id == patient.Id);
            objFromDb.FirstName = patient.FirstName;
            objFromDb.MiddleName = patient.MiddleName;
            objFromDb.LastName = patient.LastName;
            objFromDb.SSN = patient.SSN;
            objFromDb.Gender = patient.Gender;
            objFromDb.Phone = patient.Phone;
            objFromDb.DateOfBirth = patient.DateOfBirth;
            objFromDb.Address.Street = patient.Address.Street;
            objFromDb.Address.City = patient.Address.City;
            objFromDb.Address.State = patient.Address.State;
            objFromDb.Address.Zip = patient.Address.Zip;

            _db.SaveChanges();
        }

        public void UpdateInsurance(Patient patient)
        {
            var objFromDb = _db.Patients.Include(p => p.Insurance).SingleOrDefault(p => p.Id == patient.Id);
            objFromDb.Insurance.Name = patient.Insurance.Name;
            objFromDb.Insurance.GroupNumber = patient.Insurance.GroupNumber;
            objFromDb.Insurance.Phone = patient.Insurance.Phone;

            _db.SaveChanges();
        }
    }
}
