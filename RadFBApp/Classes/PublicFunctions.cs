using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RadFBApp.Models;
using RadFBApp.Models;

namespace RadFBApp.Classes
{
    public class publicFunctions
    {
        ApplicationDbContext db = new ApplicationDbContext();


        public string fileType(int id)
        {
            string file = (from i in db.postType where i.PostTypeID == id select i.FaPostTypeTitle).FirstOrDefault();

            return file.ToString();
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
    }
}
