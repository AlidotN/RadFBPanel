namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_UsersSkills
    {
        [Key]
        public long UsersSkillsID { get; set; }

        public long fk_SkillID { get; set; }

        public long fk_UserID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_SkillID")]
        public Tbl_Skills Skills { get; set; }
    }
}
