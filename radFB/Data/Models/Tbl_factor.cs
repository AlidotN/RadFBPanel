namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_factor
    {
        [Key]
        public long factorID { get; set; }

        public long fk_payID { get; set; }

        public long price { get; set; }

        public string description { get; set; }

        public string Authority { get; set; }

        public string TrackingCode { get; set; }

        public int status { get; set; }

        public string Email { get; set; }

        public string phoneNumber { get; set; }

        public bool DeleteStatus { get; set; }

        public string date { get; set; }

        public virtual Tbl_pay Tbl_pay { get; set; }
    }
}
