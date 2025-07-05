using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Models.Data;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;
using Microsoft.AspNetCore.Authorization;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class notificationController : Controller
    {
        readonly repNotification rep = new repNotification();

        public IActionResult Index()
        {
            ViewBag.count = rep.DialogList().Count;
            return View(rep.DialogList());

        }


        [HttpGet]
        public IActionResult AddDialog()
        {         
            return View();
        }

        [HttpPost]
        public IActionResult AddDialog(Tbl_dialog model)
        {

            int st = rep.AddDialog(model);
            if (st == 1)
            {
                TempData["successAdd"] = Texts.SubmitedSuccess;
                return RedirectToAction("Index");
            }
            else
            {
                TempData["failedAdd"] = Texts.SubmitFailed;
                return View();
            }

        }


       


        public IActionResult DeleteDialog(long id)
        {
            int st = rep.Deldialog(id);
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


        public IActionResult DeleteAllDialogs(string deleteItems)
        {
            int st = rep.DelAlldialog(deleteItems);
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
