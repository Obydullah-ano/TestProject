using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMVCCodeFirst.Models
{
    public class Student
    {
        public int StudentId { get; set; }
        public string StudentName { get; set; }
        public string Email { get; set; }
        public System.DateTime DateOfBirth { get; set; }
        public bool IsSitAvailable { get; set; }
        public decimal CourseFee { get; set; }
        public string ImageName { get; set; }
        public string ImageUrl { get; set; }
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }
    }
}