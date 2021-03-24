using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMVCCodeFirst.Models.ViewModels
{
    public class StudentListViewModel
    {
        public int StudentId { get; set; }

        public string StudentName { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public Nullable<bool> IsSitAvailable { get; set; }
        public decimal CourseFee { get; set; }

        public string ImageName { get; set; }

        public string ImageUrl { get; set; }

        public int CourseId { get; set; }
        public string PageTitle { get; set; }
        public string CourseName { get; set; }

        public Course Course { get; set; }
    }
}