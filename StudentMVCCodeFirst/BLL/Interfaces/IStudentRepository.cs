using StudentMVCCodeFirst.Models;
using StudentMVCCodeFirst.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMVCCodeFirst.BLL.Interfaces
{
    public interface IStudentRepository
    {
        List<StudentListViewModel> GetStudents();
        Student GetStudentById(int id);
        void SaveStudent(Student obj);
        void UpdateStudent(Student obj);
        void DeleteStudent(int id);

        List<Course> GetCourses();
    }
}