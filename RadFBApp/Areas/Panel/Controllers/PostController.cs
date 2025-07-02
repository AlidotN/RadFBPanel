using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;
using RadFBApp.Models.ViewModels.Admin;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class PostController : Controller
    {


        private repPost rep;
        public PostController(repPost repository)
        {
            // [1]
            rep = repository;
        }


        public IActionResult Index()
        {
           
            
            ViewBag.count = rep.postList().Count;
            return View(rep.postList());
        }

        [HttpGet]
        public IActionResult EditPost(long id)
        {
            if (rep.post(id) != null)
            {
                return View(rep.post(id));
            }
            else
            {
                return NotFound();
            }
           
        }

        [HttpPost]
        public IActionResult EditPost(long id,VmPost model)
        {
            var q = rep.post(id);
            if (q != null)
            {
                if (rep.edit(id,model) == true)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["faield"] = Texts.EditFaild;
                }
                return View(q);
            }
            else
            {
                return NotFound();
            }
        }

        public IActionResult DeletePost(long id)
        {
            int st = rep.DelPost(id);
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


        public IActionResult DeleteAllPost(string deleteItems)
        {
            int st = rep.DelAllPosts(deleteItems);
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
        public IActionResult search(string date1,string date2)
        {
            if ((date1 != null && date1 !="" )&& (date2 != null && date2 != "" ))
            {
                ViewBag.dt = " جستجو از "+ "  "+ date1 +" تا " +"  " + date2;
                var q = rep.searchResult(date1, date2);
                if ( q != null)
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
