using RadFBApp.Models.Data;
using RadFBApp.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using RadFBApp.Models.ViewModels.Admin;

namespace RadFBApp.Areas.Panel.Repository
{
    public class repQuestion
    {
        ApplicationDbContext db = new ApplicationDbContext();
        Classes.publicFunctions func = new Classes.publicFunctions();


        //Question list
        public List<VmQuestion> QuestionList()
        {

            var q = (from i in db.Tbl_Question
                     join p in db.Tbl_post on i.fk_postID equals p.postID
                     join s in db.Tbl_subject on i.fk_subjectID equals s.subjectID
                     join c in db.Tbl_jobCategory on i.fk_JobCategoryID equals c.jobCategoryID
                     join f in db.Tbl_PostFile on i.fk_postID equals f.fk_postID
                     where i.DeleteStatus == false select new
                     {
                         i.QuestionID , p.postTitle,p.RegisterDate,p.fk_UserID,s.FaTitle,c.PrJobCategoryTitle
                         ,f.picAddress
                     }).ToList();

            List<VmQuestion> list = new List<VmQuestion>();

            foreach (var item in q)
            {
                VmQuestion vm = new VmQuestion();
                vm.ID = item.QuestionID;
                vm.answerCount = showAnswers(item.QuestionID).Count;
                vm.category = item.PrJobCategoryTitle;
                vm.subject = item.FaTitle;
                vm.pic = item.picAddress;
                vm.name = func.fullName(item.fk_UserID);
                vm.textTitle = item.postTitle;
                vm.date = item.RegisterDate;
                vm.time = Convert.ToDateTime(ShamsiDateFormat(item.RegisterDate)).Date.TimeOfDay.ToString();
                list.Add(vm);
            }
            return list;
        }

        //find one Question
        public VmQuestion Question(long id)
        {
            var q = (from i in db.Tbl_Question
                     join p in db.Tbl_post on i.fk_postID equals p.postID
                     join s in db.Tbl_subject on i.fk_subjectID equals s.subjectID
                     join c in db.Tbl_jobCategory on i.fk_JobCategoryID equals c.jobCategoryID
                     join f in db.Tbl_PostFile on i.fk_postID equals f.fk_postID
                     where i.DeleteStatus == false && i.QuestionID == id
                     select new
                     {
                         i.QuestionID,
                         p.postTitle,
                         p.RegisterDate,
                         p.fk_UserID,
                         s.FaTitle,
                         c.PrJobCategoryTitle
,
                         f.picAddress
                     }).SingleOrDefault();

            VmQuestion vm = new VmQuestion();
            vm.answerCount = showAnswers(q.QuestionID).Count();
            vm.category = q.PrJobCategoryTitle;
            vm.subject = q.FaTitle;
            vm.pic = q.picAddress;
            vm.name = func.fullName(q.fk_UserID);
            vm.textTitle = q.postTitle;
            vm.date = q.RegisterDate;
            vm.time = Convert.ToDateTime(ShamsiDateFormat(q.RegisterDate)).Date.TimeOfDay.ToString();
            return vm;
        }


        //answers
        public List<Tbl_AnswerToQuestion> showAnswers(long id)
        {
            var q = (from i in db.Tbl_AnswerToQuestion 
                     where i.fk_QuestiontID == id  
                     && i.DeleteStatus == false select i).ToList();

            return q;
        }


