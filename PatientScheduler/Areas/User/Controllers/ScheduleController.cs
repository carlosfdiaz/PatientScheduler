using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
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

        public IActionResult GetAppointments()
        {
            var appointments = _unitOfWork.Appointment.GetAll();
            List<CalendarEvent> calendarEvents = new List<CalendarEvent>();
            foreach(var appointment in appointments)
            {
                var calendarEvent = new CalendarEvent();
                calendarEvent.Title = appointment.Id.ToString();
                calendarEvent.Start = appointment.StartTime;
                calendarEvent.End = appointment.EndTime;
                calendarEvents.Add(calendarEvent);
            }
            return new JsonResult(calendarEvents);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostAppointment(IFormFileCollection form)
        {
            var show =PatientAppointmentVM;
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
