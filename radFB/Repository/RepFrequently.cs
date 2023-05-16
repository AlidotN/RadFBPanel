using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using radFB.db;

namespace radFB.Repository
{
    public class RepFrequently
    {
        ApplicationDbContext db = new ApplicationDbContext();


        //Frequently list
        public List<Tbl_FrequentlyAskedQuestions> FrequentlyList()
        {
            var q = (from i in db.Tbl_FrequentlyAskedQuestions where i.DeleteStatus == false select i).OrderByDescending(c=>c.FrequentlyAskedQuestionsID).ToList();
            return q;
        }

        //Frequently 
        public object Frequently(long? id)
        {
            var q = (from i in db.Tbl_FrequentlyAskedQuestions where i.FrequentlyAskedQuestionsID == id select i).SingleOrDefault();
            return q;
        }

        //edit status
        public int editSt(long? id)
        {
            var q = (from i in db.Tbl_FrequentlyAskedQuestions where i.FrequentlyAskedQuestionsID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.status = !q.status;
                db.Tbl_FrequentlyAskedQuestions.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }

        //Add Frequently
        public int AddFrequently(Tbl_FrequentlyAskedQuestions model)
        {
            try
            {
                db.Tbl_FrequentlyAskedQuestions.Add(new Tbl_FrequentlyAskedQuestions
                {
                    prQuestion = model.prQuestion,
                    prAnswer = model.prAnswer,
                    EnQuestion = model.EnQuestion,
                    EnAnswer = model.EnAnswer,
                    status = model.status,
                    fk_SubjectID = model.fk_SubjectID
                });

                db.SaveChanges();

                return 1;
            }
            catch
            {

                return 0;
            }

        }

        //edit Frequently
        public int editFrequently(long? id, Tbl_FrequentlyAskedQuestions model)
        {
            var q = (from i in db.Tbl_FrequentlyAskedQuestions where i.FrequentlyAskedQuestionsID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.prQuestion = model.prQuestion;
                q.prAnswer = model.prAnswer;
                q.EnQuestion = model.EnQuestion;
                q.EnAnswer = model.EnAnswer;
                q.status = model.status;
                q.fk_SubjectID = model.fk_SubjectID;
                db.Tbl_FrequentlyAskedQuestions.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }

        //delete Frequently
        public int DelFrequently(long? id)
        {
            var q = (from i in db.Tbl_FrequentlyAskedQuestions where i.FrequentlyAskedQuestionsID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_FrequentlyAskedQuestions.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected Frequently
        public int DelAllFrequently(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_FrequentlyAskedQuestions where i.FrequentlyAskedQuestionsID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_FrequentlyAskedQuestions.Update(q);
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

        //subject name
        public string subjectName(long? id) 
        {
            string name = (from i in db.Tbl_FrequentlyAskedQuestionsSubject where i.FrequentlyAskedQuestionsSubjectID == id  select i.FaTitle).SingleOrDefault().ToString();

            return name;
                
        }


    }
}
