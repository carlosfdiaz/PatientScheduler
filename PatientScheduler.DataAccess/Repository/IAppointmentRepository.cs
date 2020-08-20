using PatientScheduler.Models;


namespace PatientScheduler.DataAccess.Repository
{
    public interface IAppointmentRepository : IRepository<Appointment>
    {
        void UpdateStatus(int id, int status);
    }
}
