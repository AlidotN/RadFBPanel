namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_militaryServiceSituation
    {
        public Tbl_militaryServiceSituation()
        {
            this.Tbl_EmploymentAdvPost = new HashSet<Tbl_EmploymentAdvPost>();
            this.RealClients = new HashSet<Tbl_RealCient>();
        }

        [Key]
        public long mssID { get; set; }

        public string prMSS { get; set; }

        public string enMSS { get; set; }

        public virtual ICollection<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }
        public virtual ICollection<Tbl_RealCient> RealClients { get; set; }
    }
}
