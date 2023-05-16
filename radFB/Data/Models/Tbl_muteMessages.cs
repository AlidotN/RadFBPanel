namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_muteMessages
    {
        [Key]
        public long muteMessagesID { get; set; }

        public bool messageStatus { get; set; }

        public long? fk_ReciverUserID { get; set; }

        public long? fk_senderUserID { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers1 { get; set; }
    }
}
