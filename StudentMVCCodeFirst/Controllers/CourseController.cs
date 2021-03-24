using Newtonsoft.Json;
using StudentMVCCodeFirst.BLL.Repositories;
using StudentMVCCodeFirst.Models;
using StudentMVCCodeFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace StudentMVCCodeFirst.Controllers
{
    public class CourseController : Controller
    {
        SchoolManagementContext db = new SchoolManagementContext();
        
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult GetCourseDetails()
        {

            var studentList = db.Courses.Where(s => s.IsDeleted == false).Select(s => new CourseViewModel
            {
                Id = s.Id,
                CourseName = s.CourseName,
            }).ToList();
            return Json(studentList, JsonRequestBehavior.AllowGet);




            //var CoList = db.Courses.Select(c => new Course
            //{
            //    Id = c.Id,
            //    CourseName = c.CourseName
            //}).ToList();
            //return Json(CoList, JsonRequestBehavior.AllowGet);
        }
        public JsonResult SaveDataInToDatabase(CourseViewModel viewobj)
        {
            var result = false;
            if (viewobj.Id == 0)
            {
                Course cobj = new Course();
                cobj.CourseName = viewobj.CourseName;                
                db.Courses.Add(cobj);
                db.SaveChanges();
                result = true;
            }
            else
            {
                Course model = db.Courses.Where(s => s.Id == viewobj.Id).SingleOrDefault();
                model.CourseName = viewobj.CourseName;              
                db.SaveChanges();
                result = true;
            }
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetCourseById(int Id)
        {
            Course obj = db.Courses.Where(s => s.Id == Id).SingleOrDefault();
            string value = "";
            value = JsonConvert.SerializeObject(obj, Formatting.Indented, new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Ignore
            });

            return Json(value, JsonRequestBehavior.AllowGet);


        }

        public PartialViewResult GetDetailsCourseRecord(int Id)
        {
            Course obj = db.Courses.Where(s => s.Id == Id).SingleOrDefault();
            CourseViewModel vObj = new CourseViewModel();
            vObj.Id = obj.Id;
            vObj.CourseName = obj.CourseName;           
            return PartialView("_CourseDetails", vObj);

        }

        
        

    }
}