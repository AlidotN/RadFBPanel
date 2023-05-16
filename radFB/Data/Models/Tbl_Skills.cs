namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_Skills
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_Skills()
        {
            Tbl_UsersSkills = new HashSet<Tbl_UsersSkills>();
        }

        [Key]
        public long SkillID { get; set; }

        public string PrSkillTitle { get; set; }

        public string EnSkillTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_UsersSkills> Tbl_UsersSkills { get; set; }
    }
}
