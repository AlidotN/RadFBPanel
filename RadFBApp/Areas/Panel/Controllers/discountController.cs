using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class discountController : Controller
    {

        repDiscount rep = new repDiscount();


        public IActionResult Index()
        {
            ViewBag.count = rep.discountList().Count;
            return View(rep.discountList());
        }

        [HttpGet]
        public IActionResult AddDiscount()
        {
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllDiscount(string deleteItems)
        {
            int st = rep.DelAlldiscounts(deleteItems);
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


        [HttpGet]
        public IActionResult searchDiscount()
        {
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
