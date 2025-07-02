using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmAdminPanelUsers 
    {
        [Display(Name = "نام کاربری")]
        public string email { get; set; }

        [Display(Name = "رمز عبور")]
        public string password { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }

        [Display(Name = "عکس")]
        public IFormFile UserPic { get; set; }

        [Display(Name = "سطح دسترسی")]
        public int Fk_userAccessID { get; set; }

        
    }
}
