using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class settingsController : Controller
    {

        ApplicationDbContext database = new ApplicationDbContext();

        [HttpGet]
        public IActionResult settingApp()
        {
            var q = (from i in database.Tbl_siteSetting where i.siteSettingID == 1 select i).FirstOrDefault();
            if (q != null)
            {
                return View(q);
            }
            else
            {
                return View();
            }

        }

        [HttpPost]
        public IActionResult settingApp(Tbl_siteSetting model)
        {
            try
            {
                var q = (from i in database.Tbl_siteSetting where i.siteSettingID == 1 select i).FirstOrDefault();
                if (q != null)
                {
                    q.PrAboutUS = model.PrAboutUS;
                    q.enAboutUS = model.enAboutUS;
                    q.PrRules = model.PrRules;
                    q.enRules = model.enRules;
                    q.phoneNumbers = model.phoneNumbers;
                    q.Email = model.Email;
                    q.TelegramID = model.TelegramID;
                    q.WhatsAppPhoneNumber = model.WhatsAppPhoneNumber;
                    q.instagramID = model.instagramID;
                    q.allowedBlock = model.allowedBlock;
                    q.PrDemo = model.PrDemo;
                    q.EnDemo = model.EnDemo;
                    q.postsShowTime = model.postsShowTime;
                    q.groupsMemberCount = model.groupsMemberCount;
                    q.TitleAllowedCharacterCount = model.TitleAllowedCharacterCount;
                    q.DescriptionAllowedCharacterCount = model.DescriptionAllowedCharacterCount;

                    database.Tbl_siteSetting.Update(q);
                    database.SaveChanges();
                    TempData["UpdateAction"] = Texts.EditSuccess;
                }
                else
                {
                    database.Tbl_siteSetting.Add(new Tbl_siteSetting
                    {
                        PrAboutUS = model.PrAboutUS,
                        enAboutUS = model.enAboutUS,
                        PrRules = model.PrRules,
                        enRules = model.enRules,
                        phoneNumbers = model.phoneNumbers,
                        Email = model.Email,
                        TelegramID = model.TelegramID,
                        WhatsAppPhoneNumber = model.WhatsAppPhoneNumber,
                        instagramID = model.instagramID,
                        allowedBlock = model.allowedBlock,
                        PrDemo = model.PrDemo,
                        EnDemo = model.EnDemo,
                        postsShowTime = model.postsShowTime,
                        groupsMemberCount = model.groupsMemberCount,
                        TitleAllowedCharacterCount = model.TitleAllowedCharacterCount,
                        DescriptionAllowedCharacterCount = model.DescriptionAllowedCharacterCount,

                    });
                    database.SaveChanges();
                    TempData["AddAction"] = Texts.SubmitedSuccess;
                }
            }
            catch (Exception)
            {

                TempData["problem"] = Texts.OperationFailed;
            }
            

            return View();
    }
}
}
