namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_BlockedUsers
    {
        [Key]
        public long BlockedUsersID { get; set; }

        public long fk_BlockingUSerID { get; set; }

        public long fk_BlockedUserID { get; set; }

        public string BlockExplantion { get; set; }

        [ForeignKey("fk_BlockingUSerID")]
        public Tbl_RadFBUsers Users { get; set; }
    }
}
