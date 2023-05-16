namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_memberOfGroup
    {
        [Key]
        public long memberOfGroupID { get; set; }

        public long fk_UserID { get; set; }

        public long fk_groupID { get; set; }

        public virtual Tbl_group Tbl_group { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
