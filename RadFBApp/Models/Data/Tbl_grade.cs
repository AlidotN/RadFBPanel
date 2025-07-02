namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_grade
    {
        public Tbl_grade()
        {
            this.EmploymentAdvPosts = new HashSet<Tbl_EmploymentAdvPost>();
            this.UserEducationalBackgrounds = new HashSet<Tbl_UserEducationalBackground>();
        }

        [Key]
        public long gradeID { get; set; }

        public string PrGradeTitle { get; set; }

        public string EnGradeTitle { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual ICollection<Tbl_EmploymentAdvPost> EmploymentAdvPosts { get; set; }

        public virtual ICollection<Tbl_UserEducationalBackground> UserEducationalBackgrounds { get; set; }
    }
}
