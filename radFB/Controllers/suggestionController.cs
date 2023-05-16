using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace radFB.Controllers
{
    [Authorize]
    public class suggestionController : Controller
    {
        Repository.repSuggestion rep = new Repository.repSuggestion();

        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.connectUserMenu(User.Identity.Name) != true)
            {
                roleID = false;
            }

            return roleID;
        }
        public IActionResult Index()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.count = rep.SuggestionList().Count;
            return View(rep.SuggestionList());
        }

        public IActionResult showDetail(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            rep.suggestionReading(id);
            var q = rep.suggestion(id);
            if (q != null)
            {
                return View(q);
            }
            else
            {
                return NotFound();
            }
            
        }


        public IActionResult DeleteSuggestion(long id)
        {
            int st = rep.DelSuggestion(id);
            if (st == 1)
            {
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllSuggestions(string deleteItems)
        {
            int st = rep.DelAllSuggestions(deleteItems);
            if (st == 1)
            {
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            return RedirectToAction("Index");
        }

    }
}
