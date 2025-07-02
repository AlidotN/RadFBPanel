using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class subjectController : Controller
    {
        readonly ApplicationDbContext database = new ApplicationDbContext();

        public IActionResult Index()
        {
            var q = (from i in database.Tbl_subject select i).ToList();
            return View(q);
        }



        [HttpPost]
        public IActionResult Addsubject(string Prsubject, string Ensubject)
        {
            if (Prsubject != "" && Ensubject != "" && Prsubject != null && Ensubject != null)
            {
                database.Tbl_subject.Add(new Tbl_subject
                {
                    FaTitle = Prsubject,
                    EnTitle = Ensubject,
                });
                database.SaveChanges();
                TempData["successAdd"] = Texts.SubmitedSuccess;
            }
            else
            {
                TempData["failedAdd"] = Texts.SearchFrom;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editsubject(int? id)
        {
            var q = (from i in database.Tbl_subject where i.subjectID == id select i).FirstOrDefault();

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
        public IActionResult Editsubject(int? id, Tbl_subject model)
        {
            if (id != model.subjectID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var q = (from i in database.Tbl_subject where i.subjectID == id select i).FirstOrDefault();
                if (q != null)
                {
                    q.FaTitle = model.FaTitle;
                    q.EnTitle = model.EnTitle;
                    database.Tbl_subject.Update(q);
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



        public IActionResult Deletesubject(int? id)
        {
            var q = (from i in database.Tbl_subject where i.subjectID == id select i).SingleOrDefault();
            if (q != null)
            {
                database.Tbl_subject.Remove(q);
                database.SaveChanges();
                TempData["seccessDelete"] = Texts.DeleteSuccess;


            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }




        public IActionResult DeleteAllsubject(string deleteItems)
        {
            try
            {

                string strValue = deleteItems;
                string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var obj in strArray)
                {
                    var q = (from i in database.Tbl_subject where i.subjectID == long.Parse(obj) select i).SingleOrDefault();
                    //your delete query
                    database.Tbl_subject.Remove(q);
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
