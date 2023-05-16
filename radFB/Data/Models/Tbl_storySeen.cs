namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_storySeen
    {
        [Key]
        public long storySeenID { get; set; }

        public long fk_userID { get; set; }

        public long fk_storyID { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_story Tbl_story { get; set; }
    }
}
