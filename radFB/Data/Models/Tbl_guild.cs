namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_guild
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_guild()
        {
            Tbl_jobCategory = new HashSet<Tbl_jobCategory>();
        }

        [Key]
        public long guildID { get; set; }

        public string FAguildNAme { get; set; }

        public string EnguildNAme { get; set; }

        public string guildColor { get; set; }

        public bool DeleteStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_jobCategory> Tbl_jobCategory { get; set; }
    }
}
