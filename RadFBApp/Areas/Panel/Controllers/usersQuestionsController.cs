using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class usersQuestionsController : Controller
    {
        readonly repUsersQuestion rep = new repUsersQuestion();

        public IActionResult Index()
        {
            ViewBag.count = rep.UserQuestionList().Count;
            return View(rep.UserQuestionList());
        }

        public IActionResult showDetail(long id)
        {
            if (rep.UserQuestion(id) != null)
            {
                return View(rep.UserQuestion(id));
            }
            else
            {
                return NotFound();
            }
           
        }

       
        [HttpPost]
        public IActionResult AddAnswer(long ID, string question,string answer,string admin,bool add)
        {

            int st = rep.AddAnswer(ID,answer,admin);
            if (st == 1)
            {
                if (add == true)
                {
                    TempData["prQuestion"] = question;
                    TempData["prAnswer"] = answer;
                    return RedirectToAction("AddFrequently", "frequently");
                }
                else
                {
                    TempData["successAdd"] = Texts.SubmitedSuccess;
                    return RedirectToAction("showDetail" , new { id = ID } );
                }
               
            }
            else
            {
                TempData["failedAdd"] = Texts.SubmitFailed;
                return RedirectToAction("showDetail" , new { id = ID });
            }

        }



        public IActionResult DeleteAnswer(long ID)
        {
            int st = rep.DeleteAnswer(ID);
            if (st == 1)
            {
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("showDetail",new {id = ID });
        }

        public IActionResult DeleteUserQuestion(long id)
        {
            int st = rep.DelUserQuestion(id);
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


        public IActionResult DeleteAllUserQuestion(string deleteItems)
        {
            int st = rep.DelAllUserQuestion(deleteItems);
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
