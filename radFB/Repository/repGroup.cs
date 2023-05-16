using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using radFB.db;
using radFB.ViewModels;

namespace radFB.Repository
{
    public class repGroup
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //name and family of grops member or groups creator
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

        //numbers of group members
        public int memberCount(long GroupID)
        {
            int count = (from i in db.Tbl_memberOfGroup where i.fk_groupID == GroupID select i).Count();
            return count;
        }

        //nembers of group messages
        public long messagesCount(long GroupID)
        {
            long count = (from i in db.Tbl_groupMessages where i.fk_groupID == GroupID select i).Count();
            return count;
        }

        //groups lists
        public List<VmGroup> groupList()
        {
            var q = (from i in db.Tbl_group where i.DeleteStatus == false select i).OrderByDescending(c=>c.groupID).ToList();

            List<VmGroup> GList = new List<VmGroup>();

            foreach (var item in q)
            {

                VmGroup vm = new VmGroup();
                vm.groupID = item.groupID;
                vm.GroupTitle = item.groupTitle;
                vm.creatorUser = fullName(item.fk_creatorUserID);
                vm.messagesCount = messagesCount(item.groupID);
                vm.groupsMember = memberCount(item.groupID);


                GList.Add(vm);
            }

            return GList;
        }


        //delete group
        public int DelGroup(long? id)
        {
            var q = (from i in db.Tbl_group where i.groupID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_group.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected groups
        public int DelAllGroups(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_group where i.groupID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_group.Update(q);
                    }
                    db.SaveChanges();
                    return 1;
                }
                catch (Exception)
                {

                    return 0;
                }
            }
            else
            {
                return 0;
            }

        }


        //information of a group
        public dynamic gropInformation(long id)
        {     
                var q = (from i in db.Tbl_group
                         join b in db.Tbl_RadFBUsers on i.fk_creatorUserID equals b.RadFbUserID
                         where i.groupID == id
                         select new { b.phoneNumber, i.groupID, i.groupTitle, i.description, i.fk_creatorUserID }).FirstOrDefault();

                VmGroupInfo vm = new VmGroupInfo();
                vm.groupID = q.groupID;
                vm.GroupTitle = q.groupTitle;
                vm.groupDescription = q.description;
                vm.phoneNumber = q.phoneNumber;
                vm.creatorUser = fullName(q.fk_creatorUserID);

                return vm;
        }

        //number of messages group
        public long GroupUserMessagesCount(long groupID, long memberID)
        {
            long q = (from i in db.Tbl_groupMessages where i.fk_groupID == groupID && i.fk_senderUserID == memberID select i).Count();
            return q;
        }



        //member phone number
        public string phoneNumber(long id)
        {
            var q = (from i in db.Tbl_RadFBUsers where i.RadFbUserID == id select i).FirstOrDefault();
            return q.phoneNumber.ToString();
        }


        //member userType
        public string userType(long UserId)
        {
            string q = (from i in db.Tbl_RadFBUsers
                        join b in db.Tbl_userType on i.fk_userTypeID equals b.userTypeID
                        where i.RadFbUserID == UserId
                        select b.PrUserTypeName).FirstOrDefault();

            return q.ToString();
        }


        //information about group members
        public List<VmGroupMembersInfo> gropMembersInformation(long id)
        {
                var q = (from i in db.Tbl_group
                         join b in db.Tbl_memberOfGroup on i.groupID equals b.fk_groupID
                         where i.groupID == id
                         select new { b.fk_UserID }).ToList();

                List<VmGroupMembersInfo> list = new List<VmGroupMembersInfo>();

                foreach (var item in q)
                {
                    VmGroupMembersInfo vm = new VmGroupMembersInfo();
                    vm.GroupID = id;
                    vm.memberID = item.fk_UserID;
                    vm.memberName = fullName(item.fk_UserID);
                    vm.memberPhoneNumber = phoneNumber(item.fk_UserID);
                    vm.memberMessagesCount = GroupUserMessagesCount(id, item.fk_UserID);

                    list.Add(vm);
                }
                return list;
        }



        public static string toEnglishNumber(string input)
        {
            string EnglishNumbers = "";
            for (int i = 0; i < input.Length; i++)
            {
                if (Char.IsDigit(input[i]))
                {
                    EnglishNumbers += char.GetNumericValue(input, i);
                }
                else
                {
                    EnglishNumbers += input[i].ToString();
                }
            }
            return EnglishNumbers;
        }


        //convert to shamsi Date
        public string ShamsiDateFormat(string Date)
        {
            if (Date != null && Date != "")
            {
                string[] userDateParts = Date.Split('/');
                int Year = int.Parse(toEnglishNumber(userDateParts[0]));
                int Month = int.Parse(toEnglishNumber(userDateParts[1]));
                int Day = int.Parse(toEnglishNumber(userDateParts[2]));

                PersianCalendar pc = new PersianCalendar();
                DateTime dt = new DateTime(Year, Month, Day, pc);

                return dt.ToString();
                //return Year.ToString("0000/") + Month.ToString("00/") + Day.ToString("00");
            }
            else
            {
                return "";
            }


        }
        //information about group messages
        public List<VmGroupMessagesInfo> gropMessageInformation(long id)
        {
            var q = (from i in db.Tbl_group
                         join b in db.Tbl_groupMessages on i.groupID equals b.fk_groupID
                         where i.groupID == id
                         select new { b.groupMessagesID, b.fk_senderUserID, b.groupMessageText, b.groupMessageDate, b.groupMessageTime }).OrderByDescending(c=> DateTime.Parse(ShamsiDateFormat(c.groupMessageDate)).Date).ToList();

                List<VmGroupMessagesInfo> list = new List<VmGroupMessagesInfo>();

                foreach (var item in q)
                {
                    VmGroupMessagesInfo vm = new VmGroupMessagesInfo();
                    vm.groupId = id;
                    vm.messageId = item.groupMessagesID;
                    vm.senderName = fullName(item.fk_senderUserID);
                    vm.date = item.groupMessageDate;
                    vm.time = item.groupMessageTime;
                    vm.messageText = item.groupMessageText;

                    list.Add(vm);
                }
                return list;
        }

        //delete member from group
        public bool deleteMember(long id, long userId)
        {
            var q = (from i in db.Tbl_memberOfGroup where i.fk_groupID == id && i.fk_UserID == userId select i).FirstOrDefault();

            if (q != null)
            {
                db.Tbl_memberOfGroup.Remove(q);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }


        //delete message from group
        public bool deletemessage(long id, long messageId)
        {
            var q = (from i in db.Tbl_groupMessages where i.fk_groupID == id && i.groupMessagesID == messageId select i).FirstOrDefault();

            if (q != null)
            {
                db.Tbl_groupMessages.Remove(q);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }

    }
}
