namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_siteSetting
    {
        [Key]
        public int    siteSettingID { get; set; }

        public string PrAboutUS { get; set; }

        public string enAboutUS { get; set; }

        public string PrRules { get; set; }

        public string enRules { get; set; }

        public string phoneNumbers { get; set; }

        public string Email { get; set; }

        public string TelegramID { get; set; }

        public string WhatsAppPhoneNumber { get; set; }

        public string instagramID { get; set; }

        public int    allowedBlock { get; set; }

        public string PrDemo { get; set; }

        public string EnDemo { get; set; }

        public string postsShowTime { get; set; }

        public int    groupsMemberCount { get; set; }

        public int    TitleAllowedCharacterCount { get; set; }

        public int    DescriptionAllowedCharacterCount { get; set; }
    }
}
