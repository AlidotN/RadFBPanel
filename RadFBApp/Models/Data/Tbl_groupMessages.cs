namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Tbl_groupMessages
    {
        [Key]
        public long groupMessagesID { get; set; }

        public string groupMessageText { get; set; }

        public string groupMessageDate { get; set; }

        public bool groupMessageIsSeen { get; set; }

        public long fk_groupID { get; set; }

        public long fk_senderUserID { get; set; }

        public string groupMessageTime { get; set; }

        public long fk_messageTypeID { get; set; }

        public string groupMessagePicture { get; set; }

        public string groupMessageVoice { get; set; }

        [ForeignKey("fk_groupID")]
        public Tbl_group Groups { get; set; }

        [ForeignKey("fk_senderUserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_messageTypeID")]
        public Tbl_messageType MessageTypes { get; set; }
    }
}
