using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class suggestionController : Controller
    {
        readonly repSuggestion rep = new repSuggestion();


        public IActionResult Index()
        {
            ViewBag.count = rep.SuggestionList().Count;
            return View(rep.SuggestionList());
        }

        public IActionResult showDetail(long id)
        {
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllSuggestions(string deleteItems)
        {
            int st = rep.DelAllSuggestions(deleteItems);
            if (st == 1)
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
