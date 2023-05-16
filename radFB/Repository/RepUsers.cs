using radFB.db;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.Repository
{
    public class RepUsers
    {
        ApplicationDbContext database = new ApplicationDbContext();

        public long getCount()
        {
            int count = (from i in database.Users select i).Count();
            return count;
        }

        public string getPic(string email)
        {
            string pic = (from i in database.Users where i.Email == email select i.UserPic).ToString();
            return pic;
        }


    }
}
