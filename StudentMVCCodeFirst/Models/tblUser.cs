using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace StudentMVCCodeFirst.Models
{
    public class tblUser
    {
        public tblUser()
        {
            this.tblRoles = new HashSet<tblRole>();
        }
        public int Id { get; set; }
        [Display(Name = "Enter Your User Name")]
        [DataType(DataType.EmailAddress)]
        public string UserName { get; set; }
        [Display(Name = "Enter Your Password")]
        [DataType(DataType.Password)]
        public string UserPassword { get; set; }
        public string FullName { get; set; }
        public virtual ICollection<tblRole> tblRoles { get; set; }
    }
}