// Ignore Spelling: App Admin

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RadFBApp.Models;
using RadFBApp.Services;
using RadFBApp.Models.ViewModels.Admin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using RadFBApp.Models.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;
using RadFBApp.Areas.Panel.Resources;


namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;
        private readonly ILogger logger;
        private readonly IEmailSender emailSender;
        private readonly IHostingEnvironment _appEnvironment;
        public AccountController(UserManager<ApplicationUser> _userManager, SignInManager<ApplicationUser> _signInManager, ILoggerFactory _loggerFactory, IEmailSender _emailSender, IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;
            userManager = _userManager;
            signInManager = _signInManager;
            logger = _loggerFactory.CreateLogger<AccountController>();
            emailSender = _emailSender;
        }

        ApplicationDbContext database = new ApplicationDbContext();



        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }


        //Access
        public IActionResult UserAccessList()
        {

            TempData["seccessDelete"] = "";
            TempData["FailedDelete"] = "";
            var q = (from i in database.Tbl_userAccess
                     select new VmUserAccess
                     {

                         userAccessID = i.userAccessID,
                         userAccessTitle = i.userAccessTitle,
                         setting = i.setting,
                         users = i.users,
                         UnauthorizedWords = i.UnauthorizedWords,
                         posts = i.posts,
                         permiumPackage = i.permiumPackage,
                         financialDepartment = i.financialDepartment,
                         questions = i.questions,
                         adv = i.adv,
                         reports = i.adv,
                         criticsAndSuggestions = i.criticsAndSuggestions,
                         userAccessMenu = i.userAccessMenu,
                         usersAdminPanel = i.usersAdminPanel,
                         deleteInformation = i.deleteInformation
                     }).ToList();


            return View(q);
        }

        [HttpGet]
        public IActionResult AddUserAccess()
        {
            TempData["AddSuccess"] = "";
            TempData["AddFailed"] = "";

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUserAccess(Tbl_userAccess model)
        {
            if (ModelState.IsValid)
            {

                database.Tbl_userAccess.Add(model);

                database.SaveChanges();
                TempData["AddSuccess"] = Texts.SubmitedSuccess;

            }
            else
            {
                TempData["AddFailed"] = Texts.SubmitFailed;
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditUserAccess(int? id)
        {
            TempData["EditSuccess"] = "";
            TempData["EditFailed"] = "";

            var q = (from i in database.Tbl_userAccess
                     where i.userAccessID == id
                     select new VmUserAccess
                     {

                         userAccessID = i.userAccessID,
                         userAccessTitle = i.userAccessTitle,
                         setting = i.setting,
                         users = i.users,
                         UnauthorizedWords = i.UnauthorizedWords,
                         posts = i.posts,
                         permiumPackage = i.permiumPackage,
                         financialDepartment = i.financialDepartment,
                         questions = i.questions,
                         adv = i.adv,
                         reports = i.adv,
                         criticsAndSuggestions = i.criticsAndSuggestions,
                         userAccessMenu = i.userAccessMenu,
                         usersAdminPanel = i.usersAdminPanel,
                         deleteInformation = i.deleteInformation
                     }).FirstOrDefault();

            return View(q);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUserAccess(int id, VmUserAccess model)
        {
            if (id != model.userAccessID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var q = (from i in database.Tbl_userAccess where i.userAccessID == id select i).FirstOrDefault();
                q.userAccessTitle = model.userAccessTitle;
                q.setting = model.setting;
                q.users = model.users;
                q.UnauthorizedWords = model.UnauthorizedWords;
                q.posts = model.posts;
                q.permiumPackage = model.permiumPackage;
                q.financialDepartment = model.financialDepartment;
                q.questions = model.questions;
                q.adv = model.adv;
                q.reports = model.adv;
                q.criticsAndSuggestions = model.criticsAndSuggestions;
                q.userAccessMenu = model.userAccessMenu;
                q.usersAdminPanel = model.usersAdminPanel;
                q.deleteInformation = model.deleteInformation;


                database.Tbl_userAccess.Update(q);
                database.SaveChanges();



                TempData["EditSuccess"] = Texts.EditSuccess;



            }
            else
            {
                TempData["EditFailed"] = Texts.EditFaild;
            }
            return View();
        }

        public IActionResult DeleteUserAccess(int? id)
        {

            var q = (from i in database.Tbl_userAccess where i.userAccessID == id select i).SingleOrDefault();
            if (q != null)
            {
                database.Tbl_userAccess.Remove(q);
                database.SaveChanges();
                TempData["seccessDelete"] = Texts.DeleteSuccess;


            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("UserAccessList");
        }




        //users
        [HttpGet]
        public IActionResult UserList()
        {
            List<ApplicationUser> users = userManager.Users.ToList();
            var q = (from i in users
                     join a in database.Tbl_userAccess on i.Fk_userAccessID equals a.userAccessID
                     select new VmUserList
                     {

                         id = i.Id,
                         email = i.Email,
                         FullName = i.FullName,
                         PhoneNumber = i.PhoneNumber,
                         UserPic = i.UserPic,
                         accessName = a.userAccessTitle,


                     }).ToList();
            return View(q);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            ViewBag.AccessNames = new SelectList(database.Tbl_userAccess, "userAccessID", "userAccessTitle");

            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddUser(VmAdminPanelUsers model)
        {
            string fileName = "";
            string uploads = "";

            if (ModelState.IsValid)
            {

                if (model.UserPic != null)
                {
                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\img");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.UserPic.FileName);
                }

                var user = new ApplicationUser
                {
                    Email = model.email,
                    UserName = model.email,
                    FullName = model.FullName,
                    PhoneNumber = model.PhoneNumber,
                    UserPic = fileName,
                    Fk_userAccessID = model.Fk_userAccessID
                };

                var result = await userManager.CreateAsync(user, model.password);
                if (result.Succeeded)
                {
                    //await userManager.IsEmailConfirmedAsync(user);
                    database.SaveChanges();
                    if (fileName != "")
                    {
                        var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                        model.UserPic.CopyTo(fileStream);
                    }

                    TempData["AddSuccess"] = Texts.SubmitedSuccess;
                }
                else
                {
                    TempData["AddFailed"] = Texts.SubmitFailed;
                }

            }
            ViewBag.AccessNames = new SelectList(database.Tbl_userAccess, "userAccessID", "userAccessTitle");
            return View();
        }


        [HttpGet]
        public IActionResult EditUser(string id)
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            var q = (from i in users
                     where i.Id == id
                     select new VmAdminPanelUsers
                     {
                         email = i.Email,
                         FullName = i.FullName,
                         PhoneNumber = i.PhoneNumber,
                         Fk_userAccessID = i.Fk_userAccessID
                     }).FirstOrDefault();
            ViewBag.AccessNames = new SelectList(database.Tbl_userAccess, "userAccessID", "userAccessTitle", q.Fk_userAccessID);
            var q2 = (from i in users where i.Id == id select i).FirstOrDefault();
            ViewBag.id = id;
            ViewBag.userPic = q2.UserPic;

            return View(q);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(string id, VmAdminPanelUsers model)
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            var q = (from i in users where i.Id == id select i).FirstOrDefault();

            string fileName = q.UserPic;
            string uploads = "";

            if (ModelState.IsValid)
            {
                if (model.UserPic != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads\\img", fileName);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads\\img");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.UserPic.FileName);
                }


                if (q != null)
                {

                    q.FullName = model.FullName;
                    q.PhoneNumber = model.PhoneNumber;
                    q.UserPic = fileName;
                    q.Fk_userAccessID = model.Fk_userAccessID;

                    database.SaveChanges();

                    
                    var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                    model.UserPic.CopyTo(fileStream);

                     TempData["EditSuccess"] = Texts.EditSuccess;
                    return RedirectToAction(nameof(UserList));
                }
                else
                {

                    TempData["EditFailed"] = Texts.EditFaild;
                }

            }
            ViewBag.AccessNames = new SelectList(database.Tbl_userAccess, "userAccessID", "userAccessTitle", model.Fk_userAccessID);
            return View();
        }



        public async Task<IActionResult> DeleteUser(string id)
        {

            ApplicationUser q = await userManager.FindByIdAsync(id);
            if (q != null)
            {

                IdentityResult result = await userManager.DeleteAsync(q);
                if (result.Succeeded)

                    TempData["seccessDelete"] = Texts.DeleteSuccess;

            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }
            return RedirectToAction("UserList");
        }





        [HttpPost]
        public JsonResult CheckUsername(string UserName)
        {
            string retval = "";
            if (database.Users.Any(r => r.Email == UserName))
            {
                retval = "true";
            }
            else
            {
                retval = "false";
            }
            return new JsonResult(retval);
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult Login(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var result = await signInManager.PasswordSignInAsync(model.Email, model.Password, model.RememberMe, false);
                var user = new ApplicationUser { Email = model.Email };
                var CheckeConfirmEmail = signInManager.UserManager.Users.Where(c => c.Email == model.Email).FirstOrDefault();
                if (result.Succeeded)
                {
                    if (returnUrl != null)
                    {
                        return RedirectToLocal(returnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index");
                    }

                }
                if (result.IsLockedOut)
                {
                    logger.LogWarning(Texts.AccountIdBanned);
                }
                if (result.RequiresTwoFactor)
                {
                    //
                }
                else
                {
                    ModelState.AddModelError(string.Empty, Texts.WrongPassUser);
                    return View(model);
                }
            }
            return View(model);
        }


        public IActionResult wordList()
        {
            List<ApplicationUser> users = new List<ApplicationUser>();
            var q = (from i in database.Tbl_UnauthorizedWords
                     join b in users on i.fk_ApplicationUser equals b.Id
                     select new {i.UnauthorizedWordsID , i.prWord,i.registerDate,b.FullName }).ToList();

            List<VmUnauthorizedWords> list = new List<VmUnauthorizedWords>();
            if (q != null)
            {
                foreach (var item in q)
                {
                    VmUnauthorizedWords vm = new VmUnauthorizedWords();
                    vm.wordID = item.UnauthorizedWordsID;
                    vm.creatorUser = item.FullName;
                    vm.date = item.registerDate;
                    vm.word = item.prWord;

                    list.Add(vm);
                }
                ViewBag.count = q.Count();
                return View(list);

            }
            else
            {
                return View();
            }
            
        }


        [HttpGet]
        public IActionResult AddWord()
        {
            return View();
        }


        [HttpPost]
        public IActionResult AddWord(string prWord,string enWord)
        {
            PersianCalendar pc = new PersianCalendar();
            DateTime d = DateTime.Now;
            try
            {
                string id = "";
                if (User.Identity.IsAuthenticated)
                {
                    string currenetUser = User.Identity.Name;
                    var currentID = (from i in database.Users where i.UserName == currenetUser select i).FirstOrDefault();
                    id = currentID.Id;
                }

                database.Tbl_UnauthorizedWords.Add(new Tbl_UnauthorizedWords
                {
                    prWord = prWord,
                    enWord = enWord,
                    registerDate = string.Format("{0}/{1}/{2}", pc.GetYear(d), pc.GetMonth(d), pc.GetDayOfMonth(d)),
                fk_ApplicationUser = id
                });
                database.SaveChanges();
                TempData["successAddWord"] = Texts.SubmitedSuccess;
                return View();
            }
            catch 
            {

                TempData["addWord"] = Texts.SubmitFailed;
                return View();
            }
            
        }

        [HttpGet]
        public IActionResult EditWord(long id)
        {
            var q = (from i in database.Tbl_UnauthorizedWords where i.UnauthorizedWordsID == id select i).FirstOrDefault();
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
        public IActionResult EditWord(long id, string prWord, string enWord)
        {
            var q = (from i in database.Tbl_UnauthorizedWords where i.UnauthorizedWordsID == id select i).FirstOrDefault();
            if (q != null)
            {
                string UserId = "";
                if (User.Identity.IsAuthenticated)
                {
                    string currenetUser = User.Identity.Name;
                    var currentID = (from i in database.Users where i.UserName == currenetUser select i).FirstOrDefault();
                    UserId = currentID.Id;
                }
                try
                {

                    q.prWord = prWord;
                    q.enWord = enWord;
                    q.registerDate = DateTime.Now.Date.ToString();
                    q.fk_ApplicationUser = UserId;
                    database.Tbl_UnauthorizedWords.Update(q);
                    database.SaveChanges();
                    TempData["success"] = Texts.EditSuccess;
                    return RedirectToAction("wordList");
                }
                catch
                {

                    TempData["failed"] = Texts.EditFaild;
                    return View(q);
                }
            }
            else
            {
                return NotFound();
            }

        }


        public IActionResult DeleteWord(int? id)
        {
            var q = (from i in database.Tbl_UnauthorizedWords where i.UnauthorizedWordsID == id select i).SingleOrDefault();
            if (q != null)
            {
                database.Tbl_UnauthorizedWords.Remove(q);
                database.SaveChanges();
                TempData["seccessDelete"] = Texts.DeleteSuccess;


            }
            else
            {
                TempData["failed"] = Texts.DeleteFaild;
            }
            return RedirectToAction("wordList");
        }


        public IActionResult DeleteAllWords(string deleteItems)
        {
            try
            {

                string strValue = deleteItems;
                string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                foreach (var obj in strArray)
                {
                    var q = (from i in database.Tbl_UnauthorizedWords where i.UnauthorizedWordsID == long.Parse(obj) select i).SingleOrDefault();
                    //your delete query
                    database.Tbl_UnauthorizedWords.Remove(q);
                }
                database.SaveChanges();
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            catch (Exception)
            {

                TempData["failed"] = Texts.DeleteFaild;
            }


            return RedirectToAction("wordList");
        }

        [HttpGet]
        public async Task<IActionResult> LogOff()
        {
            if (User.Identity.IsAuthenticated)
            {
                await signInManager.SignOutAsync();
            }
            return RedirectToAction(nameof(AccountController.Login), "Account");
        }

        private IActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Login");
            }
        }

    }
}
