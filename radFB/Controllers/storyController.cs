using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using radFB.Repository;

namespace radFB.Controllers
{
    public class storyController : Controller
    {
        Repository.repStory rep = new Repository.repStory();
        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.postMenu(User.Identity.Name) != true)
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
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllstories(string deleteItems)
        {
            int st = rep.DelAllStories(deleteItems);
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


        public IActionResult search()
        {
            return View();
        }

        [HttpPost]
        public IActionResult search(string date1, string date2)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            if ((date1 != null && date1 != "") && (date2 != null && date2 != ""))
            {
                ViewBag.dt = " جستجو از " + "  " + date1 + " تا " + "  " + date2;
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
                        TempData["failed"] = "یافت نشد";
                        return View();
                    }
                }
                else
                {
                    TempData["failed"] = "تاریخ شروع از تاریخ پایان بزرگ تر است";
                    return View();
                }

            }
            else
            {
                TempData["failed"] = "لطفا فیلد های جستجو را کامل کنید";
                return View();
            }

        }
    }
}
