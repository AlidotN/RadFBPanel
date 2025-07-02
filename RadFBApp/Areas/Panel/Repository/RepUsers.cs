using RadFBApp.Models.Data;
using RadFBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RadFBApp.Areas.Panel.Repository
{
    public class RepUsers
    {
        readonly ApplicationDbContext database = new ApplicationDbContext();
        public readonly UserManager<ApplicationUser> userManager;

        public RepUsers(UserManager<ApplicationUser> _userManager)
        {
            this.userManager = _userManager;
        }

        public long getCount()
        {
            List<ApplicationUser> users = userManager.Users.ToList();
            int count = (from i in users select i).Count();
            return count;
        }

        public string getPic(string email)
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            string pic = (from i in users where i.Email == email select i.UserPic).ToString();
            return pic;
        }


    }
}
