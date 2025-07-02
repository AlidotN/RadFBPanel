namespace RadFBApp.Models.Data
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

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_settingID")]
        public Tbl_setting Settings { get; set; }
    }
}
