using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Resources;
using RadFBApp.Models;
using RadFBApp.Models.Data;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class skillsController : Controller
    {

        ApplicationDbContext database = new ApplicationDbContext();

        public IActionResult Index()
        {

            return View(database.Tbl_Skills.ToList());
        }

        [HttpGet]
        public IActionResult AddSkill()
        {

            return PartialView();
        }

        [HttpPost]
        public IActionResult AddSkill(string PrSkillTitle, string EnSkillTitle)
        {
            if (PrSkillTitle != "" && EnSkillTitle != "" && PrSkillTitle != null && EnSkillTitle != null)
            {
                database.Tbl_Skills.Add(new Tbl_Skills
                {
                    PrSkillTitle = PrSkillTitle,
                    EnSkillTitle = EnSkillTitle
                });
                database.SaveChanges();
                TempData["successAdd"] = Texts.SubmitedSuccess;
            }
            else
            {
                TempData["failedAdd"] = Texts.SubmitFailed;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int? id)
        {
            var q = (from i in database.Tbl_Skills where i.SkillID == id select i).FirstOrDefault();
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
        public IActionResult EditSkill(int? id, Tbl_Skills model)
        {
            if (id != model.SkillID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var q = (from i in database.Tbl_Skills where i.SkillID == id select i).FirstOrDefault();
                if (q != null)
                {
                    q.PrSkillTitle = model.PrSkillTitle;
                    q.EnSkillTitle = model.EnSkillTitle;
                    database.Tbl_Skills.Update(q);
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
                TempData["failedEdit"] = Texts.EditFaild;
                return View();
            }

        }



        public IActionResult DeleteSkill(int? id)
        {
            var q = (from i in database.Tbl_Skills where i.SkillID == id select i).SingleOrDefault();
            if (q != null)
            {
                database.Tbl_Skills.Remove(q);
                database.SaveChanges();
                TempData["seccessDelete"] = Texts.DeleteSuccess;


            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }



      
        public IActionResult DeleteAllSkills(string deleteItems)
        {
            try
            {

                string strValue = deleteItems;
                string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var obj in strArray)
                {
                    var skill = (from i in database.Tbl_Skills where i.SkillID == long.Parse(obj) select i).SingleOrDefault();
                    //your delete query
                    database.Tbl_Skills.Remove(skill);
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
