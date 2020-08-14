using PatientScheduler.DataAccess.Data;
using PatientScheduler.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace PatientScheduler.DataAccess.Repository
{
    public class AppointmentRepository : Repository<Appointment>, IAppointmentRepository
    {
        private readonly ApplicationDbContext _db;

        public AppointmentRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
