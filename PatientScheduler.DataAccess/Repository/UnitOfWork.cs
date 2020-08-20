using PatientScheduler.DataAccess.Data;

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
            Appointment = new AppointmentRepository(_db);
            Doctor = new DoctorRepository(_db);
        }
        
        public IPatientRepository Patient { get; private set; }

        public IAddressRepository Address { get; private set; }

        public IInsuranceRepository Insurance { get; private set; }

        public IAppointmentRepository Appointment { get; private set; }

        public IDoctorRepository Doctor { get; private set; }

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
