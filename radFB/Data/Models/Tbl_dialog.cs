namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_dialog
    {
        [Key]
        public long notificationID { get; set; }

        public string prnotificationTitle { get; set; }

        public string enNotificationTitle { get; set; }

        public string prNotificationText { get; set; }

        public string enNotificationText { get; set; }

        public bool DeleteStatus { get; set; }
    }
}
