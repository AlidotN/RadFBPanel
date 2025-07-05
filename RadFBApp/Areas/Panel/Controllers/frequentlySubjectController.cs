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
    public class frequentlySubjectController : Controller
    {
        ApplicationDbContext database = new ApplicationDbContext();

        public IActionResult Index()
        {
            var q = database.Tbl_FrequentlyAskedQuestionsSubject.ToList().Where(c => c.DeleteStatus == false).ToList();
            TempData["count"] = q.Count;
            return View(q.ToList());
        }

        [HttpGet]
        public IActionResult AddFrequentlySubject()
        {

            return PartialView();
        }

        [HttpPost]
        public IActionResult AddFrequentlySubject(string PrFrequentlySubjectTitle, string EnFrequentlySubjectTitle)
        {
            if (PrFrequentlySubjectTitle != "" && EnFrequentlySubjectTitle != "" && PrFrequentlySubjectTitle != null && EnFrequentlySubjectTitle != null)
            {
                database.Tbl_FrequentlyAskedQuestionsSubject.Add(new Tbl_FrequentlyAskedQuestionsSubject
                {
                    FaTitle = PrFrequentlySubjectTitle,
                    EnTitle = EnFrequentlySubjectTitle
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
        public IActionResult EditFrequentlySubject(int? id)
        {
            var q = (from i in database.Tbl_FrequentlyAskedQuestionsSubject where i.FrequentlyAskedQuestionsSubjectID == id select i).FirstOrDefault();
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
        public IActionResult EditFrequentlySubject(int? id, Tbl_FrequentlyAskedQuestionsSubject model)
        {
            if (id != model.FrequentlyAskedQuestionsSubjectID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var q = (from i in database.Tbl_FrequentlyAskedQuestionsSubject where i.FrequentlyAskedQuestionsSubjectID == id select i).FirstOrDefault();
                if (q != null)
                {
                    q.FaTitle = model.FaTitle;
                    q.EnTitle = model.EnTitle;
                    database.Tbl_FrequentlyAskedQuestionsSubject.Update(q);
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



        public IActionResult DeleteFrequentlySubject(int? id)
        {
            var q = (from i in database.Tbl_FrequentlyAskedQuestionsSubject where i.FrequentlyAskedQuestionsSubjectID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                database.Tbl_FrequentlyAskedQuestionsSubject.Update(q);
                database.SaveChanges();
                TempData["seccessDelete"] = Texts.DeleteSuccess;


            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllFrequentlySubject(string deleteItems)
        {
            try
            {

                string strValue = deleteItems;
                string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var obj in strArray)
                {
                    var fre = (from i in database.Tbl_FrequentlyAskedQuestionsSubject where i.FrequentlyAskedQuestionsSubjectID == long.Parse(obj) select i).SingleOrDefault();
                    //your delete query
                    fre.DeleteStatus = true;
                    database.Tbl_FrequentlyAskedQuestionsSubject.Update(fre);
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
