using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using radFB.db;
using radFB.Repository;

namespace radFB.Controllers
{
    [Authorize]
    public class GroupController : Controller
    {

        ApplicationDbContext database = new ApplicationDbContext();
        Repository.repGroup rep = new Repository.repGroup();

        public bool check()
        {
            radFB.Classes.publicFunctions publicFunctions = new radFB.Classes.publicFunctions();
            bool roleID = true;
            if (publicFunctions.groupsMenu(User.Identity.Name) != true)
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
            var q = rep.groupList();
            ViewBag.count = q.Count();

            return View(q);
        }


        public IActionResult DeleteGroup(long id)
        {
            int st = rep.DelGroup(id);
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


        public IActionResult DeleteAllGroups(string deleteItems)
        {
            int st = rep.DelAllGroups(deleteItems);
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


        public IActionResult groupInfo(long id)
        {
            if (check() == false)
            {
                return RedirectToAction("Index", "Account");
            }
            var q = rep.gropInformation(id);
            if (q == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.memberCount = rep.gropMembersInformation(id).Count;
                ViewBag.messageCount = rep.gropMessageInformation(id).Count;
                return View(q);
            }
        }






        public IActionResult DeleteMember(long id, long userId)
        {
            if (rep.deleteMember(id, userId) == true)
            {
                TempData["seccessDelete"] = "کاربر مورد نظر از گروه حذف شد";
                return RedirectToAction("groupInfo", new { id = id });
            }
            else
            {
                TempData["FailedDelete"] = " ناموفق";
                return RedirectToAction("groupInfo", new { id = id });
            }

        }

        public IActionResult DeleteMessage(long id, long messageID)
        {
            if (rep.deletemessage(id, messageID) == true)
            {
                TempData["seccessDelete"] = "پیام با موفقیت از گروه حذف شد";
                return RedirectToAction("groupInfo", new { id = id });
            }
            else
            {
                TempData["FailedDelete"] = " ناموفق";
                return RedirectToAction("groupInfo", new { id = id });
            }
        }



    }
}
