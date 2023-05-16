namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_story
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_story()
        {
            Tbl_storySeen = new HashSet<Tbl_storySeen>();
        }

        [Key]
        public long storyID { get; set; }

       

        public string storyPicture { get; set; }

        public string storySong { get; set; }

        public string stroryDate { get; set; }

        public string storyTime { get; set; }

        public bool storyStatus { get; set; }

        public long fk_userID { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_storySeen> Tbl_storySeen { get; set; }
    }
}
