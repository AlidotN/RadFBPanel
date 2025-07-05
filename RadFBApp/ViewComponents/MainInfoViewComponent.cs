using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RadFBApp.Models;
using RadFBApp.Models.Data;
using RadFBApp.Models.ViewModels.Admin;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.ViewComponents
{
    public class MainInfoViewComponent : ViewComponent
    {
        private readonly UserManager<ApplicationUser> UserManager;

        public MainInfoViewComponent(UserManager<ApplicationUser> _UserManager)
        {
            UserManager = _UserManager;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            VmMainInfo data = new VmMainInfo();
            if (User.Identity.IsAuthenticated)
            {
                string UserName = User.Identity.Name;
                List<ApplicationUser> users = await UserManager.Users.ToListAsync();
                var CurrentUser = (from i in users where i.UserName == UserName select i).FirstOrDefault();
                if (CurrentUser != null)
                {
                    data.UserPic = CurrentUser.UserPic;
                    data.FullName = CurrentUser.FullName;
                }
            }
            return View(data);
        }
    }
}
