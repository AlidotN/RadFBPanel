namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_activeSesion
    {
        [Key]
        public long activeSesionID { get; set; }

        public long fk_userID { get; set; }

        public string deviceName { get; set; }

        public string deviceCode { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
