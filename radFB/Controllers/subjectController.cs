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
    public class subjectController : Controller
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
            var q = (from i in database.Tbl_subject select i).OrderByDescending(c=>c.subjectID).ToList();
            return View(q);
        }



        [HttpPost]
        public IActionResult Addsubject(string Prsubject, string Ensubject)
        {

            if (Prsubject != "" && Ensubject != "" && Prsubject != null && Ensubject != null)
            {
                database.Tbl_subject.Add(new Tbl_subject
                {
                    FaTitle = Prsubject,
                    EnTitle = Ensubject,
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
        public IActionResult Editsubject(int? id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = (from i in database.Tbl_subject where i.subjectID == id select i).FirstOrDefault();

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
        public IActionResult Editsubject(int? id, Tbl_subject model)
        {
            if (id != model.subjectID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var q = (from i in database.Tbl_subject where i.subjectID == id select i).FirstOrDefault();
                if (q != null)
                {
                    q.FaTitle = model.FaTitle;
                    q.EnTitle = model.EnTitle;
                    database.Tbl_subject.Update(q);
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



        public IActionResult Deletesubject(int? id)
        {
            var q = (from i in database.Tbl_subject where i.subjectID == id select i).SingleOrDefault();
            if (q != null)
            {
                database.Tbl_subject.Remove(q);
                database.SaveChanges();
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";


            }
            else
            {
                TempData["FailedDelete"] = "حذف ناموفق";
            }
            return RedirectToAction("Index");
        }




        public IActionResult DeleteAllsubject(string deleteItems)
        {
            try
            {

                string strValue = deleteItems;
                string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var obj in strArray)
                {
                    var q = (from i in database.Tbl_subject where i.subjectID == long.Parse(obj) select i).SingleOrDefault();
                    //your delete query
                    database.Tbl_subject.Remove(q);
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
