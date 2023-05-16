namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_awards
    {
        [Key]
        public long awardsID { get; set; }

        public string awardsTitle { get; set; }

        public bool DeleteStatus { get; set; }

        public long fk_userID { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
