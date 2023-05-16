namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
  

    public partial class Tbl_post
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Tbl_post()
        {
            Tbl_EmploymentAdvApply = new HashSet<Tbl_EmploymentAdvApply>();
            Tbl_EmploymentAdvPost = new HashSet<Tbl_EmploymentAdvPost>();
            Tbl_keyWords = new HashSet<Tbl_keyWords>();
            Tbl_PostFile = new HashSet<Tbl_PostFile>();
            Tbl_PostForward = new HashSet<Tbl_PostForward>();
            Tbl_PostLike = new HashSet<Tbl_PostLike>();
            Tbl_Question = new HashSet<Tbl_Question>();
            Tbl_questionnaire = new HashSet<Tbl_questionnaire>();
            Tbl_VisitedPosts = new HashSet<Tbl_VisitedPosts>();
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

        public virtual postType postType { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_EmploymentAdvApply> Tbl_EmploymentAdvApply { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_keyWords> Tbl_keyWords { get; set; }

        public virtual Tbl_RadFBUsers Tbl_RadFBUsers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PostFile> Tbl_PostFile { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PostForward> Tbl_PostForward { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_PostLike> Tbl_PostLike { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_Question> Tbl_Question { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_questionnaire> Tbl_questionnaire { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Tbl_VisitedPosts> Tbl_VisitedPosts { get; set; }
    }
}
