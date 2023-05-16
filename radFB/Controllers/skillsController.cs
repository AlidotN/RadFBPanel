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
    public class skillsController : Controller
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
            return View(database.Tbl_Skills.OrderByDescending(c=>c.SkillID).ToList());
        }

        [HttpGet]
        public IActionResult AddSkill()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
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
                TempData["successAdd"] = "ثبت با موفقیت انجام شد";
            }
            else
            {
                TempData["failedAdd"] = "عملیات ثبت با شکست مواجه شد";
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditSkill(int? id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
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
                TempData["failedEdit"] = "عملیات ویرایش با شکست مواجه شد";
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
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";


            }
            else
            {
                TempData["FailedDelete"] = "حذف ناموفق";
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
