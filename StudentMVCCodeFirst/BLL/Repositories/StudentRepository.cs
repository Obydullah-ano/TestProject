using StudentMVCCodeFirst.BLL.Interfaces;
using StudentMVCCodeFirst.Models;
using StudentMVCCodeFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace StudentMVCCodeFirst.BLL.Repositories
{
    public class StudentRepository
    {
        SchoolManagementContext db = new SchoolManagementContext();
        public List<StudentListViewModel> GetStudents()
        {
            List<StudentListViewModel> viewlist = new List<StudentListViewModel>();
            List<Student> list = db.Students.ToList();
            viewlist = db.Students.Select(p => new StudentListViewModel
            {
                StudentId = p.StudentId,
                StudentName = p.StudentName,
                Email = p.Email,
                DateOfBirth = p.DateOfBirth,
                IsSitAvailable = p.IsSitAvailable,
                CourseFee = p.CourseFee,
                ImageName = p.ImageName,
                ImageUrl = p.ImageUrl,
                CourseName = p.Course.CourseName,
                CourseId = p.CourseId,
                PageTitle = "Student List"

            }).ToList();
            return viewlist;
        }
        public void SaveStudent(Student obj)
        {
            db.Students.Add(obj);
            db.SaveChanges();
        }
        public Student GetStudentById(int id)
        {
            Student obj = db.Students.SingleOrDefault(p => p.StudentId == id);
            return obj;
        }
        public void UpdateStudent(Student obj)
        {
            db.Entry(obj).State = EntityState.Modified;
            db.SaveChanges();
        }
        public void DeleteStudent(int id)
        {
            Student delObj = GetStudentById(id);
            db.Students.Remove(delObj);
            db.SaveChanges();
        }
        public List<Course> GetCourses()
        {
            List<Course> coList = db.Courses.ToList();
            return coList;
        }
    }
}