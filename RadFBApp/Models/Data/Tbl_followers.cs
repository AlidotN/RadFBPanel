namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_followers
    {
        [Key]
        public long followersID { get; set; }

        public long fk_UserID { get; set; }

        public long fk_followerUSerID { get; set; }

        public bool seePostsAllow { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

    }
}
