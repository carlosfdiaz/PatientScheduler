using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
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
    }
}
