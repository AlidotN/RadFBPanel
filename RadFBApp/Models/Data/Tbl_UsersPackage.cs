
namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;


    public partial class Tbl_UsersPackage
    {
        [Key]
        public long UserPackagesID { get; set; }

        public long fk_packageID { get; set; }

        public long fk_payID { get; set; }

        public long fk_userID { get; set; }

        public string expiryDate { get; set; }

        public bool status { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_payID")]
        public Tbl_pay Pays { get; set; }

        [ForeignKey("fk_packageID")]
        public Tbl_permiumPackage PremiumPackages { get; set; }

    }

}
