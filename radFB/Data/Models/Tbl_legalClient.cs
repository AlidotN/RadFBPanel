namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public partial class Tbl_legalClient
    {
        [Key]
        public long legalClientID { get; set; }

        public string companyName { get; set; }

        public string RegisterNumber { get; set; }

        public string aboutCompany { get; set; }

        public string CEOName { get; set; }

        public string natioalCode { get; set; }

        public string membersCount { get; set; }

        public string DateOfEstablishment { get; set; }

        public string companyType { get; set; }

        public bool DeleteStatus { get; set; }

        public long fk_UserID { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
