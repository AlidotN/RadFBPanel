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
    public class frequentlyController : Controller
    {
        Repository.RepFrequently rep = new Repository.RepFrequently();
        ApplicationDbContext db = new ApplicationDbContext();

        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.frequentlyMenu(User.Identity.Name) != true)
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
            ViewBag.count = rep.FrequentlyList().Count;
            return View(rep.FrequentlyList());

        }


        [HttpGet]
        public IActionResult AddFrequently()
        {

            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.Frequently = new SelectList(db.Tbl_FrequentlyAskedQuestionsSubject.Where(c => c.DeleteStatus == false), "FrequentlyAskedQuestionsSubjectID", "FaTitle");
            return View();
        }

        [HttpPost]
        public IActionResult AddFrequently(Tbl_FrequentlyAskedQuestions model)
        {

            int st = rep.AddFrequently( model);
            if (st == 1)
            {
                TempData["prQuestion"] = null;
                TempData["prAnswer"] = null;
                TempData["successAdd"] = "ثبت با موفقیت انجام شد";
                return RedirectToAction("Index");

            }
            else
            {
                TempData["prQuestion"] = null;
                TempData["prAnswer"] = null;
                TempData["failedAdd"] = "عملیات ثبت با شکست مواجه شد";
                return View();
            }

        }


        [HttpGet]
        public IActionResult EditFrequently(long? id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }

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
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllFrequently(string deleteItems)
        {
            int st = rep.DelAllFrequently(deleteItems);
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
