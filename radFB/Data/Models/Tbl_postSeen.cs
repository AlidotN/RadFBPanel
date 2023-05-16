namespace radFB.db
{
    using System;
using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
using System.Threading.Tasks;


    public class Tbl_postSeen
    {
        [Key]
        public long postSeenID { get; set; }

        public long fk_userID { get; set; }

        public long fk_postID { get; set; }
    }
}
