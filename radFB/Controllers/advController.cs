using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using radFB.ViewModels;

namespace radFB.Controllers
{
    [Authorize]
    public class advController : Controller
    {
        radFB.Repository.repAdv rep = new Repository.repAdv();

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
            var q = rep.advList();
            ViewBag.count = q.Count;
            return View(q);
        }

       
        public IActionResult showDetail(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.adv(id);
            if (q != null)
            {
                return View(q);
            }
            else
            {
                return NotFound();
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

        public IActionResult DeleteAdv(long id)
        {
            int st = rep.DelAdv(id);
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


        public IActionResult DeleteAllAdv(string deleteItems)
        {
            int st = rep.DelAllAdv(deleteItems);
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
