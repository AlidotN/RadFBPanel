using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Models.Data;
using RadFBApp.Models.ViewModels.Admin;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    public class posterTemplateController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        public posterTemplateController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;

        }


        repPosterTemplate rep = new repPosterTemplate();

        public IActionResult Index()
        {
            ViewBag.count = rep.posterTemplateList().Count;
            return View(rep.posterTemplateList());
        }

        [HttpGet]
        public IActionResult AddPosterTemplate()
        {
            return View();
        }

        [HttpPost]
        public IActionResult AddPosterTemplate(VmPosterTemplate model)
        {
            string fileName = "";
            string uploads = "";

            if (ModelState.IsValid)
            {

                if (model.posterFileAddress != null)
                {
                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\posterTemplate");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.posterFileAddress.FileName);
                }

                if (fileName != "")
                {
                    var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                    model.posterFileAddress.CopyTo(fileStream);
                }
                Tbl_posterTemplate pt = new Tbl_posterTemplate();
                pt.posterName = model.posterName;
                pt.posterDescription = model.posterDescription;
                pt.posterFileAddress = fileName;

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
        public IActionResult EditPosterTemplate(long id)
        {

            var q = rep.posterTemplate(id);
            if (q != null)
            {
                return View(q);
            }
            else
            {
                return NotFound();
            }

        }

        [HttpPost]
        public IActionResult EditPosterTemplate(long id, Tbl_posterTemplate model,IFormFile InputFile)
        {
            Tbl_posterTemplate qq = rep.posterTemplate(id);

            string fileName = qq.posterFileAddress;
            string uploads = "";

            if (ModelState.IsValid)
            {
                if (InputFile != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\posterTemplate", fileName);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\posterTemplate");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(InputFile.FileName);
                }


                Tbl_posterTemplate pt = new Tbl_posterTemplate();
                pt.posterName = model.posterName;
                pt.posterDescription = model.posterDescription;
                pt.posterFileAddress = fileName;
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


        public IActionResult DeletePosterTemplate(long id)
        {
            int st = rep.DelposterTemplate(id);
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


        public IActionResult DeleteAllPosterTemplate(string deleteItems)
        {
            int st = rep.DelAllposterTemplates(deleteItems);
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