        //delete Question
        public int DelAnswer(long? id)
        {
            var q = (from i in db.Tbl_AnswerToQuestion where i.ParentID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_AnswerToQuestion.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete Question
        public int DelQuestion(long? id)
        {
            var q = (from i in db.Tbl_Question where i.QuestionID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_Question.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected Questions
        public int DelAllQuestions(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_Question where i.QuestionID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_Question.Update(q);
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
        public List<VmQuestion> searchResult(string name, string txt,long subject,long category,int answerCount, string dt1 , string dt2)
        {
            var q = (from i in db.Tbl_Question
                     join p in db.Tbl_post on i.fk_postID equals p.postID
                     join r in db.Tbl_RadFBUsers on p.fk_UserID equals r.RadFbUserID


                     join a in db.Tbl_RealCient on r.RadFbUserID equals a.fk_UserID
                    into ai
                     from aiResult in ai.DefaultIfEmpty()

                     join b in db.Tbl_legalClient on r.RadFbUserID equals b.fk_UserID
                     into ib
                     from ibResult in ib.DefaultIfEmpty()

                     join c in db.Tbl_userType on r.fk_userTypeID equals c.userTypeID
                     into ic
                     from icResult in ic.DefaultIfEmpty()

                     join s in db.Tbl_subject on i.fk_subjectID equals s.subjectID
                     join c in db.Tbl_jobCategory on i.fk_JobCategoryID equals c.jobCategoryID
                     join f in db.Tbl_PostFile on i.fk_postID equals f.fk_postID
                     where i.DeleteStatus == false && (ibResult.legalClientID != null || aiResult.RealClientID != null)
                     select new
                     {
                         icResult.PrUserTypeName,
                         icResult.userTypeID,
                         ibResult.CEOName,
                         aiResult.FirstName,
                         aiResult.LastName,
                         i.QuestionID,
                         p.postTitle,
                         p.RegisterDate,
                         p.fk_UserID,
                         s.FaTitle,
                         s.subjectID,
                         c.PrJobCategoryTitle,
                         c.jobCategoryID,
                         f.picAddress,
                         AnswerCount = (from n in db.Tbl_AnswerToQuestion
                                                  where n.fk_QuestiontID == i.QuestionID
                                                  select n).Count(),
                     }).ToList();


            if (name != null && name != "")
            {
                q = q.Where(c => ((c.FirstName != null && c.LastName != null) && (c.FirstName + c.LastName).Contains(name, StringComparison.CurrentCultureIgnoreCase))
                 || (c.CEOName != null && c.CEOName.Contains(name, StringComparison.CurrentCultureIgnoreCase)))
                    .Distinct().ToList();
            }

           

            if (txt != null && txt != "")
            {
                q = q.Where(c => c.postTitle.Contains(txt)).ToList();
            }

            if (subject != 0)
            {
                q = q.Where(c => c.subjectID == subject).ToList();
            }

            if (category != 0)
            {
                q = q.Where(c => c.jobCategoryID == category).ToList();
            }

            if (answerCount != 0)
            {
                q = q.Where(c => c.AnswerCount >= answerCount).ToList();
            }

            if (dt1 != null && dt1 != "" && dt2 != null && dt2 != "")
            {
                var d1 = DateTime.Parse(ShamsiDateFormat(dt1)).Date;
                var d2 = DateTime.Parse(ShamsiDateFormat(dt2)).Date;

                if (d1 < d2)
                {

                    q = q.Where(c => DateTime.Parse(ShamsiDateFormat(c.RegisterDate)).Date >= d1 && DateTime.Parse(ShamsiDateFormat(c.RegisterDate)).Date <= d2).ToList();

                }
            }

            List<VmQuestion> list = new List<VmQuestion>();

            foreach (var item in q)
            {
                VmQuestion vm = new VmQuestion();
                vm.ID = item.QuestionID;
                vm.answerCount = showAnswers(item.QuestionID).Count;
                vm.category = item.PrJobCategoryTitle;
                vm.subject = item.FaTitle;
                vm.pic = item.picAddress;
                vm.name = func.fullName(item.fk_UserID);
                vm.textTitle = item.postTitle;
                vm.date = item.RegisterDate;
                vm.time = Convert.ToDateTime(ShamsiDateFormat(item.RegisterDate)).Date.TimeOfDay.ToString();
                list.Add(vm);
            }
            return list;


        }
    }
}
