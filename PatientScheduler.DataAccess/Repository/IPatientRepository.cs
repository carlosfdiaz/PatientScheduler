using PatientScheduler.Models;

namespace PatientScheduler.DataAccess.Repository
{
    public interface IPatientRepository : IRepository<Patient>
    {
        void Update(Patient patient);

        void CreatePatientInsurance(Patient patient);
    }
}
