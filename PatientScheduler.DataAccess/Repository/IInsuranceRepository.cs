using Microsoft.EntityFrameworkCore.Update.Internal;
using PatientScheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientScheduler.DataAccess.Repository
{
    public interface IInsuranceRepository : IRepository<Insurance>
    {
        void Update(Insurance insurance);
    }
}
