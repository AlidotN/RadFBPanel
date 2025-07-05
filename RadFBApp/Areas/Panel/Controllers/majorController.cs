using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Areas.Panel.Resources;
using Microsoft.AspNetCore.Authorization;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class majorController : Controller
    {
        readonly ApplicationDbContext database = new ApplicationDbContext();

        public IActionResult Index()
        {
            var q = (from i in database.Tbl_major select i).ToList();
            return View(q);
        }



        [HttpPost]
        public IActionResult Addmajor(string Prmajor, string Enmajor)
        {
            if (Prmajor != "" && Enmajor != "" && Prmajor != null && Enmajor != null)
            {
                database.Tbl_major.Add(new Tbl_major
                {
                    PrMajorTitle = Prmajor,
                    EnMajorTitle = Enmajor,
                });
                database.SaveChanges();
                TempData["successAdd"] = Texts.SubmitedSuccess;
            }
            else
            {
                TempData["failedAdd"] = Texts.SubmitFailed;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editmajor(int? id)
        {
            var q = (from i in database.Tbl_major where i.majorID == id select i).FirstOrDefault();

            if (q != null)
            {
                return View(q);
            }
            else
            {
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult Editmajor(int? id, Tbl_major model)
        {
            if (id != model.majorID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var q = (from i in database.Tbl_major where i.majorID == id select i).FirstOrDefault();
                if (q != null)
                {
                    q.PrMajorTitle = model.PrMajorTitle;
                    q.EnMajorTitle = model.EnMajorTitle;
                    database.Tbl_major.Update(q);
                    database.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }

            }

            else
            {
                TempData["failedEdit"] = Texts.EditFaild;
                return View();
            }

        }



        public IActionResult Deletemajor(int? id)
        {
            var q = (from i in database.Tbl_major where i.majorID == id select i).SingleOrDefault();
            if (q != null)
            {
                database.Tbl_major.Remove(q);
                database.SaveChanges();
                TempData["seccessDelete"] = Texts.DeleteSuccess;


            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }




        public IActionResult DeleteAllmajor(string deleteItems)
        {
            try
            {

                string strValue = deleteItems;
                string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var obj in strArray)
                {
                    var q = (from i in database.Tbl_major where i.majorID == long.Parse(obj) select i).SingleOrDefault();
                    //your delete query
                    database.Tbl_major.Remove(q);
                }
                database.SaveChanges();
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            catch (Exception)
            {

                TempData["FailedDelete"] = Texts.DeleteFaild;
            }


            return RedirectToAction("Index");
        }
    }
}
