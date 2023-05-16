namespace radFB.db
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

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_Skills Tbl_Skills { get; set; }
    }
}
