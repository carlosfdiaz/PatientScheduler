using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PatientScheduler.DataAccess.Repository;
using PatientScheduler.Models;
using System;
using System.Linq;

namespace PatientScheduler.Areas.User.Controllers
{
    [Authorize(Roles = Utility.UserRole)]
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public IActionResult Index()
        {
            var DbF = Microsoft.EntityFrameworkCore.EF.Functions;
            var PatientAppointmentListVM = new PatientAppointmentListVM();
            var today = DateTime.Now.Date;
            var nextDay = DateTime.Now.Date.AddDays(1);
            PatientAppointmentListVM.Appointments = _unitOfWork.Appointment.GetAll(a => a.StartTime >= today && a.EndTime <= nextDay, a => a.OrderBy(a => a.StartTime), Utility.PatientProp + "," + Utility.DoctorProp);
            return View(PatientAppointmentListVM);
        }

     
    }
}
