using FreshShop.MvcWebUI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FreshShop.MvcWebUI.Areas.Yonetim.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if(SessionManager.ActiveUser != null)
                return View();

            return RedirectToAction("LogIn", "User");
        }
    }
}