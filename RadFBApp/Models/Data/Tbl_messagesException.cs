namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_messagesException
    {
        [Key]
        public long messagesExceptionID { get; set; }

        public long fk_userID { get; set; }

        public long fk_ExecptionUserID { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

    }
}
