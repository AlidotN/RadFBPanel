using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using radFB.db;

namespace radFB.Controllers
{
    [Authorize]
    public class notificationController : Controller
    {
        Repository.repNotification rep = new Repository.repNotification();
        ApplicationDbContext db = new ApplicationDbContext();


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
            ViewBag.count = rep.DialogList().Count;
            return View(rep.DialogList());

        }


        [HttpGet]
        public IActionResult AddDialog()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddDialog(Tbl_dialog model)
        {

            int st = rep.AddDialog(model);
            if (st == 1)
            {
                TempData["successAdd"] = "ثبت با موفقیت انجام شد";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["failedAdd"] = "عملیات ثبت با شکست مواجه شد";
                return View();
            }

        }


       


        public IActionResult DeleteDialog(long id)
        {
            int st = rep.Deldialog(id);
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


        public IActionResult DeleteAllDialogs(string deleteItems)
        {
            int st = rep.DelAlldialog(deleteItems);
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
