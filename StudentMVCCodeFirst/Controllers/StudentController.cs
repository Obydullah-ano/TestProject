using StudentMVCCodeFirst.BLL.Repositories;
using StudentMVCCodeFirst.Models;
using StudentMVCCodeFirst.Models.ViewModels;
using PagedList;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;
using System.Data.SqlClient;
using System.Web.UI;

namespace StudentMVCCodeFirst.Controllers
{
    [Authorize(Roles = ("Admin,SuperAdmin,User"))]
    public class StudentController : Controller
    {
        
        StudentRepository repoObj = new StudentRepository();       
        public ActionResult Index(string SearchString, string CurrentFilter, string sortOrder, int? Page)
        {
            ViewBag.SortNameParam = string.IsNullOrEmpty(sortOrder) ? "name_desc" : "";
            if (SearchString != null)
            {
                Page = 1;
            }
            else
            {
                SearchString = CurrentFilter;
            }
            ViewBag.CurrentFilter = SearchString;
            List<StudentListViewModel> studList = repoObj.GetStudents();
            if (!string.IsNullOrEmpty(SearchString))
            {
                studList = studList.Where(n => n.StudentName.ToUpper().Contains(SearchString.ToUpper())).ToList();
            }
            switch (sortOrder)
            {
                case "name_desc":
                    studList = studList.OrderByDescending(n => n.StudentName).ToList();
                    break;
                default:
                    break;
            }
            int PageSize = 3;
            int PageNumber = (Page ?? 1);
            return View("Index", studList.ToPagedList(PageNumber, PageSize));
           
        }
        public ActionResult Create()
        {
            CreateStudentViewModel obj = new CreateStudentViewModel();
            obj.CoList = repoObj.GetCourses();
            return View(obj);
        }
        [HttpPost]
        public ActionResult AddOrEdit(CreateStudentViewModel viewObj)
        {
            var result = false;
            Student studObj = new Student();
            studObj.StudentName = viewObj.StudentName;
            studObj.Email = viewObj.Email;
            studObj.DateOfBirth = viewObj.DateOfBirth;
            studObj.IsSitAvailable = viewObj.IsSitAvailable;
            studObj.CourseFee = viewObj.CourseFee;

            string filename = Path.GetFileNameWithoutExtension(viewObj.ImageFile.FileName);
            string extension = Path.GetExtension(viewObj.ImageFile.FileName);
            string fileWithExtension = filename + extension;
            studObj.ImageUrl = "~/Images/" + fileWithExtension;
            studObj.ImageName = fileWithExtension;

            string fileWithServerPath = Path.Combine(Server.MapPath("~/Images/" + filename + extension));
            viewObj.ImageFile.SaveAs(fileWithServerPath);
            studObj.CourseId = viewObj.CourseId;

            if (ModelState.IsValid)
            {
                if (viewObj.StudentId == 0)
                {
                    repoObj.SaveStudent(studObj);
                    result = true;
                }
                else
                {
                    studObj.StudentId = viewObj.StudentId;
                    repoObj.UpdateStudent(studObj);
                    result = true;
                }
            }
            if (result)
            {
                return RedirectToAction("Index");
            }
            else
            {
                if (viewObj.StudentId == 0)
                {
                    CreateStudentViewModel obj = new CreateStudentViewModel();
                    obj.CoList = repoObj.GetCourses();
                    return View("Create", obj);
                }
                else
                {
                    CreateStudentViewModel obj = new CreateStudentViewModel();
                    obj.CoList = repoObj.GetCourses();
                    return View("Edit", obj);
                }
            }
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            Student studObj = repoObj.GetStudentById(id);
            CreateStudentViewModel viewObj = new CreateStudentViewModel();
            viewObj.StudentId = studObj.StudentId;
            viewObj.StudentName = studObj.StudentName;
            viewObj.Email = studObj.Email;
            viewObj.DateOfBirth = studObj.DateOfBirth;
            viewObj.IsSitAvailable = studObj.IsSitAvailable;
            viewObj.CourseFee = studObj.CourseFee;
            viewObj.ImageName = studObj.ImageName;
            viewObj.ImageUrl = studObj.ImageUrl;
            viewObj.CourseId = studObj.CourseId;
            viewObj.CoList = repoObj.GetCourses();
            return View(viewObj);
        }
        [HttpGet]
        public ActionResult Delete(int id)
        {
            Student studObj = repoObj.GetStudentById(id);
            CreateStudentViewModel viewObj = new CreateStudentViewModel();
            viewObj.StudentId = studObj.StudentId;
            viewObj.StudentName = studObj.StudentName;
            viewObj.Email = studObj.Email;
            viewObj.DateOfBirth = studObj.DateOfBirth;
            viewObj.IsSitAvailable = studObj.IsSitAvailable;
            viewObj.CourseFee = studObj.CourseFee;
            viewObj.ImageName = studObj.ImageName;
            viewObj.ImageUrl = studObj.ImageUrl;
            viewObj.CourseId = studObj.CourseId;
            return View(viewObj);
        }
        [ActionName("Delete")]
        public ActionResult DeleteConfirm(int id)
        {
            Student studObj = repoObj.GetStudentById(id);
            if (studObj != null)
            {
                repoObj.DeleteStudent(studObj.StudentId);
                return RedirectToAction("Index");
            }
            return View();
        }

        public PartialViewResult Details(int StudentId)
        {
            Student studObj = repoObj.GetStudentById(StudentId);
            StudentListViewModel viewObj = new StudentListViewModel();
            viewObj.StudentId = studObj.StudentId;
            viewObj.StudentName = studObj.StudentName;
            viewObj.Email = studObj.Email;
            viewObj.DateOfBirth = studObj.DateOfBirth;
            viewObj.IsSitAvailable = studObj.IsSitAvailable;
            viewObj.CourseFee = studObj.CourseFee;
            viewObj.ImageName = studObj.ImageName;
            viewObj.ImageUrl = studObj.ImageUrl;
            viewObj.CourseId = studObj.CourseId;     
           
            return PartialView("_DetailsRecord", viewObj);
        }

        public ActionResult ShowStudentList()
        {
            return View();
        }
        public PartialViewResult StudentList()
        {
            Thread.Sleep(1000);
            List<StudentListViewModel> studList = repoObj.GetStudents();
            return PartialView("_StudentList", studList);
        }
        public PartialViewResult StudentListDesc()
        {
            Thread.Sleep(1000);
            List<StudentListViewModel> studList = repoObj.GetStudents();
            return PartialView("_StudentList", studList.OrderByDescending(p => p.StudentName));
        }
        public PartialViewResult StudentListAsc()
        {
            Thread.Sleep(1000);
            List<StudentListViewModel> studList = repoObj.GetStudents();
            return PartialView("_StudentList", studList.OrderBy(p => p.StudentName));
        }
    }
}