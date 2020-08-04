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
    public class PatientController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        [BindProperty]
        public Patient PatientVM { get; set; }

        public PatientController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult PatientList()
        {
            return View(_unitOfWork.Patient.GetAll());
        }

        public IActionResult PatientPage(int id)
        {           
           return View(_unitOfWork.Patient.GetFirstOrDefault(p => p.Id == id, Utility.InsuranceProp + "," + Utility.AddressProp));            
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostCreate()
        {
            if (!ModelState.IsValid)
            {
                return View(PatientVM);
            }

            _unitOfWork.Patient.Add(PatientVM);
            _unitOfWork.Save();

            return RedirectToAction(nameof(PatientPage), PatientVM);
        }

        public IActionResult EditPatient(int id)
        {
            return View(_unitOfWork.Patient.GetFirstOrDefault(x => x.Id == id, "Address"));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult PostEditPatient()
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(PatientList));
            }
    
            _unitOfWork.Patient.Update(PatientVM);
            return RedirectToAction(nameof(PatientPage), PatientVM);
        }

        public IActionResult PatientInsurance(int id)
        {
            return View(_unitOfWork.Patient.GetFirstOrDefault(p => p.Id == id));
        }

        [HttpPost]
        public IActionResult PostPatientInsurance()
        {
            if (!ModelState.IsValid)
            {
                RedirectToAction(nameof(PatientInsurance));
            }

            _unitOfWork.Patient.UpdateInsurance(PatientVM);

            return RedirectToAction(nameof(PatientPage), PatientVM);
        }

        public IActionResult EditPatientInsurance(int id)
        {
            return View(_unitOfWork.Patient.GetFirstOrDefault(p => p.Id == id, Utility.InsuranceProp));
        }
    }
}
