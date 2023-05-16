namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_Logins
    {
        [Key]
        public long LoginID { get; set; }

        public string deviceCode { get; set; }

        public string loginDate { get; set; }

        public string loginTime { get; set; }

        public long fk_userID { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
