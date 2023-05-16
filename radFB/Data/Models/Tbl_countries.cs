namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_countries
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_countries()
        {
            Tbl_EmploymentAdvPost = new HashSet<Tbl_EmploymentAdvPost>();
            Tbl_poster = new HashSet<Tbl_poster>();
            Tbl_posterFilter = new HashSet<Tbl_posterFilter>();
            Tbl_province = new HashSet<Tbl_province>();
            Tbl_RadFBUsers = new HashSet<Tbl_RadFBUsers>();
        }

        [Key]
        public int countryID { get; set; }

        public string countryName { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_poster> Tbl_poster { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_posterFilter> Tbl_posterFilter { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_province> Tbl_province { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_RadFBUsers> Tbl_RadFBUsers { get; set; }
    }
}
