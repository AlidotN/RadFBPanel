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
    public class jobController : Controller
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
            ViewBag.Guids = new SelectList(database.Tbl_guild.Where(c => c.DeleteStatus == false), "guildID", "FAguildNAme");

            return View(database.Tbl_jobCategory.OrderByDescending(c=>c.jobCategoryID).ToList());
        }

        [HttpGet]
        public IActionResult AddJob()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.Guids = new SelectList(database.Tbl_guild.Where(c => c.DeleteStatus == false), "guildID", "FAguildNAme");

            return PartialView();
        }

        [HttpPost]
        public IActionResult AddJob(string PrJobCat, string EnJobCat ,long fk_guidID)
        {
            if (PrJobCat != "" && EnJobCat != "" && PrJobCat != null && EnJobCat != null)
            {
                database.Tbl_jobCategory.Add(new Tbl_jobCategory
                {
                    PrJobCategoryTitle = PrJobCat,
                    EnJobCategoryTitle = EnJobCat,
                    fk_guildID = fk_guidID
                });
                database.SaveChanges();
                TempData["successAdd"] = "ثبت با موفقیت انجام شد";
            }
            else
            {
                TempData["failedAdd"] = "عملیات ثبت با شکست مواجه شد";
            }

            ViewBag.Guids = new SelectList(database.Tbl_guild.Where(c => c.DeleteStatus == false), "guildID", "FAguildNAme");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditJob(int? id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = (from i in database.Tbl_jobCategory where i.jobCategoryID == id select i).FirstOrDefault();
            
            if (q != null)
            {
                  ViewBag.Guids = new SelectList(database.Tbl_guild.Where(c => c.DeleteStatus == false), "guildID", "FAguildNAme", q.fk_guildID);
                return View(q);
            }
            else
            {
                ViewBag.Guids = new SelectList(database.Tbl_guild.Where(c => c.DeleteStatus == false), "guildID", "FAguildNAme", q.fk_guildID);
                return RedirectToAction("Index");
            }

        }

        [HttpPost]
        public IActionResult EditJob(int? id, Tbl_jobCategory model)
        {
            var q = (from i in database.Tbl_jobCategory where i.jobCategoryID == id select i).FirstOrDefault();
            if (id != model.jobCategoryID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                
                if (q != null)
                {
                    q.PrJobCategoryTitle = model.PrJobCategoryTitle;
                    q.EnJobCategoryTitle = model.EnJobCategoryTitle;
                    q.fk_guildID = model.fk_guildID;
                    database.Tbl_jobCategory.Update(q);
                    database.SaveChanges();
                    ViewBag.Guids = new SelectList(database.Tbl_guild.Where(c => c.DeleteStatus == false), "guildID", "FAguildNAme", q.fk_guildID);
                    return RedirectToAction("Index");
                }
                else
                {
                    return NotFound();
                }

            }

            else
            {
                ViewBag.Guids = new SelectList(database.Tbl_guild.Where(c => c.DeleteStatus == false), "guildID", "FAguildNAme", q.fk_guildID);
                TempData["failedEdit"] = "عملیات ویرایش با شکست مواجه شد";
                return View();
            }

        }

        public IActionResult DeleteJob(int? id)
        {
            var q = (from i in database.Tbl_jobCategory where i.jobCategoryID == id select i).SingleOrDefault();
            if (q != null)
            {
                database.Tbl_jobCategory.Remove(q);
                database.SaveChanges();
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";


            }
            else
            {
                TempData["FailedDelete"] = "حذف ناموفق";
            }
            return RedirectToAction("Index");
        }

        public IActionResult DeleteAllJobs(string deleteItems)
        {
            try
            {

                string strValue = deleteItems;
                string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var obj in strArray)
                {
                    var job = (from i in database.Tbl_jobCategory where i.jobCategoryID == long.Parse(obj) select i).SingleOrDefault();
                    //your delete query
                    database.Tbl_jobCategory.Remove(job);
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
