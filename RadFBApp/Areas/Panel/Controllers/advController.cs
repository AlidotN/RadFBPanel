using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Models.ViewModels.Admin;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class advController : Controller
    {
        repAdv rep = new repAdv();

        public IActionResult Index()
        {
            var q = rep.advList();
            ViewBag.count = q.Count;
            return View(q);
        }

       
        public IActionResult showDetail(long id)
        {

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
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllAdv(string deleteItems)
        {
            int st = rep.DelAllAdv(deleteItems);
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
