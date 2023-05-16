using radFB.db;
using radFB.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.Repository
{
    public class repReports
    {
        ApplicationDbContext db = new ApplicationDbContext();
        Classes.publicFunctions func = new Classes.publicFunctions();


        //تعداد بسته های خریداری شده
        public long packageCount()
        {
            long count = (from i in db.Tbl_permiumPackage
                          join a in db.Tbl_pay on i.permiumPackageID equals a.fk_permiumPackageID
                          select i.permiumPackageID).ToList().Count;
            return count;
        }


        //تعداد کاربران دارای بسته
        public long userPackagesCount()
        {
            long count = (from i in db.Tbl_UsersPackage
                          where i.status == true
                          select i).ToList().Count;
            return count;
        }


        //جمع کل خرید ها
        public string TotalPurchases()
        {
            var q = (from i in db.Tbl_pay
                     select i.price).ToList();
            string price = q.Sum().ToString();
            return price;
        }


        //لیست  مالی
        public List<VmFinance> financeList()
        {

            var q = (from p in db.Tbl_UsersPackage
                     join i in db.Tbl_permiumPackage on p.fk_packageID equals i.permiumPackageID
                     join r in db.Tbl_RadFBUsers on p.fk_userID equals r.RadFbUserID
                     join f in db.Tbl_factor on p.fk_payID equals f.fk_payID

                     select new
                     {
                         i.permiumPackageTitle,
                         f.price,
                         f.status,
                         f.date,
                         r.RadFbUserID,
                         r.phoneNumber,
                         u1 = p.status
                     }).OrderByDescending(c=> DateTime.Parse(ShamsiDateFormat(c.date)).Date).ToList();

            List<VmFinance> list = new List<VmFinance>();
            foreach (var item in q)
            {
                VmFinance vm = new VmFinance();

                vm.packageName = item.permiumPackageTitle;
                vm.username = func.fullName(item.RadFbUserID);
                vm.tell = item.phoneNumber;
                vm.price = item.price.ToString();
                vm.date = item.date;
                vm.status = item.status;
                vm.active = item.u1;
                list.Add(vm);
            }

            return list;
        }


        //تبدیل عدد فارسی به انگلیسی
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


        //جستجو در لیست گزارشات مالی
        public List<VmFinanceReports> financeSearch(string name, string price, string d1, string d2)
        {

            var q = (from i in db.Tbl_factor
                     join o in db.Tbl_pay on i.fk_payID equals o.payID
                     join r in db.Tbl_RadFBUsers on o.fk_userID equals r.RadFbUserID

                     join a in db.Tbl_RealCient on o.fk_userID equals a.fk_UserID
                     into ai
                     from aiResult in ai.DefaultIfEmpty()

                     join b in db.Tbl_legalClient on o.fk_userID equals b.fk_UserID
                     into ib
                     from ibResult in ib.DefaultIfEmpty()

                     join c in db.Tbl_userType on r.fk_userTypeID equals c.userTypeID
                     into ic
                     from icResult in ic.DefaultIfEmpty()

                     where i.DeleteStatus == false
                     && (ibResult.legalClientID != null || aiResult.RealClientID != null)

                     select new { icResult.userTypeID, ibResult.CEOName, aiResult.FirstName, aiResult.LastName, i.factorID, i.price, i.date, o.fk_userID }).ToList();


            if (name != null && name != "")
            {

                q = q.Where(c => ((c.FirstName != null && c.LastName != null) && (c.FirstName + c.LastName).Contains(name, StringComparison.CurrentCultureIgnoreCase))
                 || (c.CEOName != null && c.CEOName.Contains(name, StringComparison.CurrentCultureIgnoreCase))).ToList();

            }



            if (price != null && price != "")
            {
                q = q.Where(c => c.price == long.Parse(price)).ToList();
            }

            if (d1 != null && d1 != "" && d2 != null && d2 != "")
            {
                var dt1 = DateTime.Parse(ShamsiDateFormat(d1)).Date;
                var dt2 = DateTime.Parse(ShamsiDateFormat(d2)).Date;

                if (dt1 < dt2)
                {

                    q = q.Where(c => DateTime.Parse(ShamsiDateFormat(c.date)).Date >= dt1 && DateTime.Parse(ShamsiDateFormat(c.date)).Date <= dt2).ToList();

                }
            }


            List<VmFinanceReports> list = new List<VmFinanceReports>();

            foreach (var item in q)
            {
                VmFinanceReports vm = new VmFinanceReports();

                vm.userName = func.fullName(item.fk_userID);
                vm.factorNumber = item.factorID.ToString();
                vm.price = item.price.ToString();
                vm.date = item.date;

                list.Add(vm);
            }

            return list;
        }



        //جستجو در لیست گزارشات کاربر
        public List<VmUserReports> UserSearch(string name, int postCount, int QuestionAnswerCount, int advAnswerCount, int advCount, int bookCount, int articleCount, int questinierCount, int questinierAnswerCount, int questionCount, int posterParticipateCount, bool lastLogin = false)
        {
            var q = (from r in db.Tbl_RadFBUsers
                     join a in db.Tbl_RealCient on r.RadFbUserID equals a.fk_UserID
                     into ai
                     from aiResult in ai.DefaultIfEmpty()

                     join b in db.Tbl_legalClient on r.RadFbUserID equals b.fk_UserID
                     into ib
                     from ibResult in ib.DefaultIfEmpty()

                     join c in db.Tbl_userType on r.fk_userTypeID equals c.userTypeID
                     into ic
                     from icResult in ic.DefaultIfEmpty()

                     where r.DeleteStatus == false
                     && (ibResult.legalClientID != null || aiResult.RealClientID != null)

                     select new
                     {
                         icResult.PrUserTypeName,
                         icResult.userTypeID,
                         ibResult.CEOName,
                         aiResult.FirstName,
                         aiResult.LastName,
                         r.RadFbUserID,
                         r.phoneNumber,
                         r.email,
                         r.lastSeenDate,

                         postCount = (from m in db.Tbl_post where m.fk_UserID == r.RadFbUserID select m).Count(),

                         questionAnswerCount = (from n in db.Tbl_AnswerToQuestion where n.fk_UserID == r.RadFbUserID select n).Count(),

                         AdAnswerCount = (from n in db.Tbl_EmploymentAdvApply where n.fk_ApplicantUserID == r.RadFbUserID select n).Count(),

                         AdvCount = (from n in db.Tbl_EmploymentAdvPost
                                     join p in db.Tbl_post on n.fk_PostID equals p.postID
                                     where r.RadFbUserID == p.fk_UserID
                                     select n).Count(),
                         bookCount = (from n in db.Tbl_post
                                      where r.RadFbUserID == n.fk_UserID && n.fk_PostTypeID == 1
                                      select n).Count(),

                         aricleCount = (from n in db.Tbl_post
                                        where r.RadFbUserID == n.fk_UserID && n.fk_PostTypeID == 2
                                        select n).Count(),

                         questionCount = (from n in db.Tbl_post
                                          join p in db.Tbl_Question on n.postID equals p.fk_postID
                                          where r.RadFbUserID == n.fk_UserID && n.fk_PostTypeID == 6
                                          select n).Count(),

                         questinierCount = (from n in db.Tbl_post
                                            join p in db.Tbl_questionnaire on n.postID equals p.fk_postID
                                            where r.RadFbUserID == n.fk_UserID && n.fk_PostTypeID == 5
                                            select n).Count(),

                         AnswerQuestinierCount = (from n in db.Tbl_DeclarationOfReadiness
                                                  where r.RadFbUserID == n.fk_volunteerUserID
                                                  select n).Count(),

                         posterRegisterCount = (from n in db.Tbl_poster
                                                join p in db.Tbl_UserRegistrationCourses on n.posterID equals p.fk_posterID
                                                where r.RadFbUserID == p.fk_RegisteredUserID
                                                select n).Count(),
                     }).ToList();



            if (name != null && name != "")
            {
                q = q.Where(c => ((c.FirstName != null && c.LastName != null) && (c.FirstName + c.LastName).Contains(name, StringComparison.CurrentCultureIgnoreCase))
                 || (c.CEOName != null && c.CEOName.Contains(name, StringComparison.CurrentCultureIgnoreCase)))
                    .Distinct().ToList();
            }


            if (postCount != 0)
            {
                q = q.Where(c => c.postCount >= postCount).Distinct().ToList();
            }

            if (questionCount != 0)
            {
                q = q.Where(c => c.questionCount >= questionCount).Distinct().ToList();
            }

            if (QuestionAnswerCount != 0)
            {
                q = q.Where(c => c.questionAnswerCount >= QuestionAnswerCount).Distinct().ToList();
            }


            if (advCount != 0)
            {
                q = q.Where(c => c.AdvCount >= advCount).Distinct().ToList();
            }

            if (advAnswerCount != 0)
            {
                q = q.Where(c => c.AdAnswerCount >= advAnswerCount).Distinct().ToList();
            }

            if (bookCount != 0)
            {
                q = q.Where(c => c.bookCount >= bookCount).Distinct().ToList();
            }


            if (articleCount != 0)
            {
                q = q.Where(c => c.aricleCount >= articleCount).Distinct().ToList();
            }


           

            if (questinierCount != 0)
            {
                q = q.Where(c => c.questinierCount >= questinierCount).Distinct().ToList();
            }

            if (questinierAnswerCount != 0)
            {
                q = q.Where(c => c.AnswerQuestinierCount >= questinierAnswerCount).Distinct().ToList();
            }

            if (posterParticipateCount != 0)
            {
                q = q.Where(c => c.posterRegisterCount >= posterParticipateCount).Distinct().ToList();
            }
    

            if (lastLogin == true)
            {
                q = q.OrderBy(c => DateTime.Parse(ShamsiDateFormat(c.lastSeenDate)).Date).ToList();
            }


            List<VmUserReports> list = new List<VmUserReports>();

            foreach (var item in q)
            {
                VmUserReports vm = new VmUserReports();

                vm.ID = item.RadFbUserID;
                vm.userType = item.PrUserTypeName;
                vm.userName = func.fullName(item.RadFbUserID);
                vm.tell = item.phoneNumber;
                vm.email = item.email;
                vm.postCount = item.postCount;
                vm.advPostCount = item.AdvCount;
                vm.answerToAdvCount = item.AdAnswerCount;
                vm.answerToQuestionCount = item.questionAnswerCount;
                vm.bookCount = item.bookCount;
                vm.articleCount = item.aricleCount;
                vm.questionCount = item.questionCount;
                vm.questinierCount = item.questinierCount;
                vm.answerToquestinierCount = item.AnswerQuestinierCount;
                vm.posterParticipateCount = item.posterRegisterCount;

                list.Add(vm);
            }

            return list;
        }
    }
}


