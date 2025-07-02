namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_AnswerToQuestion
    {
        public Tbl_AnswerToQuestion() 
        {
            this.CommentLikes = new HashSet<Tbl_CommentLike>();
        }

        [Key]
        public long ParentID { get; set; }

        public long ChildID { get; set; }

        public string postDescription { get; set; }

        public string RegisterDate { get; set; }

        public string RegisterTime { get; set; }

        public long fk_UserID { get; set; }

        public long fk_QuestiontID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        [ForeignKey("fk_QuestiontID")]
        public Tbl_Question Questions { get; set; }

        public virtual ICollection<Tbl_CommentLike> CommentLikes { get; set; }

    }
}
