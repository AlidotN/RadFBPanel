using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class jobController : Controller
    {
        readonly ApplicationDbContext database = new ApplicationDbContext();

        public IActionResult Index()
        {
            ViewBag.Guids = new SelectList(database.Tbl_guild.Where(c => c.DeleteStatus == false), "guildID", "FAguildNAme");

            return View(database.Tbl_jobCategory.ToList());
        }

        [HttpGet]
        public IActionResult AddJob()
        {
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
                TempData["successAdd"] = Texts.SubmitedSuccess;
            }
            else
            {
                TempData["failedAdd"] = Texts.SubmitFailed;
            }

            ViewBag.Guids = new SelectList(database.Tbl_guild.Where(c => c.DeleteStatus == false), "guildID", "FAguildNAme");
            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditJob(int? id)
        {
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
                TempData["failedEdit"] = Texts.EditFaild;
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;


            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            catch (Exception)
            {

                TempData["FailedDelete"] = Texts.DeleteFaild;
            }


            return RedirectToAction("Index");
        }
    }
}
