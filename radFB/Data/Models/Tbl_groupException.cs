namespace radFB.db
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

        public virtual Tbl_group Tbl_group { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
