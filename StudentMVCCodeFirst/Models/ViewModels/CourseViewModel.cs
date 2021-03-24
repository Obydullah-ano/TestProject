﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentMVCCodeFirst.Models.ViewModels
{
    public class CourseViewModel
    {
        public int Id { get; set; }
        public string CourseName { get; set; }
        public bool IsDeleted { get; set; }

        public virtual ICollection<Student> Students { get; set; }
    }
}