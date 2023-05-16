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
    public class guildController : Controller
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
            var q = (from i in database.Tbl_guild where i.DeleteStatus == false select i).OrderByDescending(c=>c.guildID).ToList();
            return View(q);
        }

    

        [HttpPost]
        public IActionResult AddGuild(string PrGuild, string EnGuild, string color)
        {
            if (PrGuild != "" && EnGuild != "" && PrGuild != null && EnGuild != null && color != null && color != null)
            {
                database.Tbl_guild.Add(new Tbl_guild
                {
                    FAguildNAme = PrGuild,
                    EnguildNAme = EnGuild,
                    guildColor = color,
                    DeleteStatus = false
                }) ;
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
        public IActionResult EditGuild(int? id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = (from i in database.Tbl_guild where i.guildID == id select i).FirstOrDefault();

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
        public IActionResult EditGuild(int? id, Tbl_guild model)
        {
            if (id != model.guildID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                var q = (from i in database.Tbl_guild where i.guildID == id select i).FirstOrDefault();
                if (q != null)
                {
                    q.FAguildNAme = model.FAguildNAme;
                    q.EnguildNAme = model.EnguildNAme;
                    q.guildColor = model.guildColor;
                    q.DeleteStatus = false;
                    database.Tbl_guild.Update(q);
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



        public IActionResult DeleteGuild(int? id)
        {
            var q = (from i in database.Tbl_guild where i.guildID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                database.Tbl_guild.Update(q);
                database.SaveChanges();
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";


            }
            else
            {
                TempData["FailedDelete"] = "حذف ناموفق";
            }
            return RedirectToAction("Index");
        }




        public IActionResult DeleteAllGuild(string deleteItems)
        {
            try
            {

                string strValue = deleteItems;
                string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var obj in strArray)
                {
                    var q = (from i in database.Tbl_guild where i.guildID == long.Parse(obj) select i).SingleOrDefault();
                    //your delete query
                    q.DeleteStatus = true;
                    database.Tbl_guild.Update(q);
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

