using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;
using RadFBApp.Models;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class questionController : Controller
    {
        readonly repQuestion rep = new repQuestion();
        readonly ApplicationDbContext database = new ApplicationDbContext();

        public IActionResult Index()
        {
            var q = rep.QuestionList();
            ViewBag.count = q.Count;
            return View(q);
        }

        [HttpGet]
        public IActionResult showDetail(long id)
        {
       
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("showDetail",new{ id = questionID });
        }


        public IActionResult DeleteQuestion(long id)
        {
            int st = rep.DelQuestion(id);
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


        public IActionResult DeleteAllQuestion(string deleteItems)
        {
            int st = rep.DelAllQuestions(deleteItems);
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
        public IActionResult search()
        {
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
