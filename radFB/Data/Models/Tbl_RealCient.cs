namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_RealCient
    {
        [Key]
        public long RealClientID { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string birthday { get; set; }

        public string aboutMe { get; set; }

        public string suggestSAlary { get; set; }

        public bool companyDesire { get; set; }

        public int fk_GenderID { get; set; }

        public long fk_mssID { get; set; }

        public int fk_CooperationID { get; set; }

        public bool DeleteStatus { get; set; }

        public int Fk_maritalstatus { get; set; }

        public long fk_UserID { get; set; }

        public virtual Tbl_CooperationType Tbl_CooperationType { get; set; }

        public virtual Tbl_gender Tbl_gender { get; set; }

        public virtual Tbl_militaryServiceSituation Tbl_militaryServiceSituation { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
