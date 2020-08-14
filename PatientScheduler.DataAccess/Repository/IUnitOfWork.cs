using System;
using System.Collections.Generic;
using System.Text;

namespace PatientScheduler.DataAccess.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        IPatientRepository Patient { get; }
        IInsuranceRepository Insurance { get; }
        IAddressRepository Address { get; }

        IAppointmentRepository Appointment { get; }
        void Save();
    }
}
