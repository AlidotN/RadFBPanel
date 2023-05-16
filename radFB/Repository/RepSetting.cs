using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using radFB.ViewModels;

namespace radFB.Repository
{
    public class RepSetting
    {
        radFB.db.ApplicationDbContext db = new db.ApplicationDbContext();


        public long skillCount()
        {
            return db.Tbl_Skills.Count();
        }

        public long catCount()
        {
            return db.Tbl_jobCategory.Count();
        }

        public long GuildCount()
        {
            var q = (from i in db.Tbl_guild where i.DeleteStatus == false select i).Count();
            return q;
        }

        public string guildName(long id)
        {
            string name = "";
            var q = (from i in db.Tbl_guild where i.guildID == id select i).SingleOrDefault();
            if (q != null)
            {
                name = q.FAguildNAme.ToString();
            }
            return name;
        }



        public long majorCount()
        {
            return db.Tbl_major.Count();
        }

        public long SubjectCount()
        {
            return db.Tbl_subject.Count();
        }

       
    }
}
