using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.ViewModels
{
    public class VmUserList
    {
        [Display(Name = "کد")]
        public string id { get; set; }

        [Display(Name = "نام کاربری")]
        public string email { get; set; }

        [Display(Name = "نام و نام خانوادگی")]
        public string FullName { get; set; }

        [Display(Name = "شماره موبایل")]
        public string PhoneNumber { get; set; }

        [Display(Name = "عکس")]
        public string UserPic { get; set; }

        [Display(Name = "سطح دسترسی")]
        public string accessName { get; set; }

       

    }
}
