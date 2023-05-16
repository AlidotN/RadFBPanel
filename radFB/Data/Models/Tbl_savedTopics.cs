namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_savedTopics
    {
        [Key]
        public long savedTopicsID { get; set; }

        public long fk_userID { get; set; }

        public long fk_subjectID { get; set; }

        public bool savedTopicStatus { get; set; }

        public bool questionOrQuestionnaire { get; set; }

        public bool ShowOrHide { get; set; }

        public bool PinStatus { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        public virtual Tbl_subject Tbl_subject { get; set; }
    }
}
