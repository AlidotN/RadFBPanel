namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_group
    {
        public Tbl_group()
        {
            this.GroupExceptions = new HashSet<Tbl_groupException>();
            this.GroupMessages = new HashSet<Tbl_groupMessages>();
            this.MemberOfGroups = new HashSet<Tbl_memberOfGroup>();
            this.MuteGroupMessages = new HashSet<Tbl_muteGroupMessage>();
        }

        [Key]
        public long groupID { get; set; }

        public string groupTitle { get; set; }

        public string description { get; set; }

        public long fk_creatorUserID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_creatorUserID")]
        public Tbl_RadFBUsers Users { get; set; }

        public virtual ICollection<Tbl_groupException> GroupExceptions { get; set; }

        public virtual ICollection<Tbl_groupMessages> GroupMessages { get; set; }

        public virtual ICollection<Tbl_memberOfGroup> MemberOfGroups { get; set; }

        public virtual ICollection<Tbl_muteGroupMessage> MuteGroupMessages { get; set; }
    }
}
