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
    public class PostController : Controller
    {
    

        private repPost rep;
        public PostController(repPost repository)
        {
            // [1]
            rep = repository;
        }

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

            ViewBag.count = rep.postList().Count;
            return View(rep.postList());
        }

        [HttpGet]
        public IActionResult EditPost(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
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
                    TempData["faield"] = "عملیات ویرایش با شکست مواجه شد";
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
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllPost(string deleteItems)
        {
            int st = rep.DelAllPosts(deleteItems);
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
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
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
    }
}
