using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using radFB.Models;
using radFB.Services;
using radFB.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using radFB.db;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using System.IO;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Globalization;

namespace radFB.Controllers
{
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

        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.adminPanelMenu(User.Identity.Name) != true)
            {
                roleID = false;
            }

            return roleID;
        }


        [HttpGet]
        public IActionResult Index()
        {

            ViewBag.postCount = (from i in database.Tbl_postChanged where i.DeleteStatus != true select i).ToList().Count();


            ViewBag.advCount = (from i in database.Tbl_EmploymentAdvPost where i.DeleteStatus != true select i).ToList().Count();


            ViewBag.userCount = (from i in database.Tbl_RadFBUsers where i.DeleteStatus != true select i).ToList().Count();


            ViewBag.questionnarCount = (from i in database.Tbl_questionnaire where i.DeleteStatus != true select i).ToList().Count();


            ViewBag.questionCount = (from i in database.Tbl_Question where i.DeleteStatus != true select i).ToList().Count();

            ViewBag.poster = (from i in database.Tbl_poster where i.DeleteStatus != true select i).ToString().Count();



            return View();
        }

        //سوالات بی پاسخ
        [HttpGet]
        public JsonResult answer()
        {
            long result = 0;
            var q = (from i in database.Tbl_usersQuestions where i.QuestionAnswerText == null || i.QuestionAnswerText == "" select i).ToList();
            if (q.Count() > 0)
            {
                result = q.Count();
            }
            else
            {
                result = 0;
            }
            return new JsonResult(result);
        }

        //پست های تایید نشده
        [HttpGet]
        public JsonResult post()
        {
            long result = 0;
            var q = (from i in database.Tbl_postChanged where i.postChangedStatus == false select i).ToList();
            if (q.Count() > 0)
            {
                result = q.Count();
            }
            else
            {
                result = 0;
            }
            return new JsonResult(result);
        }

        //انتقاد یا پیشنهاد جدید
        [HttpGet]
        public JsonResult suggestion()
        {
            long result = 0;
            var q = (from i in database.Tbl_criticsAndSuggestions where i.Confirmation == false select i).ToList();
            if (q.Count() > 0)
            {
                result = q.Count();
            }
            else
            {
                result = 0;
            }
            return new JsonResult(result);
        }


        //Access
        public IActionResult UserAccessList()
        {
            if (check() == false)   
            {
                return RedirectToAction("Index");
            }

            TempData["seccessDelete"] = null;
            TempData["FailedDelete"] = null;
            var q = (from i in database.Tbl_userAccess select i).OrderByDescending(c => c.userAccessID).ToList();

            List<VmUserAccess> List = new List<VmUserAccess>();
            foreach (var item in q)
            {
                VmUserAccess vm = new VmUserAccess();
                vm.userAccessID = item.userAccessID;
                vm.userAccessTitle = item.userAccessTitle;
                vm.setting = item.setting;
                vm.users = item.users;
                vm.groups = item.groups;
                vm.posts = item.posts;
                vm.financialDepartment = item.financialDepartment;
                vm.templates = item.templates;
                vm.reports = item.reports;
                vm.connectUsers = item.connectUsers;
                vm.frequently = item.frequently;
                vm.usersAdminPanel = item.usersAdminPanel;
                vm.deleteInformation = item.deleteInformation;

                List.Add(vm);
            }

            return View(List);
        }

        [HttpGet]
        public IActionResult AddUserAccess()
        {
            if (check() == false)
            {
                return RedirectToAction("Index");
            }
            TempData["AddSuccess"] = null;
            TempData["AddFailed"] = null;

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
                TempData["AddSuccess"] = "ثبت با موفقیت انجام شد";

            }
            else
            {
                TempData["AddFailed"] = "عملیات ثبت با شکست مواجه شد";
            }
            return View();
        }

        [HttpGet]
        public IActionResult EditUserAccess(int? id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index");
            }

            TempData["EditSuccess"] = null;
            TempData["EditFailed"] = null;

            var q = (from i in database.Tbl_userAccess
                     where i.userAccessID == id
                     select new VmUserAccess
                     {

                         userAccessID = i.userAccessID,
                         userAccessTitle = i.userAccessTitle,
                         setting = i.setting,
                         users = i.users,
                         groups = i.groups,
                         posts = i.posts,
                         financialDepartment = i.financialDepartment,
                         templates = i.templates,
                         reports = i.reports,
                         connectUsers = i.connectUsers,
                         frequently = i.frequently,
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
                q.groups = model.groups;
                q.posts = model.posts;
                q.financialDepartment = model.financialDepartment;
                q.templates = model.templates;
                q.reports = model.reports;
                q.connectUsers = model.connectUsers;
                q.frequently = model.frequently;
                q.usersAdminPanel = model.usersAdminPanel;
                q.deleteInformation = model.deleteInformation;


                database.Tbl_userAccess.Update(q);
                database.SaveChanges();



                TempData["EditSuccess"] = "ویرایش با موفقیت انجام شد";



            }
            else
            {
                TempData["EditFailed"] = "ویرایش انجام نشد ";
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
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";


            }
            else
            {
                TempData["FailedDelete"] = "حذف ناموفق";
            }
            return RedirectToAction("UserAccessList");
        }




        //users
        [HttpGet]
        public IActionResult UserList()
        {
            if (check() == false)
            {
                return RedirectToAction("Index");
            }

            var q = (from i in database.Users
                     join a in database.Tbl_userAccess on i.Fk_userAccessID equals a.userAccessID
                     select new VmUserList
                     {

                         id = i.Id,
                         email = i.Email,
                         FullName = i.FullName,
                         PhoneNumber = i.PhoneNumber,
                         UserPic = i.UserPic,
                         accessName = a.userAccessTitle,


                     }).OrderByDescending(c => c.id).ToList();
            return View(q);
        }

        [HttpGet]
        public IActionResult AddUser()
        {
            if (check() == false)
            {
                return RedirectToAction("Index");
            }
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

                    TempData["AddSuccess"] = "ثبت با موفقیت انجام شد";
                }
                else
                {
                    TempData["AddFailed"] = "عملیات ثبت با شکست مواجه شد";
                }

            }
            ViewBag.AccessNames = new SelectList(database.Tbl_userAccess, "userAccessID", "userAccessTitle");
            return View();
        }


        [HttpGet]
        public IActionResult EditUser(string id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index");
            }

            var q = (from i in database.Users
                     where i.Id == id
                     select new VmAdminPanelUsers
                     {
                         email = i.Email,
                         FullName = i.FullName,
                         PhoneNumber = i.PhoneNumber,
                         Fk_userAccessID = i.Fk_userAccessID
                     }).FirstOrDefault();
            ViewBag.AccessNames = new SelectList(database.Tbl_userAccess, "userAccessID", "userAccessTitle", q.Fk_userAccessID);
            var q2 = (from i in database.Users where i.Id == id select i).FirstOrDefault();
            ViewBag.id = id;
            ViewBag.userPic = q2.UserPic;

            return View(q);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult EditUser(string id, VmAdminPanelUsers model)
        {
            var q = (from i in database.Users where i.Id == id select i).FirstOrDefault();

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

                    if (model.UserPic != null)
                    {
                        var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                        model.UserPic.CopyTo(fileStream);
                    }

                    // TempData["AddSuccess"] = "ویرایش با موفقیت انجام شد";
                    return RedirectToAction(nameof(UserList));
                }
                else
                {

                    TempData["EditFailed"] = "عملیات ویرایش با شکست مواجه شد";
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

                    TempData["seccessDelete"] = "حذف با موفقیت انجام شد";

            }
            else
            {
                TempData["FailedDelete"] = "کاربر یافت نشد";
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
                    logger.LogWarning("حساب کاربری شما قفل می باشد ");
                }
                if (result.RequiresTwoFactor)
                {
                    //
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "نام کاربری یا کلمه عبور اشتباه می باشد");
                    return View(model);
                }
            }
            return View(model);
        }


        public IActionResult wordList()
        {
            if (check() == false)
            {
                return RedirectToAction("Index");
            }

            var q = (from i in database.Tbl_UnauthorizedWords
                     join b in database.Users on i.fk_ApplicationUser equals b.Id
                     select new { i.UnauthorizedWordsID, i.prWord, i.registerDate, b.FullName }).OrderByDescending(c => c.UnauthorizedWordsID).ToList();

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
            if (check() == false)
            {
                return RedirectToAction("Index");
            }
            return View();
        }


        [HttpPost]
        public IActionResult AddWord(string prWord, string enWord)
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
                TempData["successAddWord"] = "ثبت با موفقیت انجام شد";
                return View();
            }
            catch
            {

                TempData["addWord"] = "عملیات با شکست مواجه شد";
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
            if (check() == false)
            {
                return RedirectToAction("Index");
            }
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
                    TempData["success"] = "ویرایش با موفقیت انجام شد";
                    return RedirectToAction("wordList");
                }
                catch
                {

                    TempData["failed"] = "عملیات با شکست مواجه شد";
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
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";


            }
            else
            {
                TempData["failed"] = "حذف ناموفق";
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
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            catch (Exception)
            {

                TempData["failed"] = "عملیات حذف با شکست مواجه شد";
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
