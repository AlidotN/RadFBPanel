namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_messages
    {
        [Key]
        public long messageID { get; set; }

        public string messageText { get; set; }

        public string messageDate { get; set; }

        public bool messageIsSeen { get; set; }

        public long fk_ReciverUserID { get; set; }

        public long fk_senderUserID { get; set; }

        public string MessageTime { get; set; }

        public long fk_messageTypeID { get; set; }

        public string MessagePicture { get; set; }

        public string MessageVoice { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_ReciverUserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_messageTypeID")]
        public Tbl_messageType MessageTypes { get; set; }

    }
}
