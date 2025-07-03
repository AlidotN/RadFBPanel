using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Mail;
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
        public string ShamsiDate()
        {
            PersianCalendar g = new PersianCalendar();
            Int32 d, m, y;
            string ymd;
            d = g.GetDayOfMonth(DateTime.Now);
            m = g.GetMonth(DateTime.Now);
            y = g.GetYear(DateTime.Now);

            string mm, dd;
            if (m < 10)
            {
                mm = "0" + m.ToString();
            }
            else
            {
                mm = m.ToString();
            }

            if (d < 10)
            {
                dd = "0" + d.ToString();
            }
            else
            {
                dd = d.ToString();
            }

            ymd = y.ToString() + "/" + mm + "/" + dd;

            return ymd;
        }

        public string ShamsiDate2()
        {
            PersianCalendar g = new PersianCalendar();
            Int32 d, m, y;
            string ymd;
            d = g.GetDayOfMonth(DateTime.Now);
            m = g.GetMonth(DateTime.Now);
            y = g.GetYear(DateTime.Now);

            string mm, dd;
            if (m < 10)
            {
                mm = "0" + m.ToString();
            }
            else
            {
                mm = m.ToString();
            }

            if (d < 10)
            {
                dd = "0" + d.ToString();
            }
            else
            {
                dd = d.ToString();
            }

            ymd = y.ToString() + mm + dd;

            return ymd;
        }

        public string ShamsiDate(DateTime date)
        {
            PersianCalendar g = new PersianCalendar();
            Int32 d, m, y;
            string ymd;
            d = g.GetDayOfMonth(date);
            m = g.GetMonth(date);
            y = g.GetYear(date);

            string mm, dd;
            if (m < 10)
            {
                mm = "0" + m.ToString();
            }
            else
            {
                mm = m.ToString();
            }

            if (d < 10)
            {
                dd = "0" + d.ToString();
            }
            else
            {
                dd = d.ToString();
            }

            ymd = y.ToString() + "/" + mm + "/" + dd;

            return ymd;
        }

        public string ShamsiDateTime(DateTime date)
        {
            PersianCalendar g = new PersianCalendar();
            Int32 d, m, y, h, min, s;
            string ymd;
            d = g.GetDayOfMonth(date);
            m = g.GetMonth(date);
            y = g.GetYear(date);
            h = g.GetHour(date);
            min = g.GetMinute(date);
            s = g.GetSecond(date);

            string mm, dd;
            if (m < 10)
            {
                mm = "0" + m.ToString();
            }
            else
            {
                mm = m.ToString();
            }

            if (d < 10)
            {
                dd = "0" + d.ToString();
            }
            else
            {
                dd = d.ToString();
            }

            return h + ":" + min + ":" + s + " " + y.ToString() + "/" + mm + "/" + dd;
        }

        public string ShamsiDate2(DateTime date)
        {
            PersianCalendar g = new PersianCalendar();
            Int32 d, m, y;
            string ymd;
            d = g.GetDayOfMonth(date);
            m = g.GetMonth(date);
            y = g.GetYear(date);

            string mm, dd;
            if (m < 10)
            {
                mm = "0" + m.ToString();
            }
            else
            {
                mm = m.ToString();
            }

            if (d < 10)
            {
                dd = "0" + d.ToString();
            }
            else
            {
                dd = d.ToString();
            }

            ymd = y.ToString() + mm + dd;

            return ymd;
        }

        public string ShamsiToMiladi(string ShamsiDate)
        {
            PersianCalendar pc = new PersianCalendar();
            string[] shamsi_parts = ShamsiDate.Split('/');
            DateTime dt1 = pc.ToDateTime(int.Parse(shamsi_parts[0]), int.Parse(shamsi_parts[1]), int.Parse(shamsi_parts[2]), 0, 0, 0, 0);
            DateTime? dt2 = dt1;
            string miladi = dt2.Value.Year.ToString() + "/" + dt2.Value.Month.ToString() + "/" + dt2.Value.Day.ToString();
            return miladi;
        }

        public DateTime ShamsiToMiladi2(string ShamsiDate)
        {
            ShamsiDate = PersianToEnglishNumber(ShamsiDate);
            PersianCalendar pc = new PersianCalendar();
            string[] shamsi_parts = ShamsiDate.Split(new char[] { '/', ' ' }, System.StringSplitOptions.RemoveEmptyEntries);
            DateTime miladi = pc.ToDateTime(int.Parse(shamsi_parts[2]), int.Parse(shamsi_parts[0]), int.Parse(shamsi_parts[1]), 0, 0, 0, 0);
            return miladi;
        }

        public void SendEmailAsync(string email, string name, string subject, string msg)
        {
            string msgbody = string.Format(msg);
            MailMessage message = new MailMessage();
            message.From = new MailAddress("info@noelshop.ir");
            message.To.Add(new MailAddress("ali.n_programmer@yahoo.com"));
            message.Subject = subject;
            message.Body = msgbody;
            SmtpClient smtp = new SmtpClient("webmail.noelshop.ir");
            smtp.Credentials = new System.Net.NetworkCredential("info@noelshop.ir", "RI}t,af!]0Ie");
            smtp.Port = 465;
            smtp.EnableSsl = true;
            smtp.Send(message);
        }



        public bool IsDigitsOnly(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }

            return true;
        }

        public string PersianToEnglishNumber(string str)
        {
            _ = str.Replace("۰", "0");
            _ = str.Replace("۱", "1");
            _ = str.Replace("۲", "2");
            _ = str.Replace("۳", "3");
            _ = str.Replace("۴", "4");
            _ = str.Replace("۵", "5");
            _ = str.Replace("۶", "6");
            _ = str.Replace("۷", "7");
            _ = str.Replace("۸", "8");
            _ = str.Replace("۹", "9");

            return str;
        }

    }
}
