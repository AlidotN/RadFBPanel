namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_userSetting
    {
        [Key]
        public long userSettingID { get; set; }

        public long fk_settingID { get; set; }

        public long fk_userID { get; set; }

        public bool settingStatus { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_setting Tbl_setting { get; set; }
    }
}
