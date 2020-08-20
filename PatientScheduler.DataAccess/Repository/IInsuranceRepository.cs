using PatientScheduler.Models;

namespace PatientScheduler.DataAccess.Repository
{
    public interface IInsuranceRepository : IRepository<Insurance>
    {
        void Update(Insurance insurance);
    }
}
