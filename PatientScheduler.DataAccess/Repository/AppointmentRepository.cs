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

        public void UpdateStatus(int id, int status)
        {
            var objFromDb = _db.Appointments.Find(id);
            if (objFromDb != null)
            {
                objFromDb.Status = status;
                _db.SaveChanges();
            }
           
        }
    }
}
