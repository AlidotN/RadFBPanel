using RadFBApp.Models.Data;
using RadFBApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Areas.Panel.Repository
{
    public class repSuggestion
    {
        ApplicationDbContext db = new ApplicationDbContext();


        //suggestion list
        public List<Tbl_criticsAndSuggestions> SuggestionList()
        {
            var q = (from i in db.Tbl_criticsAndSuggestions where i.DeleteStatus == false select i).ToList();
            return q;
        }

        //suggestion 
        public object suggestion(long? id)
        {
            var q = (from i in db.Tbl_criticsAndSuggestions where i.criticsAndSuggestionsID == id select i).SingleOrDefault();
            return q;
        }

        //suggestion 
        public void suggestionReading(long? id)
        {
            try
            {
                var q = (from i in db.Tbl_criticsAndSuggestions where i.criticsAndSuggestionsID == id select i).SingleOrDefault();
                if (q != null)
                {
                    q.Confirmation = true;
                    db.Tbl_criticsAndSuggestions.Update(q);
                    db.SaveChanges();

                }
            }
            catch
            {
                ;
            }
        }


            //delete suggestion
            public int DelSuggestion(long? id)
            {
                var q = (from i in db.Tbl_criticsAndSuggestions where i.criticsAndSuggestionsID == id select i).SingleOrDefault();
                if (q != null)
                {
                    q.DeleteStatus = true;
                    db.Tbl_criticsAndSuggestions.Update(q);
                    db.SaveChanges();
                    return 1;
                }
                else
                {
                    return 0;
                }

            }



            //delete selected suggestion
            public int DelAllSuggestions(string deleteItems)
            {
                if (deleteItems != null)
                {
                    try
                    {

                        string strValue = deleteItems;
                        string[] strArray = strValue.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

                        foreach (var obj in strArray)
                        {
                            var q = (from i in db.Tbl_criticsAndSuggestions where i.criticsAndSuggestionsID == long.Parse(obj) select i).SingleOrDefault();
                            //your delete query
                            q.DeleteStatus = true;
                            db.Tbl_criticsAndSuggestions.Update(q);
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
