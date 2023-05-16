using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using radFB.db;
using radFB.ViewModels;

namespace radFB.Controllers
{
    [Authorize]
    public class appUsersController : Controller
    {
        ApplicationDbContext database = new ApplicationDbContext();
        Repository.repRadfbUsers rep = new Repository.repRadfbUsers();


        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.UsersMenu(User.Identity.Name) != true)
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
            var q = rep.userLists();

            ViewBag.userCount = q.Count();

            return View(q);
        }


        public IActionResult showRealClient(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.showRealUser(id);
            string cd = "";
            if (q.companyDesire == true)
                cd = "بله";
            else
                cd = "خیر";
            VmRealClient vm = new VmRealClient();
            vm.RealClientID = q.RadFbUserID;
            vm.email = q.email;
            vm.phoneNumber = q.phoneNumber;
            vm.FullName = q.FirstName + " " + q.LastName;
            vm.birthday = q.birthday;
            vm.companyDesire = cd;
            vm.Gender = q.PrGenderTitle;
            vm.province = q.provinceName;
            vm.city = q.city;
            vm.maritalstatusTitle = q.FaMaritalstatusTitle;
            vm.interdusedEmail = q.interdusedEmail;
            vm.UserPic = q.UserPic;
            vm.EducationLevel = rep.aduName(id);


            ViewBag.activity = rep.activities(id);
            ViewBag.skills = rep.skills(id);
            ViewBag.exprienses = rep.exprienses(id);
            ViewBag.voluntary = rep.voluntary(id);
            ViewBag.awards = rep.awards(id);
            ViewBag.favorites = rep.favorites(id);
            ViewBag.books = rep.booksCount(id).Count().ToString();
            ViewBag.articles = rep.articlesCount(id).Count().ToString();
            ViewBag.posters = rep.PostersCount(id).Count().ToString();

            return View(vm);
        }

        public IActionResult showLegalClient(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.showLegalUser(id);

            VmLegalClient vm = new VmLegalClient();
            vm.legalClientID = q.RadFbUserID;
            vm.email = q.email;
            vm.phoneNumber = q.phoneNumber;
            vm.CEOName = q.CEOName;
            vm.companyName = q.companyName;
            vm.DateOfEstablishment = q.DateOfEstablishment;
            vm.membersCount = q.membersCount;
            vm.province = q.provinceName;
            vm.city = q.city;
            vm.natioalCode = q.natioalCode;
            vm.interdusedEmail = q.interdusedEmail;
            vm.UserPic = q.UserPic;
            vm.RegisterNumber = q.RegisterNumber;
            vm.companyType = q.companyType;

            ViewBag.activity = rep.activities(id);
            ViewBag.skills = rep.skills(id);
            ViewBag.exprienses = rep.exprienses(id);
            ViewBag.voluntary = rep.voluntary(id);
            ViewBag.awards = rep.awards(id);
            ViewBag.favorites = rep.favorites(id);
            ViewBag.books = rep.booksCount(id).ToString();
            ViewBag.articles = rep.articlesCount(id).ToString();
            ViewBag.posters = rep.PostersCount(id).ToString();

            return View(vm);
        }

        public IActionResult DeleteUser(long id)
        {
            var q = (from i in database.Tbl_RadFBUsers where i.RadFbUserID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                database.SaveChanges();
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";


            }
            else
            {
                TempData["FailedDelete"] = "حذف ناموفق";
            }
            return RedirectToAction("Index");
        }


        public IActionResult BlockUser(long id)
        {
            var q = (from i in database.Tbl_RadFBUsers where i.RadFbUserID == id select i).SingleOrDefault();
            if (q != null)
            {
                bool status = !(q.userStatus);
                q.userStatus = status;
                q.inactiveDate = DateTime.Now.ToString();
                database.SaveChanges();
                if (status == false)
                {
                    TempData["seccessDelete"] = "کاربر مسدود شد";
                }
                else
                {
                    TempData["seccessDelete"] = "کاربر فعال شد";
                }


            }
            else
            {
                TempData["FailedDelete"] = " ناموفق";
            }
            return RedirectToAction("Index");
        }


        public IActionResult UnBlockUser(long id)
        {
            var q = (from i in database.Tbl_RadFBUsers where i.RadFbUserID == id select i).SingleOrDefault();
            if (q != null)
            {
                bool status = !(q.userStatus);
                q.userStatus = status;
                database.SaveChanges();
                TempData["seccessDelete"] = "کاربر فعال شد";
            }
            else
            {
                TempData["FailedDelete"] = " ناموفق";
            }
            return RedirectToAction("inactiveUsers");
        }



        public IActionResult ShowAllMessages()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.messagesList();

            ViewBag.MessagesCount = q.Count();

            return View(q);
        }


        public IActionResult ShowDetailMessages(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.MessageDetail(id);

            ViewBag.MessagesCount = q.Count();

            return View(q);
        }

        public IActionResult DeleteMessage(long id, long userId)
        {
            var q = (from i in database.Tbl_messages where i.messageID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                database.SaveChanges();
                TempData["seccessDelete"] = "پیام حذف شد";
            }
            else
            {
                TempData["FailedDelete"] = " ناموفق";
            }

            return RedirectToAction("ShowDetailMessages", new { id = userId });
        }


        public IActionResult inactiveUsers()
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.inactiveUsers();
            ViewBag.Count = q.Count();
            return View(q);
        }


        public IActionResult DeletePoster(long id , long userId)
        {
            int st = rep.delPoster(id);
            if (st == 1)
            {
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            var q = (from i in database.Tbl_RadFBUsers where i.RadFbUserID == userId select i).SingleOrDefault();
            if (q.fk_userTypeID == 1)
            {
                return RedirectToAction("showRealClient" , new { id = userId });
            }
            else
            {
                return RedirectToAction("showLegalClient", new { id = userId });
            }
            
        }

        public IActionResult DeleteBook(long id, long userId)
        {
            int st = rep.delBook(id);
            if (st == 1)
            {
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            var q = (from i in database.Tbl_RadFBUsers where i.RadFbUserID == userId select i).SingleOrDefault();
            if (q.fk_userTypeID == 1)
            {
                return RedirectToAction("showRealClient", new { id = userId });
            }
            else
            {
                return RedirectToAction("showLegalClient", new { id = userId });
            }
        }

        public IActionResult DeleteArticle(long id , long userId)
        {
            int st = rep.delArticle(id);
            if (st == 1)
            {
                TempData["seccessDelete"] = "حذف با موفقیت انجام شد";
            }
            else
            {
                TempData["FailedDelete"] = "عملیات حذف با شکست مواجه شد";
            }
            var q = (from i in database.Tbl_RadFBUsers where i.RadFbUserID == userId select i).SingleOrDefault();
            if (q.fk_userTypeID == 1)
            {
                return RedirectToAction("showRealClient", new { id = userId });
            }
            else
            {
                return RedirectToAction("showLegalClient", new { id = userId });
            }
        }


    }
}
