﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PatientScheduler.Areas.User.Controllers
{
    [Area("User")]
    public class ScheduleController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult SchedulePatientAppointment()
        {
            return View();
        }
    }
}