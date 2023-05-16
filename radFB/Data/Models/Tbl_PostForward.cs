namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_PostForward
    {
        [Key]
        public long PostForwardID { get; set; }

        public long fk_ForwardedUserID { get; set; }

        public long fk_ForwardingUserID { get; set; }

        public long fk_PostID { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_post Tbl_post { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers1 { get; set; }
    }
}
