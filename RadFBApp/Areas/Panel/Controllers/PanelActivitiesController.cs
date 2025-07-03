using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;
using RadFBApp.Models;
using RadFBApp.Models.Data;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    public class PanelActivitiesController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly RepPanelActivity rep;
        public PanelActivitiesController(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
            rep = new RepPanelActivity(userManager);
        }
        public IActionResult Index()
        {
            var data = rep.GetAll();
            return View(data);
        }

        public IActionResult DeleteActivity(int id)
        {
            var data = rep.DeleteActivity(id);
            if (data)
            { 
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAllActivities(string DeleteItems)
        {
            var data = rep.DeleteAllActivities(DeleteItems);
            if (data)
            {
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }
    }
}
