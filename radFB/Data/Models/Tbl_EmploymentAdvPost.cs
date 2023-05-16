namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_EmploymentAdvPost
    {
        [Key]
        public long EmploymentAdvPostID { get; set; }

        public int fk_CooperationTypeID { get; set; }

        public int fk_countryID { get; set; }

        public long fk_provinceID { get; set; }

        public long fk_jobCategoryID { get; set; }

        public long fk_PostID { get; set; }

        public int fk_genderID { get; set; }

        public long fk_grageID { get; set; }

        public long fk_mssID { get; set; }

        public string salary { get; set; }

        public string SkillsReqired { get; set; }

        public string WorkExprience { get; set; }

        public bool EdvType { get; set; }

        public bool EdvStatus { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_CooperationType Tbl_CooperationType { get; set; }

        public virtual Tbl_countries Tbl_countries { get; set; }

        public virtual Tbl_gender Tbl_gender { get; set; }

        public virtual Tbl_grade Tbl_grade { get; set; }

        public virtual Tbl_jobCategory Tbl_jobCategory { get; set; }

        public virtual Tbl_militaryServiceSituation Tbl_militaryServiceSituation { get; set; }

        public virtual Tbl_post Tbl_post { get; set; }
    }
}
