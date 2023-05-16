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
    public class majorController : Controller
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
            var q = (from i in database.Tbl_major select i).OrderByDescending(c=>c.majorID).ToList();
            return View(q);
        }



        [HttpPost]
        public IActionResult Addmajor(string Prmajor, string Enmajor)
        {
            if (Prmajor != "" && Enmajor != "" && Prmajor != null && Enmajor != null)
            {
                database.Tbl_major.Add(new Tbl_major
                {
                    PrMajorTitle = Prmajor,
                    EnMajorTitle = Enmajor,
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
        public IActionResult Editmajor(int? id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = (from i in database.Tbl_major where i.majorID == id select i).FirstOrDefault();

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
        public IActionResult Editmajor(int? id, Tbl_major model)
        {
            if (id != model.majorID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var q = (from i in database.Tbl_major where i.majorID == id select i).FirstOrDefault();
                if (q != null)
                {
                    q.PrMajorTitle = model.PrMajorTitle;
                    q.EnMajorTitle = model.EnMajorTitle;
                    database.Tbl_major.Update(q);
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



        public IActionResult Deletemajor(int? id)
        {
            var q = (from i in database.Tbl_major where i.majorID == id select i).SingleOrDefault();
            if (q != null)
            {
                database.Tbl_major.Remove(q);
                database.SaveChanges();
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";


            }
            else
            {
                TempData["FailedDelete"] = "حذف ناموفق";
            }
            return RedirectToAction("Index");
        }




        public IActionResult DeleteAllmajor(string deleteItems)
        {
            try
            {

                string strValue = deleteItems;
                string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var obj in strArray)
                {
                    var q = (from i in database.Tbl_major where i.majorID == long.Parse(obj) select i).SingleOrDefault();
                    //your delete query
                    database.Tbl_major.Remove(q);
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
