using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using radFB.db;

namespace radFB.Controllers
{
    [Authorize]
    public class permiumController : Controller
    {
        Repository.repPermium rep = new Repository.repPermium();
       ApplicationDbContext db = new ApplicationDbContext();

        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.settingMenu(User.Identity.Name) != true)
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
            ViewBag.count = rep.permiumList().Count;
            return View(rep.permiumList());
        }

        [HttpGet]
        public IActionResult AddPermium()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.options = new SelectList(db.Tbl_setting, "settingID", "prSettingTitle");
            return View();
        }

        [HttpPost]
        public IActionResult AddPermium(Tbl_permiumPackage model)
        {

            var q = rep.Addpermium(model);
            if (q == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        public IActionResult EditPermium(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }

            Tbl_permiumPackage q = rep.permium(id);

            ViewBag.options = new SelectList(db.Tbl_permiumPackage.Where(c => c.DeleteStatus == false), "settingID", "prSettingTitle", q.permiumPackageID);

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
        public IActionResult EditPermium(long id, Tbl_permiumPackage model)
        {

            var q = rep.editpermium(id, model);
            if (q == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }


        public IActionResult DeletePermium(long id)
        {
            int st = rep.Delpermium(id);
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


        public IActionResult DeleteAllPermium(string deleteItems)
        {
            int st = rep.DelAllpermium(deleteItems);
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
