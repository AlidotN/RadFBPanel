using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class reportsController : Controller
    {
        readonly repReports rep = new repReports();

        // vaziat mali
        public IActionResult finance()
        {
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
            return View();
        }

        // <!--bookCount,articleCount,questinierCount,questinierAnswerCount,questionCount,posterParticipateCount-->
        [HttpPost]
        public IActionResult userReports(string name, int postCount, int questionAnswer, int advAnswer, int advCount,bool lastLogin, int bookCount, int articleCount, int questinierCount, int questinierAnswerCount, int questionCount, int posterParticipateCount)
        {
            var q = rep.UserSearch(name, postCount, questionAnswer, advAnswer, advCount,bookCount,articleCount,questinierCount,questinierAnswerCount,questionCount,posterParticipateCount, lastLogin);
            if (q.Count > 0)
            {
                ViewBag.userList = q.ToList();
                ViewBag.count = q.Count;
            }
            else
            {
                TempData["notFound"] = Texts.NotFound;
            }
            return View();
        }

        //gozaresh mali
        public IActionResult financeReports()
        {
            return View();
        }

        [HttpPost]
        public IActionResult financeReports(string name, string price, string d1, string d2)
        {
            var q = rep.financeSearch(name, price, d1, d2);
            if (q.Count > 0)
            {
                ViewBag.list = q;
                ViewBag.count = q.Count;
            }
            else
            {
                TempData["notFound"] = Texts.NotFound;
            }
           
            return View();
        }
    }
}
