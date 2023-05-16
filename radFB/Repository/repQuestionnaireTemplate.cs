using radFB.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.Repository
{
    public class repQuestionnaireTemplate
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //questionnaireTemplate list
        public List<Tbl_questionnaireTemplate> questionnaireTemplateList()
        {
            var q = (from i in db.Tbl_questionnaireTemplate where i.DeleteStatus == false select i).OrderByDescending(c=>c.questionnaireTemplateID).ToList();
            return q;
        }

        //find one questionnaireTemplate
        public Tbl_questionnaireTemplate questionnaireTemplate(long id)
        {
            var q = (from i in db.Tbl_questionnaireTemplate where i.questionnaireTemplateID == id && i.DeleteStatus == false select i).FirstOrDefault();

            return q;
        }


        //category name
        public string catName(long id)
        {
            string name = "";
            var q = (from i in db.Tbl_jobCategory where i.jobCategoryID == id select i).SingleOrDefault();
            if (q != null)
            {
                name = q.PrJobCategoryTitle.ToString();
            }
            
            return name;
        }


        //Add questionnaireTemplate
        public bool Add(Tbl_questionnaireTemplate model)
        {
            try
            {
                db.Tbl_questionnaireTemplate.Add(new Tbl_questionnaireTemplate
                {
                    questionnaireTemplateTitle = model.questionnaireTemplateTitle,
                    questionnaireTemplateDescription = model.questionnaireTemplateDescription,
                    questionnaireTemplateAddress = model.questionnaireTemplateAddress,
                    fk_jobCategoryID = model.fk_jobCategoryID,
                    templatePic = model.templatePic,
                    DeleteStatus = false
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

        //edit questionnaireTemplate
        public bool edit(long id, Tbl_questionnaireTemplate model)
        {
            var q = (from i in db.Tbl_questionnaireTemplate where i.questionnaireTemplateID == id && i.DeleteStatus == false select i).FirstOrDefault();
            if (q != null)
            {
                q.questionnaireTemplateTitle = model.questionnaireTemplateTitle;
                q.questionnaireTemplateDescription = model.questionnaireTemplateDescription;
                q.questionnaireTemplateAddress = model.questionnaireTemplateAddress;
                q.fk_jobCategoryID = model.fk_jobCategoryID;
                q.templatePic = model.templatePic;
                db.Tbl_questionnaireTemplate.Update(q);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete questionnaireTemplate
        public int DelquestionnaireTemplate(long? id)
        {
            var q = (from i in db.Tbl_questionnaireTemplate where i.questionnaireTemplateID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_questionnaireTemplate.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected questionnaireTemplates
        public int DelAllquestionnaireTemplates(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_questionnaireTemplate where i.questionnaireTemplateID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_questionnaireTemplate.Update(q);
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
