using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMVCCodeFirst.Controllers
{
    public class HomeController : Controller
    {     
        [Authorize(Roles = ("Admin,SuperAdmin,User,Student"))]
        public ActionResult Index()
        {
            return View();
        }
    }
}