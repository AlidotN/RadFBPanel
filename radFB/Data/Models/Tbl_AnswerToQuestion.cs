namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_AnswerToQuestion
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_AnswerToQuestion()
        {
            Tbl_AnswerToQuestion1 = new HashSet<Tbl_AnswerToQuestion>();
            Tbl_CommentLike = new HashSet<Tbl_CommentLike>();
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_AnswerToQuestion> Tbl_AnswerToQuestion1 { get; set; }

        public virtual Tbl_AnswerToQuestion Tbl_AnswerToQuestion2 { get; set; }

        public virtual Tbl_Question Tbl_Question { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_CommentLike> Tbl_CommentLike { get; set; }
    }
}
