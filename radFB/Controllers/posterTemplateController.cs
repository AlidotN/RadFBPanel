using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using radFB.db;
using radFB.ViewModels;

namespace radFB.Controllers
{
    [Authorize]
    public class posterTemplateController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        public posterTemplateController(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;

        }


        radFB.Repository.repPosterTemplate rep = new Repository.repPosterTemplate();

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
            ViewBag.count = rep.posterTemplateList().Count;
            return View(rep.posterTemplateList());
        }

        [HttpGet]
        public IActionResult AddPosterTemplate()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            return View();
        }

        [HttpPost]
        public IActionResult AddPosterTemplate(VmPosterTemplate model)
        {
            string fileName = "";
            string uploads = "";

            string fileName2 = "";
     

            if (ModelState.IsValid)
            {

                if (model.posterFileAddress != null)
                {
                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\posterTemplate");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.posterFileAddress.FileName);
                }


                if (model.templatePic != null)
                {
                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\posterTemplate");
                    fileName2 = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.templatePic.FileName);
                }



                if (fileName != "")
                {
                    var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                    model.posterFileAddress.CopyTo(fileStream);
                }

                if (fileName2 != "")
                {
                    var fileStream = new FileStream(Path.Combine(uploads, fileName2), FileMode.Create);
                    model.templatePic.CopyTo(fileStream);
                }

              
                Tbl_posterTemplate pt = new Tbl_posterTemplate();
                pt.posterName = model.posterName;
                pt.posterDescription = model.posterDescription;
                pt.posterFileAddress = fileName;
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
        public IActionResult EditPosterTemplate(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
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
        public IActionResult EditPosterTemplate(long id, Tbl_posterTemplate model,IFormFile InputFile, IFormFile InputFile2)
        {
            Tbl_posterTemplate qq = rep.posterTemplate(id);

            string fileName = qq.posterFileAddress;
            string fileName2 = qq.templatePic;
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

                if (InputFile2 != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\posterTemplate", fileName2);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\posterTemplate");
                    fileName2 = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(InputFile2.FileName);
                }


                Tbl_posterTemplate pt = new Tbl_posterTemplate();
                pt.posterName = model.posterName;
                pt.posterDescription = model.posterDescription;
                pt.posterFileAddress = fileName;
                pt.templatePic = fileName2;
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


        public IActionResult DeletePosterTemplate(long id)
        {
            int st = rep.DelposterTemplate(id);
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


        public IActionResult DeleteAllPosterTemplate(string deleteItems)
        {
            int st = rep.DelAllposterTemplates(deleteItems);
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
