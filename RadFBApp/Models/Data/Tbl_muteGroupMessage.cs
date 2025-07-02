namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_muteGroupMessage
    {
        [Key]
        public long muteGroupMessageID { get; set; }

        public bool messageStatus { get; set; }

        public long fk_groupID { get; set; }

        public long fk_UserID { get; set; }

        [ForeignKey("fk_groupID")]
        public Tbl_group Groups { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

    }
}
