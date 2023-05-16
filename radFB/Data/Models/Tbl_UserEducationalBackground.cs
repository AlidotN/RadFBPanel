namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_UserEducationalBackground
    {
        [Key]
        public long UserEduBackID { get; set; }

        public string InstituteName { get; set; }

        public string FromDate { get; set; }

        public string UpToDate { get; set; }

        public long fk_majorID { get; set; }

        public long fk_gradeID { get; set; }

        public long fk_UserID { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_grade Tbl_grade { get; set; }

        public virtual Tbl_major Tbl_major { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
