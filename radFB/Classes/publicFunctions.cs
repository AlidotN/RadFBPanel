using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using radFB.db;
using radFB.Repository;
using radFB.ViewModels;

namespace radFB.Classes
{
    public class publicFunctions
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public string fileType(int id)
        {
            string file = (from i in db.postType where i.PostTypeID == id select i.FaPostTypeTitle).FirstOrDefault();

            return file.ToString();
        }

        public string adminName(string email)
        {
            string name = "";
            var q = (from i in db.Users where i.Email == email select i).SingleOrDefault();
            if (q != null)
            {
                name = q.FullName;
            }
            return name;
        }

        public string countryName(int id)
        {
            string q = (from i in db.Tbl_countries where i.countryID == id select i.countryName).FirstOrDefault();

            return q.ToString();
        }

        public string genderyName(int id)
        {
            string q = (from i in db.Tbl_gender where i.GenderID == id select i.PrGenderTitle).FirstOrDefault();

            return q.ToString();
        }

        public string gradeName(long id)
        {
            string q = (from i in db.Tbl_grade where i.gradeID == id select i.PrGradeTitle).FirstOrDefault();
            if (q != null)
            {
                return q.ToString();
            }
            else
            {
                return "";
            }


        }

        public string majorName(long id)
        {
            string q = (from i in db.Tbl_major where i.majorID == id select i.PrMajorTitle).FirstOrDefault();

            if (q != null)
            {
                return q.ToString();
            }
            else
            {
                return "";
            }
        }

        public string phoneNumber(long id)
        {
            string tell = (from i in db.Tbl_RadFBUsers where i.RadFbUserID == id select i.phoneNumber).SingleOrDefault().ToString();
            return tell;
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



        public string postTitle(long id)
        {
            string t = "";
            var q = (from i in db.Tbl_post where i.postID == id select i).SingleOrDefault();
            t = q.postTitle;
            return t;
        }

        public string fileAddress(long id)
        {
            string t = "";
            var q = (from i in db.Tbl_post
                     join f in db.Tbl_PostFile on i.postID equals f.fk_postID
                     where i.postID == id select new { f.FileAddress}).SingleOrDefault();
            t = q.FileAddress.ToString();
            return t;
        }

        //آگهی های پر بازدید
        public List<string> adv()
        {
            List<string> list = new List<string>();
            var q = (from i in db.Tbl_post
                     join b in db.Tbl_postSeen on i.postID equals b.fk_postID
                     where i.fk_PostTypeID == 4
                     select new { i.postID})
                     .GroupBy(x => x.postID) //group all rows with same product id together
                     .OrderByDescending(g => g.Count()) // move products with highest views to the top
                    .Take(3) // take top 5
                    .Select(x => x.Key) // get id of products
                     .ToList();



            //var topAdvs = db.Tbl_post // table with products information
            //    .Where(x => q.Contains(x.postID));
            foreach (var item in q)
            {

                list.Add(postTitle(item));
            }
            return list;
        }


        //سوال های پر بازدید
        public List<string> question()
        {
            List<string> list = new List<string>();
            var q = (from i in db.Tbl_post
                     join b in db.Tbl_postSeen on i.postID equals b.fk_postID
                     where i.fk_PostTypeID == 6
                     select new { i.postID })
                     .GroupBy(x => x.postID) //group all rows with same product id together
                     .OrderByDescending(g => g.Count()) // move products with highest views to the top
                    .Take(3) // take top 5
                    .Select(x => x.Key) // get id of products
                     .ToList();



            //var topAdvs = db.Tbl_post // table with products information
            //    .Where(x => q.Contains(x.postID));
            foreach (var item in q)
            {

                list.Add(postTitle(item));
            }
            return list;
        }

        //سوال های پر بازدید
        public List<VmMostVisited> questionnair()
        {
            List<VmMostVisited> list = new List<VmMostVisited>();
            var q = (from i in db.Tbl_post
                     join b in db.Tbl_postSeen on i.postID equals b.fk_postID
                     where i.fk_PostTypeID == 5
                     select new { i.postID })
                     .GroupBy(x => x.postID) //group all rows with same product id together
                     .OrderByDescending(g => g.Count()) // move products with highest views to the top
                    .Take(3) // take top 5
                    .Select(x => x.Key) // get id of products
                     .ToList();



            //var topAdvs = db.Tbl_post // table with products information
            //    .Where(x => q.Contains(x.postID));
            foreach (var item in q)
            {
                VmMostVisited vm = new VmMostVisited();
                vm.Title = postTitle(item);
                vm.Address = fileAddress(item);
                list.Add(vm);
            }
            return list;
        }


        //پروفایل های پر طرفدار
        public List<string> users()
        {
            List<string> list = new List<string>();
            var q = (from i in db.Tbl_RadFBUsers
                     join b in db.Tbl_followers on i.RadFbUserID equals b.fk_UserID
                     select new { i.RadFbUserID })
                     .GroupBy(x => x.RadFbUserID) //group all rows with same product id together
                     .OrderByDescending(g => g.Count()) // move products with highest views to the top
                    .Take(3) // take top 5
                    .Select(x => x.Key) // get id of products
                     .ToList();



            //var topAdvs = db.Tbl_post // table with products information
            //    .Where(x => q.Contains(x.postID));
            foreach (var item in q)
            {

                list.Add(fullName(item));
            }
            return list;
        }

        //menu ha

        public bool settingMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.setting == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool UsersMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.users == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool postMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.posts == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool groupsMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.groups == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool financialMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.financialDepartment == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool templateMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.templates == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool reportMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.reports == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool connectUserMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.connectUsers == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool frequentlyMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.frequently == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool adminPanelMenu(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.usersAdminPanel == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteInformations(string username)
        {
            var q = (from i in db.Tbl_userAccess
                     join u in db.Users on i.userAccessID equals u.Fk_userAccessID
                     where i.deleteInformation == true && u.UserName == username
                     select u.Email).Count();
            if (q > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
