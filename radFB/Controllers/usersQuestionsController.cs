using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace radFB.Controllers
{
    [Authorize]
    public class usersQuestionsController : Controller
    {
        Repository.repUsersQuestion rep = new Repository.repUsersQuestion();


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
            ViewBag.count = rep.UserQuestionList().Count;
            return View(rep.UserQuestionList());
        }

        public IActionResult showDetail(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
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
                    TempData["successAdd"] = "ثبت با موفقیت انجام شد";
                    return RedirectToAction("showDetail" , new { id = ID } );
                }
               
            }
            else
            {
                TempData["failedAdd"] = "عملیات ثبت با شکست مواجه شد";
                return RedirectToAction("showDetail" , new { id = ID });
            }

        }



        public IActionResult DeleteAnswer(long ID)
        {
            int st = rep.DeleteAnswer(ID);
            if (st == 1)
            {
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            return RedirectToAction("showDetail",new {id = ID });
        }

        public IActionResult DeleteUserQuestion(long id)
        {
            int st = rep.DelUserQuestion(id);
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


        public IActionResult DeleteAllUserQuestion(string deleteItems)
        {
            int st = rep.DelAllUserQuestion(deleteItems);
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
    }
}
