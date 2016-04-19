using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.AccessControl;
using System.Web;

namespace Authentication_Practice.Models
{
    public class InfoVM
    {
        [Display(Name = "First Name")]
        public string FirstName { get; set; }
        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        [Display(Name = "E-mail Address")]
        public string Email { get; set; }
        [Display(Name = "Date of Birth")]
        public string DOB { get; set; }
    }
}