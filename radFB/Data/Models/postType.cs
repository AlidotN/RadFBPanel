namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    

    [Table("postType")]
    public partial class postType
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public postType()
        {
            Tbl_post = new HashSet<Tbl_post>();
        }

        public long PostTypeID { get; set; }

        public string FaPostTypeTitle { get; set; }

        public string EnPostTypeTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_post> Tbl_post { get; set; }
    }
}
