namespace RadFBApp.Models.Data
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

        [ForeignKey("fk_settingID")]
        public Tbl_setting Settings { get; set; }

        [ForeignKey("fk_permiumPackageID")]
        public Tbl_permiumPackage PermiumPackages { get; set; }

    }
}
