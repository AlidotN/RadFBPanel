namespace RadFBApp.Models.Data
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

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_groupID")]
        public Tbl_group Groups { get; set; }
    }
}
