using PatientScheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientScheduler.DataAccess.Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient patient);

        void UpdateInsurance(Patient patient);
    }
}
