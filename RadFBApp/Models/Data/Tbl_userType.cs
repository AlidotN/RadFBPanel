namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_userType
    {
        public Tbl_userType()
        {
            this.Users = new HashSet<Tbl_RadFBUsers>();
        }

        [Key]
        public int userTypeID { get; set; }

        public string PrUserTypeName { get; set; }

        public string EnUserTypeName { get; set; }

        public virtual ICollection<Tbl_RadFBUsers> Users { get; set; }
    }
}
