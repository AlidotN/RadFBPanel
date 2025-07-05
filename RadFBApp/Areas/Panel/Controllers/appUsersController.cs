using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Models.ViewModels.Admin;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;
using Microsoft.AspNetCore.Authorization;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class appUsersController : Controller
    {
        ApplicationDbContext database = new ApplicationDbContext();
        repRadfbUsers rep = new repRadfbUsers();


        public IActionResult Index()
        {
            var q = (from i in database.Tbl_RadFBUsers
                     join a in database.Tbl_RealCient on i.RadFbUserID equals a.fk_UserID
                     into ai
                     from aiResult in ai.DefaultIfEmpty()

                     join b in database.Tbl_legalClient on i.RadFbUserID equals b.fk_UserID
                     into ib
                     from ibResult in ib.DefaultIfEmpty()
                     join c in database.Tbl_userType on i.fk_userTypeID equals c.userTypeID
                     into ic
                     from icResult in ic.DefaultIfEmpty()

                     where i.DeleteStatus == false && (ibResult.legalClientID != null || aiResult.RealClientID != null)
                     select new { i.RadFbUserID, i.email, i.lastSeenDate, i.phoneNumber, i.UserPic, i.userStatus, aiResult.FirstName, aiResult.LastName, ibResult.CEOName, icResult.userTypeID, icResult.PrUserTypeName }).ToList();

            List<VmRadfbUsers> users = new List<VmRadfbUsers>();

            foreach (var item in q)
            {
                string fullName = "";
                if (item.userTypeID == 1)
                {
                    fullName = item.FirstName + " " + item.LastName;
                }
                else
                {
                    fullName = item.CEOName;
                }

                VmRadfbUsers vm = new VmRadfbUsers
                {
                    RadFbUserID = item.RadFbUserID,
                    UserPic = item.UserPic,
                    fullName = fullName,
                    phoneNumber = item.phoneNumber,
                    email = item.email,
                    userType = item.PrUserTypeName,
                    UserTypeID = item.userTypeID,
                    lastSeenDate = item.lastSeenDate,
                    userStatus = item.userStatus.ToString()
                };
                users.Add(vm);
            }

            ViewBag.userCount = q.Count();

            return View(users);
        }


        public IActionResult showRealClient(long id)
        {
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
            ViewBag.books = rep.booksCount(id).ToString();
            ViewBag.articles = rep.articlesCount(id).ToString();
            ViewBag.posters = rep.PostersCount(id).ToString();

            return View(vm);
        }

        public IActionResult showLegalClient(long id)
        {
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;


            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
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
                    TempData["seccessDelete"] = Texts.UserBanned;
                }
                else
                {
                    TempData["seccessDelete"] = Texts.UserActived;
                }


            }
            else
            {
                TempData["FailedDelete"] = Texts.OperationFailed;
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
                TempData["seccessDelete"] = Texts.UserActived;
            }
            else
            {
                TempData["FailedDelete"] = Texts.OperationFailed;
            }
            return RedirectToAction("inactiveUsers");
        }



        public IActionResult ShowAllMessages()
        {
            var q = rep.messagesList();

            ViewBag.MessagesCount = q.Count();

            return View(q);
        }


        public IActionResult ShowDetailMessages(long id)
        {
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
                TempData["seccessDelete"] = Texts.DeleteSuccess;
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
            }

            return RedirectToAction("ShowDetailMessages", new { id = userId });
        }


        public IActionResult inactiveUsers()
        {
            var q = rep.inactiveUsers();
            ViewBag.Count = q.Count();
            return View(q);
        }
    }
}
