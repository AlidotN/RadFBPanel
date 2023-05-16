using radFB.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.Repository
{
    public class repUsersQuestion
    {
        ApplicationDbContext db = new ApplicationDbContext();


        //UserQuestion list
        public List<Tbl_usersQuestions> UserQuestionList()
        {
            var q = (from i in db.Tbl_usersQuestions where i.DeleteStatus == false select i).OrderByDescending(c=>c.usersQuestionsID).ToList();
            return q;
        }

        //UserQuestion 
        public Tbl_usersQuestions UserQuestion(long? id)
        {
            Tbl_usersQuestions q = (from i in db.Tbl_usersQuestions where i.usersQuestionsID == id select i).SingleOrDefault();
            return q;
        }

       

        //Add answer
        public int AddAnswer(long id,string text,string admin)
        {
           
            var q = (from i in db.Tbl_usersQuestions where i.usersQuestionsID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.QuestionAnswerText = text;
                q.QuestionAnswerDate = DateTime.Now.Date.ToString();
                q.QuestionAnswerTime = DateTime.Now.TimeOfDay.ToString();
                q.fk_admin = admin;
                db.SaveChanges();

                return 1;
            }
            else
            {

                return 0;
            }

        }

        //delete answer
        public int DeleteAnswer(long id)
        {
            var q = (from i in db.Tbl_usersQuestions where i.usersQuestionsID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.QuestionAnswerText = "";
                q.QuestionAnswerDate = "";
                q.QuestionAnswerTime = "";
                q.fk_admin = "";
                db.SaveChanges();

                return 1;
            }
            else
            {

                return 0;
            }

        }


       


        //delete UserQuestion
        public int DelUserQuestion(long? id)
        {
            var q = (from i in db.Tbl_usersQuestions where i.usersQuestionsID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_usersQuestions.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected UserQuestion
        public int DelAllUserQuestion(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_usersQuestions where i.usersQuestionsID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_usersQuestions.Update(q);
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
