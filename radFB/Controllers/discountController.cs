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
    public class discountController : Controller
    {

        Repository.repDiscount rep = new Repository.repDiscount();

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
            ViewBag.count = rep.discountList().Count;
            return View(rep.discountList());
        }

        [HttpGet]
        public IActionResult AddDiscount()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddDiscount( Tbl_discount model)
        {

            var q = rep.Add( model);
            if (q != false)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }

        [HttpGet]
        public IActionResult EditDiscount(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }

            var q = rep.discount(id );
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
        public IActionResult EditDiscount(long id, Tbl_discount model)
        {

            var q = rep.edit(id, model);
            if (q != false)
            {
                return RedirectToAction("Index");
            }
            else
            {
                return NotFound();
            }

        }


        public IActionResult DeleteDiscount(long id)
        {
            int st = rep.DelDiscount(id);
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


        public IActionResult DeleteAllDiscount(string deleteItems)
        {
            int st = rep.DelAlldiscounts(deleteItems);
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


        [HttpGet]
        public IActionResult searchDiscount()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult searchDiscount(string title,int percent,string date)
        {
            var q = rep.searchResult(title, percent, date);
            ViewBag.count = q.Count;
            if (q.Count > 0)
            {
                return View(q);
            }
            else
            {
                return View();
            }
           
        }
    }
}
