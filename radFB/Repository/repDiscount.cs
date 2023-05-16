using radFB.db;
using radFB.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.Repository
{
    public class repDiscount
    {
        ApplicationDbContext db = new ApplicationDbContext();


        //discount list
        public List<Tbl_discount> discountList()
        {
            var q = (from i in db.Tbl_discount where i.DeleteStatus == false select i).OrderByDescending(c=>c.discountID).ToList();
            return q;
        }

        //find one discount
        public object discount(long id)
        {
            var q = (from i in db.Tbl_discount where i.discountID == id && i.DeleteStatus == false select i).FirstOrDefault();

            return q;
        }

        //Add discount
        public bool Add(Tbl_discount model)
        {
            try
            {
                db.Tbl_discount.Add(new Tbl_discount
                {
                    discountTitle = model.discountTitle,
                    discountPercent = model.discountPercent,
                    startDate = model.startDate,
                    endDate = model.endDate
                });

                db.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
            {

            }

        }

        //edit discount
        public bool edit(long id, Tbl_discount model)
        {
            var q = (from i in db.Tbl_discount where i.discountID == id && i.DeleteStatus == false select i).FirstOrDefault();
            if (q != null)
            {
                q.discountTitle = model.discountTitle;
                q.discountPercent = model.discountPercent;
                q.startDate = model.startDate;
                q.endDate = model.endDate;
                db.Tbl_discount.Update(q);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete discount
        public int DelDiscount(long? id)
        {
            var q = (from i in db.Tbl_discount where i.discountID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_discount.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected discounts
        public int DelAlldiscounts(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_discount where i.discountID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_discount.Update(q);
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
        public List<VmDiscont> searchResult(string title, int percent, string dt)
        {
            var q = (from i in db.Tbl_discount
                     where i.DeleteStatus == false
                     select i).ToList();

            if (dt != null && dt != "")
            {
                var dtt = DateTime.Parse(ShamsiDateFormat(dt)).Date;
                q = q.Where(c => DateTime.Parse(ShamsiDateFormat(c.endDate)).Date == dtt).ToList();

            }

            if (title != null && title != "")
            {
                q = q.Where(c => c.discountTitle.Contains(title)).ToList();
            }

            if (percent != 0 )
            {
                q = q.Where(c => c.discountPercent == percent).ToList();
            }      

            List<VmDiscont> vmDisconts = new List<VmDiscont>();

            foreach (var item in q)
            {
                VmDiscont vm = new VmDiscont();
                vm.discountID = item.discountID;
                vm.discountTitle = item.discountTitle;
                vm.discountPercent = item.discountPercent;
                vm.endDate = item.endDate;

                vmDisconts.Add(vm);
            }
            return vmDisconts;


        }
    }
}
