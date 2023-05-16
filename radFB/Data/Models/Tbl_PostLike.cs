namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_PostLike
    {
        [Key]
        public long PostLikeID { get; set; }

        public long fk_UserID { get; set; }

        public long fk_PostID { get; set; }

        public virtual Tbl_post Tbl_post { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
