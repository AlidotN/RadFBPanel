using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class permiumController : Controller
    {
       readonly repPermium rep = new repPermium();
       readonly ApplicationDbContext db = new ApplicationDbContext();


        public IActionResult Index()
        {
            ViewBag.count = rep.permiumList().Count;
            return View(rep.permiumList());
        }

        [HttpGet]
        public IActionResult AddPermium()
        {
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllPermium(string deleteItems)
        {
            int st = rep.DelAllpermium(deleteItems);
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
