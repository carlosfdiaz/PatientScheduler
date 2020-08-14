using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PatientScheduler.DataAccess.Repository;
using PatientScheduler.Models;

namespace PatientScheduler.Areas.User.Controllers
{
    [Area("User")]
    public class ScheduleController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public PatientAppointmentVM PatientAppointmentVM { get; set; }

        public ScheduleController(IUnitOfWork unitOfWork)
        {
            PatientAppointmentVM = new PatientAppointmentVM();
            Appointment Appointment = new Appointment();
            PatientAppointmentVM.Appointment = Appointment;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SchedulePatientAppointment(int id)
        {

            PatientAppointmentVM.Patient = _unitOfWork.Patient.Get(id);
            return View(PatientAppointmentVM);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostAppointment()
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Appointment.Add(PatientAppointmentVM.Appointment);
                _unitOfWork.Save();
                return new JsonResult(PatientAppointmentVM.Appointment);
                
            }
            return new JsonResult("invalidState");
        }
    }
}
