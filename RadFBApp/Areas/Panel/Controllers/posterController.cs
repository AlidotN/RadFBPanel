using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;
using RadFBApp.Models.ViewModels.Admin;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class posterController : Controller
    {
        repPoster rep = new repPoster();

        public IActionResult Index()
        {
            var q = rep.PosterList();
            ViewBag.count = q.Count;
            return View(q);
        }


        [HttpGet]
        public IActionResult showPoster(long id)
        {
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
                TempData["notFound"] = Texts.NotFound;
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
                    TempData["faield"] = Texts.EditFaild;
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllPoster(string deleteItems)
        {
            int st = rep.DelAllPosters(deleteItems);
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

       
    }
}
