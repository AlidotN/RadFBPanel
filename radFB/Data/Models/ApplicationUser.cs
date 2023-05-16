
using Microsoft.AspNetCore.Identity;
using radFB.db;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace radFB.Models
{
    public class ApplicationUser : IdentityUser
    {

     


        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "عکس")]
        public string UserPic { get; set; }

        [Display(Name = "سطح دسترسی")]
        public int Fk_userAccessID { get; set; }

        public bool DeleteStatus { get; set; }



        
        public virtual Tbl_userAccess Tbl_userAccess { get; set; }


    }
}
