using StudentMVCCodeFirst.BLL.Interfaces;
using StudentMVCCodeFirst.Models;
using StudentMVCCodeFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMVCCodeFirst.BLL.Repositories
{
    public class CourseRepository
    {
        //SchoolManagementContext db = new SchoolManagementContext();

        //public void DeleteCourse(int id)
        //{
        //    Course delObj = GetCourseById(id);
        //    db.Courses.Remove(delObj);
        //    db.SaveChanges();
        //}

        //public Course GetCourseById(int id)
        //{
        //    Course obj = db.Courses.SingleOrDefault(p => p.Id == id);
        //    return obj;
        //}

        //public List<CourseViewModel> GetCourses()
        //{
        //    List<CourseViewModel> viewlist = new List<CourseViewModel>();
        //    List<Course> list = db.Courses.ToList();
        //    viewlist = db.Courses.Select(p => new CourseViewModel
        //    {
        //        Id = p.Id,
        //        CourseName = p.CourseName

        //    }).ToList();
        //    return viewlist;
        //}
        //public List<Course> GetCourses()
        //{
        //    List<CreateCourseViewModel> viewClist = new List<CreateCourseViewModel>();
        //    List<Course> list = db.Courses.ToList();
        //    viewClist = db.Courses.Select(p => new CreateCourseViewModel
        //    {
        //        Id = p.Id,
        //        CourseName = p.CourseName,

        //    }).ToList();
        //    return list;
        //}

    }
}