using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMVCCodeFirst.Models
{
    public class tblRole
    {
        public int Id { get; set; }
        
        public string RoleName { get; set; }
        
        public int UserId { get; set; }
        public virtual tblUser tblUsers { get; set; }
    }
}