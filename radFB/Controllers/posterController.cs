using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using radFB.Repository;
using radFB.ViewModels;

namespace radFB.Controllers
{
    [Authorize]
    public class posterController : Controller
    {
        repPoster rep = new repPoster();

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
            var q = rep.PosterList();
            ViewBag.count = q.Count;
            return View(q);
        }


        [HttpGet]
        public IActionResult showPoster(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            if (rep.poster(id) != null)
            {
                return View(rep.poster(id));
            }
            else
            {
                return NotFound();
            }

        }


        [HttpGet]
        public IActionResult searchPoster()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult searchPoster(VmSearchPoster model)
        {
            var q = rep.searchResult(model);
            if (q != null)
            {
                ViewBag.list = q;
                ViewBag.count = q.Count;
            }
            else
            {
                TempData["notFound"] = "موردی یافت نشد";
            }
          
            return View();
            
            
        }




        [HttpPost]
        public IActionResult EditPoster(long posterID, bool posterStatus)
        {
            var q = rep.poster(posterID);
            if (q != null)
            {
                if (rep.edit(posterID, posterStatus) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["faield"] = "عملیات ویرایش با شکست مواجه شد";
                    return RedirectToAction("showPoster", new { id = posterID });
                }
               
            }
            else
            {
                return NotFound();
            }
        }


        public IActionResult DeletePoster(long posterID)
        {
            int st = rep.DelPoster(posterID);
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


        public IActionResult DeleteAllPoster(string deleteItems)
        {
            int st = rep.DelAllPosters(deleteItems);
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



        [HttpPost]
        public JsonResult Edit(long id)
        {
            bool result;
            int st = rep.edit(id);
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


        public IActionResult search()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

       
    }
}
