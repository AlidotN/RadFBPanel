using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace radFB.Controllers
{
    [Authorize]
    public class reportsController : Controller
    {
        radFB.Repository.repReports rep = new Repository.repReports();

        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.reportMenu(User.Identity.Name) != true)
            {
                roleID = false;
            }

            return roleID;
        }
        // vaziat mali
        public IActionResult finance()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.financeList();
            ViewBag.packages = rep.packageCount();
            ViewBag.Purchases = rep.TotalPurchases();
            ViewBag.users = rep.userPackagesCount();
            ViewBag.count = q.Count;
            return View(q);
        }


        //gozaresh karbar
        public IActionResult userReports()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        // <!--bookCount,articleCount,questinierCount,questinierAnswerCount,questionCount,posterParticipateCount-->
        [HttpPost]
        public IActionResult userReports(string name, int postCount, int questionAnswer, int advAnswer, int advCount,bool lastLogin, int bookCount, int articleCount, int questinierCount, int questinierAnswerCount, int questionCount, int posterParticipateCount)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.UserSearch(name, postCount, questionAnswer, advAnswer, advCount,bookCount,articleCount,questinierCount,questinierAnswerCount,questionCount,posterParticipateCount, lastLogin);
            if (q.Count > 0)
            {
                ViewBag.userList = q.ToList();
                ViewBag.count = q.Count;
            }
            else
            {
                TempData["notFound"] = "نتیجه ای یافت نشد";
            }
            return View();
        }

        //gozaresh mali
        public IActionResult financeReports()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult financeReports(string name, string price, string d1, string d2)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.financeSearch(name, price, d1, d2);
            if (q.Count > 0)
            {
                ViewBag.list = q;
                ViewBag.count = q.Count;
            }
            else
            {
                TempData["notFound"] = "نتیجه ای یافت نشد";
            }
           
            return View();
        }
    }
}
