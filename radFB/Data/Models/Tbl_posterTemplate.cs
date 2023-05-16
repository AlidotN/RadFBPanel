namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Tbl_posterTemplate
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_posterTemplate()
        {
            Tbl_poster = new HashSet<Tbl_poster>();
        }

        [Key]
        public long posterTemplateID { get; set; }

        public string posterName { get; set; }

        public string posterDescription { get; set; }

        public string posterFileAddress { get; set; }

        public string templatePic { get; set; }

        public bool DeleteStatus { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_poster> Tbl_poster { get; set; }
    }
}
