using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PatientScheduler.DataAccess.Data;
using PatientScheduler.DataAccess.Repository;

namespace PatientScheduler.Areas.User.Controllers
{
    [Area("User")]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            
        }

        public ApplicationDbContext Db { get; }

        public IActionResult Index()
        {
            return View();
        }

     
    }
}
