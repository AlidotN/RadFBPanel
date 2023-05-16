namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_silentUsers
    {
        [Key]
        public long silentUserID { get; set; }

        public long fk_userID { get; set; }

        public long fk_silentUSerID { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers1 { get; set; }
    }
}
