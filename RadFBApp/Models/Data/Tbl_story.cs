namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_story
    {
        public Tbl_story()
        {
            this.StorySeen = new HashSet<Tbl_storySeen>();
        }

        [Key]
        public long storyID { get; set; }

       

        public string storyPicture { get; set; }

        public string storySong { get; set; }

        public string stroryDate { get; set; }

        public string storyTime { get; set; }

        public bool storyStatus { get; set; }

        public long fk_userID { get; set; }

        [ForeignKey("fk_userID")]
        public Tbl_RadFBUsers Users { get; set; }

        public virtual ICollection<Tbl_storySeen> StorySeen { get; set; }
    }
}
