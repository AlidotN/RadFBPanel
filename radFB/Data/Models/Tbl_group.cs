namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_group
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_group()
        {
            Tbl_groupException = new HashSet<Tbl_groupException>();
            Tbl_groupMessages = new HashSet<Tbl_groupMessages>();
            Tbl_memberOfGroup = new HashSet<Tbl_memberOfGroup>();
            Tbl_muteGroupMessage = new HashSet<Tbl_muteGroupMessage>();
        }

        [Key]
        public long groupID { get; set; }

        public string groupTitle { get; set; }

        public string description { get; set; }

        public long fk_creatorUserID { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_groupException> Tbl_groupException { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_groupMessages> Tbl_groupMessages { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_memberOfGroup> Tbl_memberOfGroup { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_muteGroupMessage> Tbl_muteGroupMessage { get; set; }
    }
}
