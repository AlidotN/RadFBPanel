using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RadFBApp.Models.ViewModels.Admin;
using RadFBApp.Models.Data;
using RadFBApp.Models;

namespace RadFBApp.Areas.Panel.Repository
{
    public class RepSetting
    {
        ApplicationDbContext db = new ApplicationDbContext();


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
