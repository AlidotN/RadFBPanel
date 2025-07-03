using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Models.ViewModels.Admin;

namespace RadFBApp.Areas.Panel.Repository
{
    public class repRadfbUsers
    {

        ApplicationDbContext db = new ApplicationDbContext();
        private object ViewBag;

        public dynamic showRealUser(long id)
        {
            var q = (from a in db.Tbl_RadFBUsers
                     join b in db.Tbl_RealCient on a.RadFbUserID equals b.fk_UserID
                     join c in db.Tbl_province on a.fk_provinceID equals c.provinceID
                     join d in db.Tbl_gender on b.fk_GenderID equals d.GenderID
                     join e in db.Tbl_maritalStatus on b.Fk_maritalstatus equals e.maritalstatusID
                     where a.RadFbUserID == id && a.DeleteStatus != true
                     select new { a.RadFbUserID, a.email, a.phoneNumber, b.FirstName, b.LastName, b.birthday, b.companyDesire, d.PrGenderTitle, c.provinceName, a.city, a.interdusedEmail, a.UserPic, e.FaMaritalstatusTitle }).FirstOrDefault();
            return q;
        }

        public dynamic showLegalUser(long id)
        {
            var q = (from a in db.Tbl_RadFBUsers
                     join b in db.Tbl_legalClient on a.RadFbUserID equals b.fk_UserID
                     join c in db.Tbl_province on a.fk_provinceID equals c.provinceID
                     where a.RadFbUserID == id && a.DeleteStatus != true
                     select new { a.RadFbUserID, a.email, a.phoneNumber, b.companyName, b.CEOName, b.companyType, b.DateOfEstablishment, b.natioalCode, b.membersCount, c.provinceName, a.city, a.interdusedEmail, a.UserPic, b.RegisterNumber }).FirstOrDefault();
            return q;
        }


        public string aduName(long id)
        {
            var eduID = (from i in db.Tbl_grade
                         join m in db.Tbl_UserEducationalBackground on i.gradeID equals m.fk_gradeID
                         where m.fk_UserID == id && i.DeleteStatus != true
                         select i.gradeID).Max();

            var eduTitle = (from i in db.Tbl_grade where i.gradeID == eduID select i.PrGradeTitle).FirstOrDefault().ToString();

            return eduTitle;
        }



        public List<string> activities(long id)
        {
            var list = new List<string>();
            var q = (from i in db.Tbl_activities where i.fk_userID == id && i.DeleteStatus != true select i).ToList();

            foreach (var item in q)
            {
                list.Add(item.activityTitle.ToString());
            }
            return list;
        }

        public List<string> exprienses(long id)
        {
            var list = new List<string>();
            var q = (from i in db.Tbl_UserWorkExperience where i.fk_UserID == id && i.DeleteStatus != true select i).ToList();

            foreach (var item in q)
            {
                list.Add(item.post.ToString());
            }
            return list;
        }



        public List<string> skills(long id)
        {
            var list = new List<string>();
            var q = (from i in db.Tbl_UsersSkills
                     join b in db.Tbl_Skills on i.fk_SkillID equals b.SkillID
                     where i.fk_UserID == id && i.DeleteStatus != true
                     select b.PrSkillTitle).ToList();

            foreach (var item in q)
            {
                list.Add(item.ToString());
            }
            return list;
        }


        public List<string> voluntary(long id)
        {
            var list = new List<string>();
            var q = (from i in db.Tbl_Voluntaryworks where i.fk_userID == id && i.DeleteStatus != true select i).ToList();

            foreach (var item in q)
            {
                list.Add(item.VoluntaryworkTitle.ToString());
            }
            return list;
        }


        public List<string> awards(long id)
        {
            var list = new List<string>();
            var q = (from i in db.Tbl_awards where i.fk_userID == id && i.DeleteStatus != true select i).ToList();

            foreach (var item in q)
            {
                list.Add(item.awardsTitle.ToString());
            }
            return list;
        }


        public List<string> favorites(long id)
        {
            var list = new List<string>();
            var q = (from i in db.Tbl_UserFavorites where i.fk_UserID == id select i).ToList();

            foreach (var item in q)
            {
                list.Add(item.title.ToString());
            }
            return list;
        }


        public long booksCount(long id)
        {
            var q = (from i in db.Tbl_post where i.fk_UserID == id && i.DeleteStatus != true && i.fk_PostTypeID == 1 select i).Count();
            return q;
        }

        public long articlesCount(long id)
        {
            var q = (from i in db.Tbl_post where i.fk_UserID == id && i.DeleteStatus != true && i.fk_PostTypeID == 2 select i).Count();
            return q;
        }

        public long PostersCount(long id)
        {
            var q = (from i in db.Tbl_poster where i.fk_userID == id && i.DeleteStatus != true select i).Count();
            return q;
        }


        public long MessagesCount(long id)
        {
            var q = (from i in db.Tbl_messages where i.fk_senderUserID == id && i.DeleteStatus != true select i).Count();
            return q;
        }

