using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using RadFBApp.Models.Data;
using RadFBApp.Models;


namespace RadFBApp.Areas.Panel.Repository
{
    public class repStory
    {
        ApplicationDbContext db = new ApplicationDbContext();


        //story list
        public List<Tbl_story> storyList()
        {
            var q = (from i in db.Tbl_story  select i).ToList();
            return q;
        }


        //edit story
        public int editStory(long? id)
        {
            var q = (from i in db.Tbl_story where i.storyID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.storyStatus = !q.storyStatus;
                db.Tbl_story.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }

        //delete story
        public int DelStory(long? id)
        {
            var q = (from i in db.Tbl_story where i.storyID == id select i).SingleOrDefault();
            if (q != null)
            {
               
                db.Tbl_story.Remove(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected stores
        public int DelAllStories(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_story where i.storyID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                      
                        db.Tbl_story.Remove(q);
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

            string[] userDateParts = Date.Split('/');
            int Year = int.Parse(toEnglishNumber(userDateParts[0]));
            int Month = int.Parse(toEnglishNumber(userDateParts[1]));
            int Day = int.Parse(toEnglishNumber(userDateParts[2]));

            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(Year, Month, Day, pc);

            return dt.ToString();
            //return Year.ToString("0000/") + Month.ToString("00/") + Day.ToString("00");

        }


        //search
        public List<Tbl_story> searchResult(string dt1, string dt2)
        {

            var d1 = DateTime.Parse(ShamsiDateFormat(dt1)).Date;
            var d2 = DateTime.Parse(ShamsiDateFormat(dt2)).Date;

            if (d1 < d2)
            {
                var q = (from i in db.Tbl_story
                         where
                         (DateTime.Parse(ShamsiDateFormat(i.stroryDate)).Date >= d1 && DateTime.Parse(ShamsiDateFormat(i.stroryDate)).Date <= d2)
                         select i).ToList();

                return q;
            }
            else
            {
                return null;
            }


        }
    }
}
