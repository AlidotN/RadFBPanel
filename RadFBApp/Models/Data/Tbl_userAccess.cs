namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_userAccess
    {
        public Tbl_userAccess() { 
            this.AppUsers = new HashSet<ApplicationUser>();
        }

        [Key]
        public int userAccessID { get; set; }

        public string userAccessTitle { get; set; }
        public string userAccessTitleEN { get; set; }

        public bool setting { get; set; }

        public bool users { get; set; }

        public bool UnauthorizedWords { get; set; }

        public bool posts { get; set; }

        public bool permiumPackage { get; set; }

        public bool financialDepartment { get; set; }

        public bool questions { get; set; }

        public bool adv { get; set; }

        public bool reports { get; set; }

        public bool criticsAndSuggestions { get; set; }

        public bool userAccessMenu { get; set; }

        public bool usersAdminPanel { get; set; }

        public bool deleteInformation { get; set; }

        public virtual ICollection<ApplicationUser> AppUsers { get; set; }
    }
}
