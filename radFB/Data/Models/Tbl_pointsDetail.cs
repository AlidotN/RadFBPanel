namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_pointsDetail
    {
        [Key]
        public long pointsDetailID { get; set; }

        public string pointDetailDate { get; set; }

        public long subPoint { get; set; }

        public string pointSubDate { get; set; }

        public long sumPoint { get; set; }

        public long fk_pointID { get; set; }

        public long fk_userID { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_points Tbl_points { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
