namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_permiumPackage
    {
        public Tbl_permiumPackage()
        {
            this.PackageOptions = new HashSet<Tbl_packageOptions>();
            this.Pays = new HashSet<Tbl_pay>();
            this.UsersPackages = new HashSet<Tbl_UsersPackage>();
        }

        [Key]
        public long permiumPackageID { get; set; }

        public string permiumPackageTitle { get; set; }

        public string selectedOptions { get; set; }

        public string price { get; set; }

        public string time { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual ICollection<Tbl_packageOptions> PackageOptions { get; set; }

        public virtual ICollection<Tbl_pay> Pays { get; set; }

        public virtual ICollection<Tbl_UsersPackage> UsersPackages { get; set; }
    }
}
