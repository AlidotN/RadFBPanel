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
using Microsoft.AspNetCore.Authorization;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class frequentlyController : Controller
    {
        RepFrequently rep = new RepFrequently();
        ApplicationDbContext db = new ApplicationDbContext();

        public IActionResult Index()
        {
            var data = rep.FrequentlyList();
            ViewBag.count = data.Count;
            return View(data);
        }


        [HttpGet]
        public IActionResult AddFrequently()
        {
            

            ViewBag.Frequently = new SelectList(db.Tbl_FrequentlyAskedQuestionsSubject.Where(c => c.DeleteStatus == false), "FrequentlyAskedQuestionsSubjectID", "FaTitle");
            return View();
        }

        [HttpPost]
        public IActionResult AddFrequently(Tbl_FrequentlyAskedQuestions model)
        {

            int st = rep.AddFrequently( model);
            if (st == 1)
            {
                TempData["prQuestion"] = "";
                TempData["prAnswer"] = "";
                TempData["successAdd"] = Texts.SubmitedSuccess;
                return RedirectToAction("Index");

            }
            else
            {
                TempData["prQuestion"] = "";
                TempData["prAnswer"] = "";
                TempData["failedAdd"] = Texts.SubmitFailed;
                return View();
            }

        }


        [HttpGet]
        public IActionResult EditFrequently(long? id)
        {
            var q = (from i in db.Tbl_FrequentlyAskedQuestions where i.FrequentlyAskedQuestionsID == id select i).SingleOrDefault();
            //var q = rep.Frequently(id);

            if (q != null)
            {
                ViewBag.Frequently = new SelectList(db.Tbl_FrequentlyAskedQuestionsSubject.Where(c => c.DeleteStatus == false), "FrequentlyAskedQuestionsSubjectID", "FaTitle", q.fk_SubjectID);
                return View(q);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult EditFrequently(long id, Tbl_FrequentlyAskedQuestions model)
        {

            int st = rep.editFrequently(id, model);
            if (st == 1)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var q = rep.Frequently(id);
                return View(q);
            }

        }

        public IActionResult DeleteFrequently(long id)
        {
            int st = rep.DelFrequently(id);
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


        public IActionResult DeleteAllFrequently(string deleteItems)
        {
            int st = rep.DelAllFrequently(deleteItems);
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

        [HttpPost]
        public JsonResult EditStatus(long? id)
        {
            bool result;
            int st = rep.editSt(id);
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
    }
}
