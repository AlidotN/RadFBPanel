namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_userBackGroundSetting
    {
        [Key]
        public long userBackGroundSettingID { get; set; }

        public long fk_userID { get; set; }

        public string pic { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }
    }
}
