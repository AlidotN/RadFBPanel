using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using radFB.db;
using radFB.ViewModels;

namespace radFB.Repository
{
    public class repPost
    {
        private readonly IHostingEnvironment _appEnvironment;
        public repPost(IHostingEnvironment appEnvironment)
        {
            _appEnvironment = appEnvironment;

        }



        ApplicationDbContext db = new ApplicationDbContext();


        //post list
        public List<Tbl_postChanged> postList()
        {
            var q = (from i in db.Tbl_postChanged where i.DeleteStatus == false select i).OrderByDescending(c=>c.postChangedID).ToList();
            return q;
        }

        //find one post
        public dynamic post(long id)
        {
            var q = (from i in db.Tbl_postChanged where i.postChangedID == id && i.DeleteStatus == false select i).FirstOrDefault();

            return q;
        }

        //edit post
        public bool edit(long id, VmPost model)
        {
            var q = post(id);
            if (q != null)
            {
                string fileName = q.postChangedPic;
                string uploads = "";

                if (model.postChangedPic != null)
                {
                    var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot\\uploads", fileName);

                    if (System.IO.File.Exists(path))
                    {
                        System.IO.File.Delete(path);
                    }

                    uploads = Path.Combine(_appEnvironment.WebRootPath, "uploads");
                    fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(model.postChangedPic.FileName);

                    var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create);
                    model.postChangedPic.CopyTo(fileStream);
                }



                q.postChangedExplain = model.postChangedExplain;
                q.postChangedPic = fileName;
                q.postChangedStatus = model.postChangedStatus;

                db.SaveChanges();



                return true;
            }
            else
            {
                return false;
            }
        }

        //delete post
        public int DelPost(long? id)
        {
            var q = (from i in db.Tbl_postChanged where i.postChangedID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_postChanged.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected posts
        public int DelAllPosts(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_postChanged where i.postChangedID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_postChanged.Update(q);
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
            int Year =int.Parse(toEnglishNumber(userDateParts[0]));
            int Month = int.Parse(toEnglishNumber(userDateParts[1]));
            int Day = int.Parse(toEnglishNumber(userDateParts[2]));

            PersianCalendar pc = new PersianCalendar();
            DateTime dt = new DateTime(Year, Month, Day, pc);

            return dt.ToString();
            //return Year.ToString("0000/") + Month.ToString("00/") + Day.ToString("00");

        }


        //search
        public List<Tbl_postChanged> searchResult(string dt1, string dt2)
        {

            var d1 = DateTime.Parse(ShamsiDateFormat(dt1)).Date;
            var d2 = DateTime.Parse(ShamsiDateFormat(dt2)).Date;

            if (d1 < d2)
            {
                var q = (from i in db.Tbl_postChanged 
                         where i.DeleteStatus == false &&
                         (DateTime.Parse(ShamsiDateFormat(i.postChangedDate)).Date >= d1 && DateTime.Parse(ShamsiDateFormat(i.postChangedDate)).Date <= d2) select i).ToList();
              
                return q;
            }
            else
            {
                return null;
            }

          
        }


        //edit status
        public int edit(long id)
        {
            var q = (from i in db.Tbl_postChanged
                     where i.postChangedID == id && i.DeleteStatus == false
                     select i).FirstOrDefault();
            if (q != null)
            {
                q.postChangedStatus = !q.postChangedStatus;
                db.Tbl_postChanged.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }

    }
}
