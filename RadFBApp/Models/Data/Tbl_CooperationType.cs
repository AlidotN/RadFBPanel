namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_CooperationType
    {
        public Tbl_CooperationType()
        {
            this.Tbl_EmploymentAdvPost = new HashSet<Tbl_EmploymentAdvPost>();
            this.RealClients = new HashSet<Tbl_RealCient>();
        }

        [Key]
        public int CooperationID { get; set; }

        public string PrCooperationName { get; set; }

        public string EnCooperationName { get; set; }

        public virtual ICollection<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }

        public virtual ICollection<Tbl_RealCient> RealClients { get; set; }
    }
}
