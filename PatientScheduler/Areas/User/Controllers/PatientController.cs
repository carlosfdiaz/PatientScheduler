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

        //Get Create New Patient Form
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }


        //Submit New Patient Form
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

            return RedirectToAction(nameof(Index), "Home");
        }

        [HttpGet]
        public IActionResult PatientList()
        {
            return View(_unitOfWork.Patient.GetAll());
        }
    }
}
