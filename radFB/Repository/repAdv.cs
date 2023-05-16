using radFB.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using radFB.ViewModels;
using System.Globalization;

namespace radFB.Repository
{
    public class repAdv
    {
        ApplicationDbContext db = new ApplicationDbContext();
        radFB.Classes.publicFunctions func = new Classes.publicFunctions();

        //adv list
        public List<VmAdv> advList()
        {
            var q = (from i in db.Tbl_EmploymentAdvPost
                     join p in db.Tbl_post on i.fk_PostID equals p.postID
                     join n in db.Tbl_province on i.fk_provinceID equals n.provinceID
                     where i.DeleteStatus == false
                     select new
                     {
                         p.fk_UserID,
                         p.RegisterDate,
                         i.EdvStatus,
                         i.EmploymentAdvPostID,
                         i.salary,
                         i.SkillsReqired,
                         i.WorkExprience,
                         n.provinceName
                     }).OrderByDescending(c=>c.EmploymentAdvPostID).ToList();
            List<VmAdv> list = new List<VmAdv>();

            foreach (var item in q)
            {
                VmAdv vm = new VmAdv();
                vm.ID = item.EmploymentAdvPostID;
                vm.skiils = item.SkillsReqired;
                vm.expriense = item.WorkExprience;
                vm.salary = item.salary;
                vm.name = func.fullName(item.fk_UserID);
                vm.province = item.provinceName;
                vm.status = item.EdvStatus;
                vm.date = item.RegisterDate;
                vm.time = Convert.ToDateTime(ShamsiDateFormat(item.RegisterDate)).Date.TimeOfDay.ToString();
                list.Add(vm);
            }
            return list;
        }





        //find one adv
        public VmDetailAdv adv(long id)
        {
            var q = (from i in db.Tbl_EmploymentAdvPost
                     join p in db.Tbl_post on i.fk_PostID equals p.postID
                     join c in db.Tbl_countries on i.fk_countryID equals c.countryID
                     join co in db.Tbl_CooperationType on i.fk_CooperationTypeID equals co.CooperationID
                     join m in db.Tbl_militaryServiceSituation on i.fk_mssID equals m.mssID
                     join cat in db.Tbl_jobCategory on i.fk_jobCategoryID equals cat.jobCategoryID
                     join g in db.Tbl_gender on i.fk_genderID equals g.GenderID
                     join gr in db.Tbl_grade on i.fk_grageID equals gr.gradeID
                     join n in db.Tbl_province on i.fk_provinceID equals n.provinceID
                     where i.DeleteStatus == false && i.EmploymentAdvPostID == id
                     select new
                     {
                         p.fk_UserID,
                         p.RegisterDate,
                         i.EdvStatus,
                         i.EmploymentAdvPostID,
                         i.salary,
                         i.SkillsReqired,
                         i.WorkExprience,
                         n.provinceName,
                         c.countryName,
                         co.PrCooperationName,
                         m.prMSS,
                         cat.PrJobCategoryTitle,
                         g.PrGenderTitle,
                         gr.PrGradeTitle,
                         p.postTitle,
                         i.EdvType
                     }).SingleOrDefault();



            VmDetailAdv vm = new VmDetailAdv();
            vm.ID = q.EmploymentAdvPostID;
            vm.skiils = q.SkillsReqired;
            vm.expriense = q.WorkExprience;
            vm.salary = q.salary;
            vm.name = func.fullName(q.fk_UserID);
            vm.province = q.provinceName;
            vm.date = q.RegisterDate;
            vm.time = Convert.ToDateTime(ShamsiDateFormat(q.RegisterDate)).Date.TimeOfDay.ToString();
            vm.country = q.countryName;
            vm.cooper = q.PrCooperationName;
            vm.mss = q.prMSS;
            vm.categoty = q.PrJobCategoryTitle;
            vm.gender = q.PrGenderTitle;
            vm.grade = q.PrGradeTitle;
            vm.title = q.postTitle;
            vm.status = q.EdvStatus;
            vm.type = q.EdvType;
            return vm;
        }



        //edit adv
        public int edit(long id)
        {
            var q = (from i in db.Tbl_EmploymentAdvPost
                     where i.EmploymentAdvPostID == id && i.DeleteStatus == false
                     select i).FirstOrDefault();
            if (q != null)
            {
                q.EdvStatus = !q.EdvStatus;
                db.Tbl_EmploymentAdvPost.Update(q);
                db.SaveChanges();
                return 1;
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


        //delete discount
        public int DelAdv(long? id)
        {
            var q = (from i in db.Tbl_EmploymentAdvPost where i.EmploymentAdvPostID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_EmploymentAdvPost.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected adv
        public int DelAllAdv(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_EmploymentAdvPost where i.EmploymentAdvPostID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_EmploymentAdvPost.Update(q);
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

    }
}
