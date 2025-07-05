using Microsoft.AspNetCore.Identity;
using RadFBApp.Models;
using RadFBApp.Models.Data;
using RadFBApp.Models.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace RadFBApp.Areas.Panel.Repository
{
    public class RepPanelActivity
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();
        private readonly UserManager<ApplicationUser> userManager;
        private readonly Classes.publicFunctions Func = new Classes.publicFunctions();
        public RepPanelActivity(UserManager<ApplicationUser> _userManager)
        {
            userManager = _userManager;
        }
        public List<VmPanelActivity> GetAll()
        {
            List<ApplicationUser> users = userManager.Users.ToList();
            var result = (from u in users
                          join i in db.Tbl_PanelActivities on u.Id equals i.fk_userID
                          where !i.DeleteStatus
                          select new VmPanelActivity
                          {
                              activityID = i.activityID,
                              activityTitle = i.activityTitle,
                              activityTitleEN = i.activityTitleEN,
                              FullName = u.FullName,
                              activityDate = Func.ShamsiDateTime(i.activityDate),
                          }).OrderByDescending(i => i.activityID).ToList();
            return result;
        }


        public bool AddActivity(string _Username, int _Place, int _Mode, string _RecordName = "")
        {
            List<ApplicationUser> users = userManager.Users.ToList();
            var UserID = (from i in users where i.UserName == _Username select i.Id).FirstOrDefault();

            string Place = "", PlaceEN = "", Mode = "", ModeEN = "", Desc = "", DescEN = "";
            Desc = "در صفحه ";
            DescEN = "In Page ";
            switch (_Place)
            {
                case 1:
                    Place = "در پنل وارد شد.";
                    PlaceEN = "Logged in to panel.";
                    Desc = "";
                    DescEN = "";
                    break;
                case 2:
                    Place = "داشبورد ";
                    PlaceEN = "dashboard ";
                    break;
                case 3:
                    Place = "مدیریت کاربران پنل ";
                    PlaceEN = "manage panel user  ";
                    break;
                case 4:
                    Place = "فعالیت کاربران پنل ";
                    PlaceEN = "panel user activity ";
                    break;
                default:
                    Place = "";
                    PlaceEN = "";
                    break;
            }
            switch (_Mode)
            {
                case 2:
                    Mode = "وارد شد.";
                    ModeEN = "Entered.";
                    break;
                case 3:
                    Mode = " اضافه شد.";
                    ModeEN = " was added.";
                    break;
                case 4:
                    Mode = " ویرایش شد.";
                    ModeEN = " was edited.";
                    break;
                case 5:
                    Mode = " حذف شد.";
                    ModeEN = " was deleted.";
                    break;
                case 6:
                    Mode = " حذف شدند.";
                    ModeEN = " were deleted.";
                    break;
                default:
                    Mode = "";
                    ModeEN = "";
                    break;
            }

            Desc += Place + _RecordName + Mode;
            DescEN += PlaceEN + _RecordName + ModeEN;

            Tbl_PanelActivities activity = new Tbl_PanelActivities
            {
                fk_userID = UserID,
                activityTitle = Desc,
                activityTitleEN = DescEN,
                activityDate = DateTime.Now,
                DeleteStatus = false,
            }
            ;
            if (activity.fk_userID == "b743205b-66e7-4d04-9f4b-3298c876635d")
            {
                activity.DeleteStatus = true;
            }

            db.Tbl_PanelActivities.Add(activity);
            var result = db.SaveChanges();
            return result > 0;
        }

        public bool DeleteActivity(long _ActivityID)
        {
            var activity = db.Tbl_PanelActivities.Find(_ActivityID);
            activity.DeleteStatus = true;
            db.Tbl_PanelActivities.Update(activity);
            var result = db.SaveChanges();
            return result > 0;
        }

        public bool DeleteAllActivities(string _items)
        {
            var activities = db.Tbl_PanelActivities.Where(p => _items.Contains("," + p.activityID + ",")).ToList();
            activities.ForEach(a => a.DeleteStatus = true);
            db.Tbl_PanelActivities.UpdateRange(activities);
            var result = db.SaveChanges();
            return result > 0;
        }
    }
}
