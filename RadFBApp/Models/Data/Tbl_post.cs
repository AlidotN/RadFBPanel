namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_post
    {
        public Tbl_post()
        {
            this.Questions = new HashSet<Tbl_Question>();
            this.EmploymentAdvApplies = new HashSet<Tbl_EmploymentAdvApply>();
            this.EmploymentAdvPosts = new HashSet<Tbl_EmploymentAdvPost>();
            this.KeyWords = new HashSet<Tbl_keyWords>();
            this.PostFiles = new HashSet<Tbl_PostFile>();
            this.PostForwards = new HashSet<Tbl_PostForward>();
            this.PostLikes = new HashSet<Tbl_PostLike>();
            this.Questionnaires = new HashSet<Tbl_questionnaire>();
            this.VisitedPosts = new HashSet<Tbl_VisitedPosts>();
        }

        [Key]
        public long postID { get; set; }

        public string postTitle { get; set; }

        public string postDescription { get; set; }

        public string RegisterDate { get; set; }

        public string DeleteDate { get; set; }

        public bool PostConfrimStatus { get; set; }

        public long fk_PostTypeID { get; set; }

        public long fk_UserID { get; set; }

        public bool DeleteStatus { get; set; }

        [ForeignKey("fk_PostTypeID")]
        public postType PostTypes { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }

        public virtual ICollection<Tbl_Question> Questions { get; set; }
        public virtual ICollection<Tbl_EmploymentAdvApply> EmploymentAdvApplies { get; set; }
        public virtual ICollection<Tbl_EmploymentAdvPost> EmploymentAdvPosts { get; set; }
        public virtual ICollection<Tbl_keyWords> KeyWords { get; set; }

        public virtual ICollection<Tbl_PostFile> PostFiles { get; set; }

        public virtual ICollection<Tbl_PostForward> PostForwards { get; set; }

        public virtual ICollection<Tbl_PostLike> PostLikes { get; set; }

        public virtual ICollection<Tbl_questionnaire> Questionnaires { get; set; }

        public virtual ICollection<Tbl_VisitedPosts> VisitedPosts { get; set; }
    }
}
