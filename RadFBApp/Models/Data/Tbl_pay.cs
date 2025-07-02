namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_pay
    {
        public Tbl_pay()
        {
            this.Tbl_factor = new HashSet<Tbl_factor>();
            this.UsersPackages = new HashSet<Tbl_UsersPackage>();
        }

        [Key]
        public long payID { get; set; }

        public long fk_userID { get; set; }

        public long fk_permiumPackageID { get; set; }

        public long price { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_permiumPackageID")]
        public Tbl_permiumPackage PermiumPackages { get; set; }

        public virtual ICollection<Tbl_factor> Tbl_factor { get; set; }
        public virtual ICollection<Tbl_UsersPackage> UsersPackages { get; set; }


    }
}
