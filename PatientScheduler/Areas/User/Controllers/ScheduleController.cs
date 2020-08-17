using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PatientScheduler.DataAccess.Repository;
using PatientScheduler.Models;
using PatientScheduler.Models.Enums;

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

        public IActionResult GetAppointments()
        {
            var appointments = _unitOfWork.Appointment.GetAll(null, null, Utility.PatientProp);
            List<CalendarEvent> calendarEvents = new List<CalendarEvent>();
            foreach(var appointment in appointments)
            {
                var calendarEvent = new CalendarEvent();
                calendarEvent.Title = appointment.Patient.FirstName + " " + appointment.Patient.LastName;
                calendarEvent.Start = appointment.StartTime;
                calendarEvent.End = appointment.EndTime;
                calendarEvent.Id = appointment.Id;
                calendarEvents.Add(calendarEvent);
            }
            return new JsonResult(calendarEvents);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostAppointment(IFormFileCollection form)
        {           
            if (ModelState.IsValid)
            {
                PatientAppointmentVM.Appointment.Status = (int)AppointmentStatus.Upcoming;
                _unitOfWork.Appointment.Add(PatientAppointmentVM.Appointment);
                _unitOfWork.Save();
                return new JsonResult(PatientAppointmentVM.Appointment);

            }
            return new JsonResult("invalidState");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostDeleteAppointment(int apptId, int patientId)
        {
            
            var objFromDb = _unitOfWork.Appointment.Get(apptId);
            if(objFromDb != null)
            {
                _unitOfWork.Appointment.Remove(objFromDb);
                _unitOfWork.Save();
            }

            return RedirectToAction("PatientPage", "Patient", new { id = patientId });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostChangeAppointmentStatus(int apptId, int patientId, AppointmentStatus status)
        {
            _unitOfWork.Appointment.UpdateStatus(apptId, (int)status);

            return RedirectToAction("PatientPage", "Patient", new { id = patientId });
        }
    }
}