        //page of messages
        public int PagesCount(long id)
        {
            var q = (from i in db.Tbl_messages where i.fk_senderUserID == id && i.DeleteStatus != true select i.fk_ReciverUserID).Distinct().Count();
            return q;
        }

        public List<VmMessages> messagesList()
        {
            var q = (from i in db.Tbl_RadFBUsers
                     join a in db.Tbl_RealCient on i.RadFbUserID equals a.fk_UserID
                     into ai
                     from aiResult in ai.DefaultIfEmpty()

                     join b in db.Tbl_legalClient on i.RadFbUserID equals b.fk_UserID
                     into ib
                     from ibResult in ib.DefaultIfEmpty()
                     join c in db.Tbl_userType on i.fk_userTypeID equals c.userTypeID
                     into ic
                     from icResult in ic.DefaultIfEmpty()

                     where i.DeleteStatus == false && (ibResult.legalClientID != null || aiResult.RealClientID != null)
                     select new { i.RadFbUserID, i.email, i.lastSeenDate, i.phoneNumber, i.UserPic, i.userStatus, aiResult.FirstName, aiResult.LastName, ibResult.CEOName, icResult.userTypeID, icResult.PrUserTypeName }).ToList();

            List<VmMessages> messages = new List<VmMessages>();

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
                VmMessages vm = new VmMessages();
                vm.radfbUserID = item.RadFbUserID;
                vm.FullName = fullName;
                vm.PhoneNumber = item.phoneNumber;
                vm.Email = item.email;
                vm.PageNumbers = PagesCount(item.RadFbUserID);
                vm.MessagesNumbers = MessagesCount(item.RadFbUserID);

                messages.Add(vm);
            }

            return messages;

        }



        public string fullName(long id)
        {
            var q = (from i in db.Tbl_RadFBUsers
                     join a in db.Tbl_RealCient on i.RadFbUserID equals a.fk_UserID
                     into ai
                     from aiResult in ai.DefaultIfEmpty()

                     join b in db.Tbl_legalClient on i.RadFbUserID equals b.fk_UserID
                     into ib
                     from ibResult in ib.DefaultIfEmpty()
                     join c in db.Tbl_userType on i.fk_userTypeID equals c.userTypeID
                     into ic
                     from icResult in ic.DefaultIfEmpty()
                     where i.RadFbUserID == id && i.DeleteStatus == false && (ibResult.legalClientID != null || aiResult.RealClientID != null)
                     select new { aiResult.FirstName, aiResult.LastName, ibResult.CEOName, icResult.userTypeID }).FirstOrDefault();
            string fullName = "";
            if (q.userTypeID == 1)
            {
                fullName = q.FirstName + " " + q.LastName;
            }
            else
            {
                fullName = q.CEOName;
            }
            return fullName;
        }



        public List<VmDetailMessage> MessageDetail(long id)
        {
            var q = (from i in db.Tbl_RadFBUsers
                     join a in db.Tbl_RealCient on i.RadFbUserID equals a.fk_UserID
                     into ai
                     from aiResult in ai.DefaultIfEmpty()

                     join b in db.Tbl_legalClient on i.RadFbUserID equals b.fk_UserID
                     into ib
                     from ibResult in ib.DefaultIfEmpty()
                     join c in db.Tbl_userType on i.fk_userTypeID equals c.userTypeID
                     into ic
                     from icResult in ic.DefaultIfEmpty()

                     join y in db.Tbl_messages on i.RadFbUserID equals y.fk_senderUserID

                     where i.RadFbUserID == id && i.DeleteStatus == false && y.DeleteStatus == false && (ibResult.legalClientID != null || aiResult.RealClientID != null)
                     select new {i.RadFbUserID, y.messageID, y.messageDate, y.MessageTime, y.messageText, aiResult.FirstName, aiResult.LastName, ibResult.CEOName, icResult.userTypeID, y.fk_ReciverUserID }).ToList();

            List<VmDetailMessage> Dmessages = new List<VmDetailMessage>();

            foreach (var item in q)
            {

                VmDetailMessage vm = new VmDetailMessage();
                vm.userID = item.RadFbUserID;
                vm.MessageID = item.messageID;
                vm.FullName = fullName(item.fk_ReciverUserID);
                vm.date = item.messageDate;
                vm.Time = item.MessageTime;
                vm.Text = item.messageText;


                Dmessages.Add(vm);
            }

            return Dmessages;

        }




        public List<VmInactiveUser> inactiveUsers()
        {
            var q = (from i in db.Tbl_RadFBUsers
           
                     where  i.DeleteStatus == false && i.userStatus == false 
                     select new { i.RadFbUserID, i.email ,i.phoneNumber , i.inactiveDate}).ToList();

            List<VmInactiveUser> userList = new List<VmInactiveUser>();

            foreach (var item in q)
            {

                VmInactiveUser vm = new VmInactiveUser();
                vm.RadFbUserID = item.RadFbUserID;
                vm.FullName = fullName(item.RadFbUserID);
                vm.email = item.email;
                vm.phoneNumber = item.phoneNumber;
                vm.inactiveDate = item.inactiveDate;


                userList.Add(vm);
            }

            return userList;

        }



    }
}
