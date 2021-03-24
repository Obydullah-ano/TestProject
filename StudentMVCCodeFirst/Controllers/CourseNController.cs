using StudentMVCCodeFirst.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace StudentMVCCodeFirst.Controllers
{
    public class CourseNController : Controller
    {
        SchoolManagementContext db = new SchoolManagementContext();
        public ActionResult Index()
        {
            using (var _context = new SchoolManagementContext())
            {
                List<Course> list = _context.Courses.ToList();
                return View(list);
            }

        }

        public JsonResult InsertCourses(List<Course> courses)
        {
            int insertRecords = 0;

            using (var _context = new SchoolManagementContext())
            {
                _context.Database.ExecuteSqlCommand("TRUNCATE TABLE[Courses]");
                if (courses == null)
                {
                    courses = new List<Course>();
                }
                foreach (var item in courses)
                {
                    _context.Courses.Add(item);
                }
                insertRecords = _context.SaveChanges();
                return Json(insertRecords);
            }

        }
    }
}