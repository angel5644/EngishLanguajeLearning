using ELL.Models;
using ELL.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace ELL.Controllers
{
    public class HomeController : Controller
    {
        private EmergencyContactService _parentService;
        public HomeController()
        {
            _parentService = new EmergencyContactService();
        }

        public ActionResult Index()
        {
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}