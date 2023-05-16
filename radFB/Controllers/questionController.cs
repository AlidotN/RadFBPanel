using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using radFB.Repository;

namespace radFB.Controllers
{
    [Authorize]
    public class questionController : Controller
    {
        repQuestion rep = new repQuestion();
        radFB.db.ApplicationDbContext database = new db.ApplicationDbContext();

        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.postMenu(User.Identity.Name) != true)
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
            var q = rep.QuestionList();
            ViewBag.count = q.Count;
            return View(q);
        }

        [HttpGet]
        public IActionResult showDetail(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.count = rep.showAnswers(id).Count;
            ViewBag.answers = (rep.showAnswers(id));
            var q = rep.Question(id);
            if (q != null)
            {
              
                return View(q);
            }
            else
            {
                return NotFound();
            }

        }


        public IActionResult DeleteAnswer(long id,long questionID)
        {
            int st = rep.DelAnswer(id);
            if (st == 1)
            {
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            return RedirectToAction("showDetail",new{ id = questionID });
        }


        public IActionResult DeleteQuestion(long id)
        {
            int st = rep.DelQuestion(id);
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


        public IActionResult DeleteAllQuestion(string deleteItems)
        {
            int st = rep.DelAllQuestions(deleteItems);
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
        public IActionResult search()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.subject = new SelectList(database.Tbl_subject, "subjectID", "FaTitle");
            ViewBag.category = new SelectList(database.Tbl_jobCategory, "jobCategoryID", "PrJobCategoryTitle");
            return View();
        }

        [HttpPost]
        public IActionResult search(string name, string txt, long subject, long category, int answerCount, string dt1, string dt2)
        {
            var q = rep.searchResult(name, txt, subject,category,answerCount,dt1,dt2);
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
