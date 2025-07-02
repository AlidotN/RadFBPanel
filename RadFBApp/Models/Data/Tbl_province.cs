namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Tbl_province
    {
        public Tbl_province() 
        {
            this.Questions = new HashSet<Tbl_Question>();
            this.RadFBUsers = new HashSet<Tbl_RadFBUsers>();
            this.EmploymentAdvPosts = new HashSet<Tbl_EmploymentAdvPost>();
        }

        [Key]
        public long provinceID { get; set; }

        public string provinceName { get; set; }

        public int? fk_countryID { get; set; }

        [ForeignKey("fk_countryID")]
        public Tbl_countries Countries { get; set; }

        public virtual ICollection<Tbl_Question> Questions { get; set; }
        public virtual ICollection<Tbl_RadFBUsers> RadFBUsers { get; set; }
        public virtual ICollection<Tbl_EmploymentAdvPost> EmploymentAdvPosts { get; set; }


    }
}
