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
    public class guildController : Controller
    {
        readonly ApplicationDbContext database = new ApplicationDbContext();

        public IActionResult Index()
        {
            var q = (from i in database.Tbl_guild where i.DeleteStatus == false select i).ToList();
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
                TempData["successAdd"] = Texts.SubmitedSuccess;
            }
            else
            {
                TempData["failedAdd"] = Texts.SubmitFailed;
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult EditGuild(int? id)
        {
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
                TempData["failedEdit"] = Texts.EditFaild;
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;


            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
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

