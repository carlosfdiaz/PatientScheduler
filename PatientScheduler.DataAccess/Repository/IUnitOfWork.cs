using System;

namespace PatientScheduler.DataAccess.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patient { get; }
        IInsuranceRepository Insurance { get; }
        IAddressRepository Address { get; }
        IAppointmentRepository Appointment { get; }
        IDoctorRepository Doctor { get; }
        void Save();
    }
}
