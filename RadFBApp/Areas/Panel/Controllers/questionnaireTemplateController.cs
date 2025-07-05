using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Models.ViewModels.Admin;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Areas.Panel.Repository;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using RadFBApp.Areas.Panel.Resources;
using Microsoft.AspNetCore.Authorization;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class questionnaireTemplateController : Controller
    {

        private readonly IHostingEnvironment _appEnvironment;
        public questionnaireTemplateController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;

        }

        readonly repQuestionnaireTemplate rep = new repQuestionnaireTemplate();
        ApplicationDbContext database = new ApplicationDbContext();

        public IActionResult Index()
        {
            ViewBag.count = rep.questionnaireTemplateList().Count;
            return View(rep.questionnaireTemplateList());
        }

        [HttpGet]
        public IActionResult AddQuestionnaireTemplate()
        {
            ViewBag.category = new SelectList(database.Tbl_jobCategory, "jobCategoryID", "PrJobCategoryTitle");
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestionnaireTemplate(VmQuestionnairTemplate model)
        {
            string fileName = "";
            string uploads = "";

            if (ModelState.IsValid)
            {

                if (model.questionnaireTemplateAddress != null)
                {
                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\questionnaireTemplate");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.questionnaireTemplateAddress.FileName);
                }

                if (fileName != "")
                {
                    var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                    model.questionnaireTemplateAddress.CopyTo(fileStream);
                }
                Tbl_questionnaireTemplate pt = new Tbl_questionnaireTemplate();
                pt.questionnaireTemplateTitle = model.questionnaireTemplateTitle;
                pt.questionnaireTemplateDescription = model.questionnaireTemplateDescription;
                pt.fk_jobCategoryID = model.fk_jobCategoryID;
                pt.questionnaireTemplateAddress = fileName;

                var q = rep.Add(pt);
                if (q != false)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = Texts.SubmitFailed;
                    return View();
                }

            }
            TempData["error"] = Texts.SubmitFailed;
            return View();
        }

        [HttpGet]
        public IActionResult EditQuestionnaireTemplate(long id)
        {

            var q = rep.questionnaireTemplate(id);
           
            if (q != null)
            {
                ViewBag.category = new SelectList(database.Tbl_jobCategory, "jobCategoryID", "PrJobCategoryTitle", q.fk_jobCategoryID);
                return View(q);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult EditQuestionnaireTemplate(long id, Tbl_questionnaireTemplate model, IFormFile InputFile)
        {
            Tbl_questionnaireTemplate qq = rep.questionnaireTemplate(id);

            string fileName = qq.questionnaireTemplateAddress;
            string uploads = "";

            if (ModelState.IsValid)
            {
                if (InputFile != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\QuestionnaireTemplate", fileName);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\questionnaireTemplate");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(InputFile.FileName);
                }


                Tbl_questionnaireTemplate pt = new Tbl_questionnaireTemplate();
                pt.questionnaireTemplateTitle = model.questionnaireTemplateTitle;
                pt.questionnaireTemplateDescription = model.questionnaireTemplateDescription;
                pt.fk_jobCategoryID = model.fk_jobCategoryID;
                pt.questionnaireTemplateAddress = fileName;
                var q = rep.edit(id, pt);
                if (q != false)
                {
                    if (InputFile != null)
                    {
                        var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                        InputFile.CopyTo(fileStream);
                    }
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = Texts.SubmitFailed;
                    return View();
                }

            }
            TempData["error"] = Texts.SubmitFailed;
            return View();
        }


        public IActionResult DeleteQuestionnaireTemplate(long id)
        {
            int st = rep.DelquestionnaireTemplate(id);
            if (st == 1)
            {
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllQuestionnaireTemplate(string deleteItems)
        {
            int st = rep.DelAllquestionnaireTemplates(deleteItems);
            if (st == 1)
            {
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("Index");
        }
    }
}
