using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using RadFBApp.Areas.Panel.Repository;
using RadFBApp.Areas.Panel.Resources;

namespace RadFBApp.Areas.Panel.Controllers
{
    [Area("Panel")]
    [Authorize]
    public class GroupController : Controller
    {

        repGroup rep = new repGroup();

        public IActionResult Index()
        {
            var q = rep.groupList();
            ViewBag.count = q.Count();

            return View(q);
        }


        public IActionResult DeleteGroup(long id)
        {
            int st = rep.DelGroup(id);
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


        public IActionResult DeleteAllGroups(string deleteItems)
        {
            int st = rep.DelAllGroups(deleteItems);
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


        public IActionResult groupInfo(long id)
        {
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
                TempData["seccessDelete"] = Texts.UserDeletedFromGroup;
                return RedirectToAction("groupInfo", new { id = id });
            }
            else
            {
                TempData["FailedDelete"] = Texts.OperationFailed;
                return RedirectToAction("groupInfo", new { id = id });
            }

        }

        public IActionResult DeleteMessage(long id, long messageID)
        {
            if (rep.deletemessage(id, messageID) == true)
            {
                TempData["seccessDelete"] = Texts.DeleteSuccess;
                return RedirectToAction("groupInfo", new { id = id });
            }
            else
            {
                TempData["FailedDelete"] = Texts.DeleteFaild;
                return RedirectToAction("groupInfo", new { id = id });
            }
        }



    }
}
