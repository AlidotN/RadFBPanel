namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_VisitedPosts
    {
        [Key]
        public long VisitedPostsID { get; set; }

        public long fk_UserID { get; set; }

        public long fk_PostID { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_PostID")]
        public Tbl_post Posts { get; set; }

    }
}
