namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_privacy
    {
        [Key]
        public long privacyID { get; set; }

        public bool privateMode { get; set; }

        public bool QuestionAnswer { get; set; }

        public bool mention { get; set; }

        public bool addToGroup { get; set; }

        public bool LastSeen { get; set; }

        public bool profilePhoto { get; set; }

        public long fk_userID { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }
    }
}
