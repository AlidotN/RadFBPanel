namespace RadFBApp.Models.Data
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

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_storyID")]
        public Tbl_story Stories { get; set; }
    }
}
