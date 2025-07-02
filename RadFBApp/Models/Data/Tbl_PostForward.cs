namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_PostForward
    {
        [Key]
        public long PostForwardID { get; set; }

        public long fk_ForwardedUserID { get; set; }

        public long fk_ForwardingUserID { get; set; }

        public long fk_PostID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_ForwardedUserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_PostID")]
        public Tbl_post Posts{ get; set; }
    }
}
