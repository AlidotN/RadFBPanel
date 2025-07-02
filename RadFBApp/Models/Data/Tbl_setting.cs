namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    

    public partial class Tbl_setting
    {
        public Tbl_setting()
        {
            this.PackageOptions = new HashSet<Tbl_packageOptions>();
            this.UserSettings = new HashSet<Tbl_userSetting>();
        }

        [Key]
        public long settingID { get; set; }

        public string prSettingTitle { get; set; }

        public string enSettingTitle { get; set; }

        public virtual ICollection<Tbl_packageOptions> PackageOptions { get; set; }

        public virtual ICollection<Tbl_userSetting> UserSettings { get; set; }
    }
}
