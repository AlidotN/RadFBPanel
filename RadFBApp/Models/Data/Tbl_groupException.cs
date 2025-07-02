namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_groupException
    {
        [Key]
        public long groupExceptionID { get; set; }

        public long fk_userID { get; set; }

        public long fk_ExecptionGroupID { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_ExecptionGroupID")]
        public Tbl_group Groups { get; set; }

    }
}
