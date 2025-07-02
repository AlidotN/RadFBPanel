using RadFBApp.Models.Data;
using RadFBApp.Models;
using RadFBApp.Models.ViewModels.Admin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Areas.Panel.Repository
{
    public class repPermium
    {

        ApplicationDbContext db = new ApplicationDbContext();


        //permium list
        public List<Tbl_permiumPackage> permiumList()
        {
            var q = (from i in db.Tbl_permiumPackage where i.DeleteStatus == false select i).ToList();
            return q;
        }

        //permium 
        public Tbl_permiumPackage permium(long? id)
        {
            var q = (from i in db.Tbl_permiumPackage where i.permiumPackageID == id select i).SingleOrDefault();
            return q;
        }


        //setting list
        public List<Tbl_setting> settingList()
        {
            var q = (from i in db.Tbl_setting select i).ToList();
            return q;
        }

        //Add permium
        public int Addpermium(Tbl_permiumPackage model)
        {
            try
            {
                db.Tbl_permiumPackage.Add(new Tbl_permiumPackage
                {
                    permiumPackageTitle = model.permiumPackageTitle,
                    time = model.time,
                    price = model.price,
                    selectedOptions = model.selectedOptions,
                    DeleteStatus = false
                });
                db.SaveChanges();

                if (model.selectedOptions != "" && model.selectedOptions != null)
                {


                    long permiumID = (from i in db.Tbl_permiumPackage
                                      where
                                      i.DeleteStatus ==false
                                      && i.permiumPackageTitle.Contains(model.permiumPackageTitle)
                                      && i.selectedOptions.Contains(model.selectedOptions)
                                      && i.time == model.time
                                      && i.price == model.price
                                      select i.permiumPackageID).SingleOrDefault();

                    string strValue = model.selectedOptions;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var settingID = (from i in db.Tbl_setting where i.settingID == long.Parse(obj) select i.settingID).SingleOrDefault();
                        //your insert query
                        db.Tbl_packageOptions.Add(new Tbl_packageOptions
                        {
                            fk_permiumPackageID = permiumID,
                            fk_settingID = settingID
                        });
                    }
                    db.SaveChanges();
                }



                return 1;
            }
            catch
            {

                return 0;
            }

        }

        //edit permium
        public int editpermium(long id, Tbl_permiumPackage model)
        {
            var q = (from i in db.Tbl_permiumPackage where i.permiumPackageID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.permiumPackageTitle = model.permiumPackageTitle;
                q.time = model.time;
                q.price = model.price;
                q.selectedOptions = model.selectedOptions;

                db.Tbl_permiumPackage.Update(q);
                db.SaveChanges();

                if (model.selectedOptions != "" && model.selectedOptions != null)
                {

                    //delete from data base

                    var del = (from i in db.Tbl_packageOptions where i.fk_permiumPackageID == id select i).ToList();

                    foreach (var detail in del)
                    {
                        db.Tbl_packageOptions.Remove(detail);
                        db.SaveChanges();
                    }

                    string strValue = model.selectedOptions;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var settingID = (from i in db.Tbl_setting where i.settingID == long.Parse(obj) select i.settingID).SingleOrDefault();
                        //your insert query
                        db.Tbl_packageOptions.Add(new Tbl_packageOptions
                        {
                            fk_permiumPackageID = id,
                            fk_settingID = settingID
                        });
                    }
                    db.SaveChanges();
                }
                return 1;
            }
            else
            {
                return 0;
            }

        }


        //setting permium list
        public string settingList(long permiumID)
        {
            List<VmSettingList> ls = new List<VmSettingList>();

            var q = (from i in db.Tbl_packageOptions
                     join b in db.Tbl_setting on i.fk_settingID equals b.settingID
                     where i.fk_permiumPackageID == permiumID
                     select new { b.prSettingTitle }).ToList();

            string list = "";

            if (q.Count > 0)
            {
                foreach (var item in q)
                {
                    list = list + item.prSettingTitle.ToString() + " - ";
                }
            }
            return list;
        }




        //delete permium
        public int Delpermium(long? id)
        {
            var q = (from i in db.Tbl_permiumPackage where i.permiumPackageID == id select i).SingleOrDefault();
            if (q != null)
            {
                q.DeleteStatus = true;
                db.Tbl_permiumPackage.Update(q);

             
                var del = (from i in db.Tbl_packageOptions where i.fk_permiumPackageID == id select i).ToList();

                foreach (var detail in del)
                {
                    db.Tbl_packageOptions.Remove(detail);
                    db.SaveChanges();
                }
                db.SaveChanges();
                return 1;
            }
            else
            {
                return 0;
            }

        }



        //delete selected permium
        public int DelAllpermium(string deleteItems)
        {
            if (deleteItems != null)
            {
                try
                {

                    string strValue = deleteItems;
                    string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (var obj in strArray)
                    {
                        var q = (from i in db.Tbl_permiumPackage where i.permiumPackageID == long.Parse(obj) select i).SingleOrDefault();
                        //your delete query
                        q.DeleteStatus = true;
                        db.Tbl_permiumPackage.Update(q);

                        var del = (from i in db.Tbl_packageOptions where i.fk_permiumPackageID == long.Parse(obj) select i).ToList();

                        foreach (var detail in del)
                        {
                            db.Tbl_packageOptions.Remove(detail);
                            db.SaveChanges();
                        }

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
