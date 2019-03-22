using LynxMagnus.Models;
using LynxMagnus.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LynxMagnus.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Location = "Home";

            return View();
        }
    }
}