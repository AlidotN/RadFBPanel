using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class storyController : Controller
    {
        readonly repStory rep = new repStory();

        public IActionResult Index()
        {
            ViewBag.count = rep.storyList().Count;
            return View(rep.storyList());
          
        }

        [HttpPost]
        public JsonResult EditStory(long id)
        {
            bool result;
            int st = rep.editStory(id);
            if (st == 1)
            {
                result = true;
            }
            else
            {
                result = false;
            }
            return new JsonResult(result);
        }

        public IActionResult DeleteStory(long id)
        {
            int st = rep.DelStory(id);
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


        public IActionResult DeleteAllstories(string deleteItems)
        {
            int st = rep.DelAllStories(deleteItems);
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


        public IActionResult search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult search(string date1, string date2)
        {
            if ((date1 != null && date1 != "") && (date2 != null && date2 != ""))
            {
                ViewBag.dt = Texts.SearchFrom + "  " + date1 + Texts.Till + "  " + date2;
                var q = rep.searchResult(date1, date2);
                if (q != null)
                {
                    if (q.Count > 0)
                    {
                        ViewBag.count = q.Count;
                        return View(q);
                    }
                    else
                    {
                        TempData["failed"] = Texts.NotFound;
                        return View();
                    }
                }
                else
                {
                    TempData["failed"] = Texts.StartAfterEnd;
                    return View();
                }

            }
            else
            {
                TempData["failed"] = Texts.FillSearchFields;
                return View();
            }

        }
    }
}
