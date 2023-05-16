using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using radFB.db;

namespace radFB.Controllers
{
    [Authorize]
    public class frequentlySubjectController : Controller
    {
        ApplicationDbContext database = new ApplicationDbContext();

        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.settingMenu(User.Identity.Name) != true)
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
            var q = database.Tbl_FrequentlyAskedQuestionsSubject.ToList().Where(c => c.DeleteStatus == false).OrderByDescending(c=>c.FrequentlyAskedQuestionsSubjectID).ToList();
            TempData["count"] = q.Count;
            return View(q.ToList());
        }

        [HttpGet]
        public IActionResult AddFrequentlySubject()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
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
                TempData["successAdd"] = "ثبت با موفقیت انجام شد";
            }
            else
            {
                TempData["failedAdd"] = "عملیات ثبت با شکست مواجه شد";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditFrequentlySubject(int? id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
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
                TempData["failedEdit"] = "عملیات ویرایش با شکست مواجه شد";
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
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";


            }
            else
            {
                TempData["FailedDelete"] = "حذف ناموفق";
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
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            catch (Exception)
            {

                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }


            return RedirectToAction("Index");
        }
    }
}
