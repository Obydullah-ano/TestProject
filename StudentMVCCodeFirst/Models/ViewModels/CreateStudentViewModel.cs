using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMVCCodeFirst.Models.ViewModels
{
    public class CreateStudentViewModel
    {
        public int StudentId { get; set; }
        [Required(ErrorMessage = "Student name Required")]
        [DataType(DataType.Text)]
        [Display(Name = "Student Name")]
        public string StudentName { get; set; }
        [Required(ErrorMessage = "Email address Required")]
        [Display(Name = "Email Address")]
        [RegularExpression("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9-]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$", ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Confirm email Required")]
        [Compare("Email", ErrorMessage = "Email address does not match")]
        [Display(Name = "Confirm Email")]
        public string ConfirmEmail { get; set; }
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:MM/dd/yyyy}")]
        [Display(Name = "Date Of Birth")]
        [Required(ErrorMessage = "Date time Required")]
        public System.DateTime DateOfBirth { get; set; }
        [Display(Name = "Sit Available is?")]
        public bool IsSitAvailable { get; set; }
        [Display(Name = "Course Fee")]
        [Range(maximum: (70000), minimum: (5000))]
        [Required(ErrorMessage = "Course Fee Required")]
        public decimal CourseFee { get; set; }
        //[Display(Name = "Image Name")]
        public string ImageName { get; set; }
        //[Display(Name = "Image")]
        public string ImageUrl { get; set; }
        [Display(Name = "Course Name")]
        [Required(ErrorMessage = "CourseName required")]
        public int CourseId { get; set; }
        public string PageTitle { get; set; }
        //[Required(ErrorMessage = "CourseName Required")]
        public string CourseName { get; set; }

        //public IQueryable<Course> CoList { get; set; }
        public List<Course> CoList { get; set; }
        public HttpPostedFileBase ImageFile { get; set; }

        public Course Course { get; set; }
    }
}