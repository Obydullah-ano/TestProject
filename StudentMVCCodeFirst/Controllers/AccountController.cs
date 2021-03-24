using StudentMVCCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace StudentMVCCodeFirst.Controllers
{
    public class AccountController : Controller
    {
        [AllowAnonymous]
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(tblUser obj)
        {
            using (var _context = new SchoolManagementContext())
            {
                bool isvalid = _context.tblUsers.Any(u => u.UserName == obj.UserName && u.UserPassword == obj.UserPassword);
                if (isvalid)
                {
                    FormsAuthentication.SetAuthCookie(obj.UserName, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Invalid User Information");
                    return View();
                }
            }
        }
        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(tblUser obj)
        {
            using (var _context = new SchoolManagementContext())
            {
                bool isExists = !_context.tblUsers.Any(u => u.UserName == obj.UserName);
                if (isExists)
                {
                    _context.tblUsers.Add(obj);
                    _context.SaveChanges();
                    int count = _context.tblUsers.Count();
                    if (count == 1)
                    {
                        return RedirectToAction("CreateRole", "Admin");
                    }
                    return View("Login");
                }
                else
                {
                    ModelState.AddModelError("", "User allready exists");
                    
                    //return RedirectToAction("Index", "Home");
                    return View();
                }

            }

        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}