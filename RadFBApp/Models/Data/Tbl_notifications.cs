namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_notifications
    {
        [Key]
        public long notificationID { get; set; }

        public bool notification { get; set; }

        public bool MessageNotification { get; set; }

        public string MessageNotificationRing { get; set; }

        public bool groupNotification { get; set; }

        public string groupNotificationRing { get; set; }

        public bool postNotification { get; set; }

        public string postNotificationRing { get; set; }

        public bool AdvNotification { get; set; }

        public string AdvNotificationRing { get; set; }

        public bool QuestionNotification { get; set; }

        public string questionNotificationRing { get; set; }

        public bool appVibration { get; set; }

        public string appNotificationRing { get; set; }

        public long fk_userID { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

    }
}
