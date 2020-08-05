using PatientScheduler.DataAccess.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientScheduler.DataAccess.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _db;

        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Patient = new PatientRepository(_db);
            Address = new AddressRepository(_db);
            Insurance = new InsuranceRepository(_db);
        }
        
        public IPatientRepository Patient { get; private set; }

        public IAddressRepository Address { get; private set; }

        public IInsuranceRepository Insurance { get; private set; }

        public void Dispose()
        {
            _db.Dispose();
        }

        public void Save()
        {
            _db.SaveChanges();
        }
    }
}
