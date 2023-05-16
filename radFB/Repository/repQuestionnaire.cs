using radFB.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using radFB.ViewModels;
namespace radFB.Repository
{
    public class repQuestionnaire
    {
        ApplicationDbContext db = new ApplicationDbContext();
        radFB.Classes.publicFunctions func = new Classes.publicFunctions();

        //Questionnair list
        public List<VmQuestionnair> QuestionList()
        {

            var q = (from i in db.Tbl_questionnaire
                     join p in db.Tbl_post on i.fk_postID equals p.postID
                     join s in db.Tbl_subject on i.fk_subjectID equals s.subjectID
                     join c in db.Tbl_jobCategory on i.fk_JobCategoryID equals c.jobCategoryID
                     where i.DeleteStatus == false
                     select new
                     {
                         i.questionnaireID,
                         p.postTitle,
                         p.RegisterDate,
                         p.fk_UserID,
                         s.FaTitle,
                         c.PrJobCategoryTitle,
                         i.address,
                         i.benefit,
                         i.status,
                         i.answerType
                     }).OrderByDescending(c => c.questionnaireID).ToList();

            List<VmQuestionnair> list = new List<VmQuestionnair>();

            foreach (var item in q)
            {
                VmQuestionnair vm = new VmQuestionnair();
                vm.ID = item.questionnaireID;
                vm.JobCategory = item.PrJobCategoryTitle;
                vm.subject = item.FaTitle;
                vm.address = item.address;
                vm.fk_userID = item.fk_UserID;
                vm.title = item.postTitle;
                vm.date = item.RegisterDate;
                vm.status = item.status;
                vm.benefit = item.benefit;
                vm.answerType = item.answerType;
                list.Add(vm);
            }
            return list;
        }


        //داوطلب شدن برای پرسشنامه
        public long answersCount(long userID, long qID)
        {
            long count = (from i in db.Tbl_post
                          join b in db.Tbl_questionnaire on i.postID equals b.fk_postID
                          join c in db.Tbl_DeclarationOfReadiness on b.questionnaireID equals c.fk_questionnaireID

                          where i.fk_UserID == userID
                          && b.questionnaireID == qID
                          && i.DeleteStatus != true
                          && i.fk_PostTypeID == 5
                          select c.fk_questionnaireID).ToList().Count();
            return count;

        }
        //edit Questionnair
        public int edit(long id)
        {
            var q = (from i in db.Tbl_questionnaire
                     where i.questionnaireID == id && i.DeleteStatus == false
                     select i).FirstOrDefault();
            if (q != null)
            {
                q.status = !q.status;
                db.Tbl_questionnaire.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }
        }


        //delete Questionnair
        public int DelQuestionnair(long? id)
        {
            var q = (from i in db.Tbl_questionnaire where i.questionnaireID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_questionnaire.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected Questionnair
        public int DelAllQuestionnair(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_questionnaire where i.questionnaireID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_questionnaire.Update(q);
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
