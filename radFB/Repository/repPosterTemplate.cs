using radFB.db;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.Repository
{
    public class repPosterTemplate
    {
        ApplicationDbContext db = new ApplicationDbContext();

        //posterTemplate list
        public List<Tbl_posterTemplate> posterTemplateList()
        {
            var q = (from i in db.Tbl_posterTemplate where i.DeleteStatus == false select i).OrderByDescending(c=>c.posterTemplateID).ToList();
            return q;
        }

        //find one posterTemplate
        public Tbl_posterTemplate posterTemplate(long id)
        {
            var q = (from i in db.Tbl_posterTemplate where i.posterTemplateID == id && i.DeleteStatus == false select i).FirstOrDefault();

            return q;
        }




        //Add posterTemplate
        public bool Add(Tbl_posterTemplate model)
        {
            try
            {
                db.Tbl_posterTemplate.Add(new Tbl_posterTemplate
                {
                    posterName = model.posterName,
                    posterDescription = model.posterDescription,
                    posterFileAddress = model.posterFileAddress,
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

        //edit posterTemplate
        public bool edit(long id, Tbl_posterTemplate model)
        {
            var q = (from i in db.Tbl_posterTemplate where i.posterTemplateID == id && i.DeleteStatus == false select i).FirstOrDefault();
            if (q != null)
            {
                q.posterName = model.posterName;
                q.posterDescription = model.posterDescription;
                q.posterFileAddress = model.posterFileAddress;
                q.templatePic = model.templatePic;
                db.Tbl_posterTemplate.Update(q);
                db.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }
        }

        //delete posterTemplate
        public int DelposterTemplate(long? id)
        {
            var q = (from i in db.Tbl_posterTemplate where i.posterTemplateID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_posterTemplate.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected posterTemplates
        public int DelAllposterTemplates(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_posterTemplate where i.posterTemplateID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_posterTemplate.Update(q);
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
