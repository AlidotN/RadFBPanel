namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_messageType
    {
        public Tbl_messageType()
        {
            this.GroupMessages = new HashSet<Tbl_groupMessages>();
            this.Messages = new HashSet<Tbl_messages>();
        }

        [Key]
        public long messageTypeID { get; set; }

        public string messageTypeTitle { get; set; }

        public virtual ICollection<Tbl_groupMessages> GroupMessages { get; set; }

        public virtual ICollection<Tbl_messages> Messages { get; set; }
    }
}
