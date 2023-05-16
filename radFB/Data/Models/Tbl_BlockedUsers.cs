namespace radFB.db
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

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers1 { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers2 { get; set; }
    }
}
