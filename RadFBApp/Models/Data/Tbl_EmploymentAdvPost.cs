namespace RadFBApp.Models.Data
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


        [ForeignKey("fk_CooperationTypeID")]
        public Tbl_CooperationType CooperationTypes { get; set; }
        [ForeignKey("fk_countryID")]
        public Tbl_countries Countries { get; set; }
        [ForeignKey("fk_provinceID")]
        public Tbl_province Provinces { get; set; }
        [ForeignKey("fk_jobCategoryID")]
        public Tbl_jobCategory JobCategories { get; set; }
        [ForeignKey("fk_PostID")]
        public Tbl_post Posts { get; set; }
        [ForeignKey("fk_genderID")]
        public Tbl_gender Genders { get; set; }
        [ForeignKey("fk_grageID")]
        public Tbl_grade Grades { get; set; }
        [ForeignKey("fk_mssID")]
        public Tbl_militaryServiceSituation MilitaryServices { get; set; }

    }
}
