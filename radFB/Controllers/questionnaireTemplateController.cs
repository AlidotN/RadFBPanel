using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using radFB.ViewModels;
using radFB.db;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Authorization;

namespace radFB.Controllers
{
    [Authorize]
    public class questionnaireTemplateController : Controller
    {

        private readonly IHostingEnvironment _appEnvironment;
        public questionnaireTemplateController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;

        }

        radFB.Repository.repQuestionnaireTemplate rep = new Repository.repQuestionnaireTemplate();
        ApplicationDbContext database = new ApplicationDbContext();

        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.templateMenu(User.Identity.Name) != true)
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
            ViewBag.count = rep.questionnaireTemplateList().Count;
            return View(rep.questionnaireTemplateList());
        }

        [HttpGet]
        public IActionResult AddQuestionnaireTemplate()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            ViewBag.category = new SelectList(database.Tbl_jobCategory, "jobCategoryID", "PrJobCategoryTitle");
            return View();
        }

        [HttpPost]
        public IActionResult AddQuestionnaireTemplate(VmQuestionnairTemplate model)
        {
            string fileName = "";
            string fileName2 = "";
            string uploads = "";

            if (ModelState.IsValid)
            {

                if (model.questionnaireTemplateAddress != null)
                {
                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\questionnaireTemplate");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.questionnaireTemplateAddress.FileName);
                }

                if (model.templatePic != null)
                {
                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\questionnaireTemplate");
                    fileName2 = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.templatePic.FileName);
                }

                if (fileName != "")
                {
                    var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                    model.questionnaireTemplateAddress.CopyTo(fileStream);
                }

                if (fileName2 != "")
                {
                    var fileStream = new FileStream(Path.Combine(uploads, fileName2), FileMode.Create);
                    model.templatePic.CopyTo(fileStream);
                }
                Tbl_questionnaireTemplate pt = new Tbl_questionnaireTemplate();
                pt.questionnaireTemplateTitle = model.questionnaireTemplateTitle;
                pt.questionnaireTemplateDescription = model.questionnaireTemplateDescription;
                pt.fk_jobCategoryID = model.fk_jobCategoryID;
                pt.questionnaireTemplateAddress = fileName;
                pt.templatePic = fileName2;
                var q = rep.Add(pt);
                if (q != false)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "خطا در ثبت اطلاعات";
                    return View();
                }

            }
            TempData["error"] = "خطا در ثبت اطلاعات";
            return View();
        }

        [HttpGet]
        public IActionResult EditQuestionnaireTemplate(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
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
        public IActionResult EditQuestionnaireTemplate(long id, Tbl_questionnaireTemplate model, IFormFile InputFile, IFormFile InputFile2)
        {
            Tbl_questionnaireTemplate qq = rep.questionnaireTemplate(id);

            string fileName = qq.questionnaireTemplateAddress;
            string fileName2 = qq.templatePic;
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

                if (InputFile2 != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\QuestionnaireTemplate", fileName2);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\questionnaireTemplate");
                    fileName2 = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(InputFile2.FileName);
                }


                Tbl_questionnaireTemplate pt = new Tbl_questionnaireTemplate();
                pt.questionnaireTemplateTitle = model.questionnaireTemplateTitle;
                pt.questionnaireTemplateDescription = model.questionnaireTemplateDescription;
                pt.fk_jobCategoryID = model.fk_jobCategoryID;
                pt.templatePic = fileName2;
                pt.questionnaireTemplateAddress = fileName;
                var q = rep.edit(id, pt);
                if (q != false)
                {
                    if (InputFile != null)
                    {
                        var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                        InputFile.CopyTo(fileStream);
                    }

                    if (InputFile2 != null)
                    {
                        var fileStream = new FileStream(Path.Combine(uploads, fileName2), FileMode.Create);
                        InputFile2.CopyTo(fileStream);
                    }

                    return RedirectToAction("Index");
                }
                else
                {
                    TempData["error"] = "خطا در ثبت اطلاعات";
                    return View();
                }

            }
            TempData["error"] = "خطا در ثبت اطلاعات";
            return View();
        }


        public IActionResult DeleteQuestionnaireTemplate(long id)
        {
            int st = rep.DelquestionnaireTemplate(id);
            if (st == 1)
            {
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            return RedirectToAction("Index");
        }


        public IActionResult DeleteAllQuestionnaireTemplate(string deleteItems)
        {
            int st = rep.DelAllquestionnaireTemplates(deleteItems);
            if (st == 1)
            {
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            return RedirectToAction("Index");
        }
    }
}
