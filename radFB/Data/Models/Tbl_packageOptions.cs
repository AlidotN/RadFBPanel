namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_packageOptions
    {
        [Key]
        public long packageOptionsID { get; set; }

        public long fk_settingID { get; set; }

        public long fk_permiumPackageID { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_permiumPackage Tbl_permiumPackage { get; set; }

        public virtual Tbl_setting Tbl_setting { get; set; }
    }
}
