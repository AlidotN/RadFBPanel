using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Models.ViewModels.Admin;

namespace RadFBApp.Areas.Panel.Repository
{
    public class repPoster
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //post list
        public List<VmPoster> PosterList()
        {
            var q = (from i in db.Tbl_poster where i.DeleteStatus == false select i).ToList();

            List<VmPoster> list = new List<VmPoster>();

            foreach (var item in q)
            {
                VmPoster vm = new VmPoster();

                vm.posterID = item.posterID;
                vm.fk_userID = item.fk_userID;
                vm.posterAddress = item.posterAddress;
                vm.posterPhoneNumber = item.posterPhoneNumber;
                vm.posterStatus = item.posterStatus;
                vm.posterContacts = item.posterContacts;
                vm.posterType = item.posterType;
                vm.posterTitle = item.posterTitle;

                list.Add(vm);
            }

            return list;
        }

        //find one poster
        public dynamic poster(long id)
        {
            var q = (from i in db.Tbl_poster where i.posterID == id && i.DeleteStatus == false select i).FirstOrDefault();

            return q;
        }

        //template name
        public string templateTitle(int id)
        {
            string q = (from i in db.Tbl_posterTemplate where i.posterTemplateID == id select i.posterName).ToString();

            return q;
        }

        //edit poster
        public bool edit(long id, bool st)
        {
            var q = poster(id);
            if (q != null)
            {

                q.posterStatus = st;
                db.Tbl_poster.Update(q);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }



        //delete poster
        public int DelPoster(long? id)
        {
            var q = (from i in db.Tbl_poster where i.posterID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_poster.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected posts
        public int DelAllPosters(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_poster where i.posterID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_poster.Update(q);
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


        //search
        public List<VmPoster> searchResult(VmSearchPoster model)
        {

            if (model != null)
            {
                var q = (from i in db.Tbl_poster
                         join o in db.Tbl_countries on i.fk_countryID equals o.countryID
                         join g in db.Tbl_gender on i.fk_genderID equals g.GenderID
                         join r in db.Tbl_RadFBUsers on i.fk_userID equals r.RadFbUserID

                         join a in db.Tbl_RealCient on i.fk_userID equals a.fk_UserID
                         into ai
                         from aiResult in ai.DefaultIfEmpty()

                         join b in db.Tbl_legalClient on i.fk_userID equals b.fk_UserID
                         into ib
                         from ibResult in ib.DefaultIfEmpty()

                         join c in db.Tbl_userType on r.fk_userTypeID equals c.userTypeID
                         into ic
                         from icResult in ic.DefaultIfEmpty()

                         where i.DeleteStatus == false
                         && (ibResult.legalClientID != null || aiResult.RealClientID != null)

                         select new { icResult.userTypeID, ibResult.CEOName, aiResult.FirstName, aiResult.LastName, g.PrGenderTitle, o.countryName, i.posterTitle, i.posterSubject, i.posterContacts, i.posterAddress, i.posterDegree, i.posterPhoneNumber, i.posterPrerequisites, i.posterOtherThings, i.posterCity, i.OnlineOflineStatus, i.PosterCapacity, i.posterCoust, i.posterType, i.daysOfWeek, i.timesOfDay, i.posterStatus, i.fk_userID, i.posterID, i.posterStartDate, i.posterEndDate }).ToList();

                if (q != null)
                {
                    if (model.user != null && model.user != "")
                    {
                      
                       q = q.Where(c => ((c.FirstName != null && c.LastName != null) && (c.FirstName + c.LastName).Contains(model.user, StringComparison.CurrentCultureIgnoreCase))
                        || (c.CEOName != null && c.CEOName.Contains(model.user, StringComparison.CurrentCultureIgnoreCase))).ToList();

                    }

                    if (model.gender != "همه")
                    {
                       
                        q = q.Where(c => c.PrGenderTitle ==model.gender).ToList();
                    }

                    if (model.country != null && model.country != "")
                    {
                       q =  q.Where(c => c.countryName.Contains(model.country)).ToList();
                    }

                    if (model.country != null && model.country != "")
                    {
                       q =  q.Where(c => c.posterTitle.Contains(model.posterTitle)).ToList();
                    }

                    if (model.country != null && model.country != "")
                    {
                       q = q.Where(c => c.posterTitle.Contains(model.posterTitle)).ToList();
                    }

                    if (model.posterSubject != null && model.posterSubject != "")
                    {
                       q = q.Where(c => c.posterSubject.Contains(model.posterSubject)).ToList();
                    }

                    if (model.posterContacts != null && model.posterContacts != "")
                    {
                       q = q.Where(c => c.posterContacts.Contains(model.posterContacts)).ToList();
                    }

                    if (model.posterAddress != null && model.posterAddress != "")
                    {
                       q = q.Where(c => c.posterAddress.Contains(model.posterAddress)).ToList();
                    }

                    if (model.posterPhoneNumber != null && model.posterPhoneNumber != "")
                    {
                       q = q.Where(c => c.posterPhoneNumber.Contains(model.posterPhoneNumber)).ToList();
                    }
                    if (model.posterDegree != null && model.posterDegree != "")
                    {
                       q = q.Where(c => c.posterDegree.Contains(model.posterDegree)).ToList();
                    }
                    if (model.posterPrerequisites != null && model.posterPrerequisites != "")
                    {
                       q = q.Where(c => c.posterPrerequisites.Contains(model.posterPrerequisites)).ToList();
                    }
                    if (model.posterOtherThings != null && model.posterOtherThings != "")
                    {
                       q = q.Where(c => c.posterOtherThings.Contains(model.posterOtherThings)).ToList();
                    }
                    if (model.posterCity != null && model.posterCity != "")
                    {
                       q = q.Where(c => c.posterCity.Contains(model.posterCity)).ToList();
                    }
                    if (model.PosterCapacity != 0)
                    {
                        q = q.Where(c => c.PosterCapacity == model.PosterCapacity).ToList();
                    }
                    if (model.posterCoust != null && model.posterCoust != "")
                    {
                       q = q.Where(c => c.posterCoust.Contains(model.posterCoust)).ToList();
                    }
                    if (model.posterCoust != null && model.posterCoust != "")
                    {
                      q =  q.Where(c => c.posterCoust.Contains(model.posterCoust)).ToList();
                    }
                    if (model.posterType != null && model.posterType != "")
                    {
                       q = q.Where(c => c.posterType.Contains(model.posterType)).ToList();
                    }
                    if (model.daysOfWeek != null && model.daysOfWeek != "")
                    {
                       q = q.Where(c => c.daysOfWeek.Contains(model.daysOfWeek)).ToList();
                    }
                    if (model.timesOfDay != null && model.timesOfDay != "")
                    {
                       q = q.Where(c => c.timesOfDay.Contains(model.timesOfDay)).ToList();
                    }

                    if (model.OnlineOflineStatus == 1)
                    {
                       q = q.Where(c => c.OnlineOflineStatus == true).ToList();
                    }
                    if (model.OnlineOflineStatus == 0)
                    {
                       q = q.Where(c => c.OnlineOflineStatus == false).ToList();
                    }
                    if (model.posterStatus == 1)
                    {
                       q = q.Where(c => c.posterStatus == true).ToList();
                    }
                    if (model.posterStatus == 0)
                    {
                       q = q.Where(c => c.posterStatus == false).ToList();
                    }


                    if (model.posterStartDate != null && model.posterStartDate != "" && model.posterEndDate != null && model.posterEndDate != "")
                    {
                        var d1 = DateTime.Parse(ShamsiDateFormat(model.posterStartDate)).Date;
                        var d2 = DateTime.Parse(ShamsiDateFormat(model.posterEndDate)).Date;

                        if (d1 < d2)
                        {

                          q =  q.Where(c => DateTime.Parse(ShamsiDateFormat(c.posterStartDate)).Date >= d1 && DateTime.Parse(ShamsiDateFormat(c.posterEndDate)).Date <= d2).ToList();

                        }
                    }


                    List<VmPoster> list = new List<VmPoster>();

                    foreach (var item in q)
                    {
                    

                        VmPoster vm = new VmPoster();

                        vm.posterID = item.posterID;
                        vm.fk_userID = item.fk_userID;
                        vm.posterAddress = item.posterAddress;
                        vm.posterPhoneNumber = item.posterPhoneNumber;
                        vm.posterStatus = item.posterStatus;
                        vm.posterContacts = item.posterContacts;
                        vm.posterType = item.posterType;
                        vm.posterTitle = item.posterTitle;

                        list.Add(vm);


                    }
                    return list;
                }
                else
                {
                    return null;
                }

            }
            else
            {
                return null;
            }
        }
    }
}

