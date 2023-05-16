namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_userAccess
    {
        [Key]
        public int userAccessID { get; set; }

        public string userAccessTitle { get; set; }

        public bool setting { get; set; }

        public bool users { get; set; }

        public bool groups { get; set; }

        public bool posts { get; set; }

        public bool financialDepartment { get; set; }

        public bool templates { get; set; }

        public bool reports { get; set; }

        public bool connectUsers { get; set; }

        public bool frequently { get; set; }

        public bool usersAdminPanel { get; set; }

        public bool deleteInformation { get; set; }
    }
}
