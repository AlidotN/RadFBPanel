namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_Skills
    {
        public Tbl_Skills()
        {
            this.UsersSkills = new HashSet<Tbl_UsersSkills>();
        }

        [Key]
        public long SkillID { get; set; }

        public string PrSkillTitle { get; set; }

        public string EnSkillTitle { get; set; }

        public virtual ICollection<Tbl_UsersSkills> UsersSkills { get; set; }
    }
}
