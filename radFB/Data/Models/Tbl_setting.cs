namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_setting
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_setting()
        {
            Tbl_packageOptions = new HashSet<Tbl_packageOptions>();
            Tbl_userSetting = new HashSet<Tbl_userSetting>();
        }

        [Key]
        public long settingID { get; set; }

        public string prSettingTitle { get; set; }

        public string enSettingTitle { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_packageOptions> Tbl_packageOptions { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_userSetting> Tbl_userSetting { get; set; }
    }
}
