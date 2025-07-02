using RadFBApp.Models.Data;
using RadFBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace RadFBApp.Areas.Panel.Repository
{
    public class RepAdmin
    {
        readonly ApplicationDbContext database = new ApplicationDbContext();
        public readonly UserManager<ApplicationUser> userManager;

        public RepAdmin(UserManager<ApplicationUser> _userManager)
        {
            this.userManager = _userManager;
        }

        public string AdminName(string email)
        {
            string name = "";
            List<ApplicationUser> users = new List<ApplicationUser>();
            var q = (from i in users where i.Email == email select i).SingleOrDefault();
            if (q != null)
            {
                name = q.FullName;
            }
            return name;
        }


    }
}
