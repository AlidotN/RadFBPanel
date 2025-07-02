using RadFBApp.Models.Data;
using RadFBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Areas.Panel.Repository
{
    public class repNotification
    {
        ApplicationDbContext db = new ApplicationDbContext();


        //dialog list
        public List<Tbl_dialog> DialogList()
        {
            var q = (from i in db.Tbl_dialog where i.DeleteStatus == false select i).ToList();
            return q;
        }

        //dialog 
        public object dialog(long? id)
        {
            var q = (from i in db.Tbl_dialog where i.notificationID == id select i).SingleOrDefault();
            return q;
        }

       

        //Add dialog
        public int AddDialog(Tbl_dialog model)
        {
            try
            {
                db.Tbl_dialog.Add(new Tbl_dialog
                {
                    prnotificationTitle = model.prnotificationTitle,
                    prNotificationText = model.prNotificationText,
                    enNotificationTitle = model.enNotificationTitle,
                    enNotificationText = model.enNotificationText,
                    DeleteStatus = false,
                   
                });

                db.SaveChanges();

                return 1;
            }
            catch
            {

                return 0;
            }

        }

       

        //delete dialog
        public int Deldialog(long? id)
        {
            var q = (from i in db.Tbl_dialog where i.notificationID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_dialog.Update(q);
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected dialog
        public int DelAlldialog(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_dialog where i.notificationID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_dialog.Update(q);
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
