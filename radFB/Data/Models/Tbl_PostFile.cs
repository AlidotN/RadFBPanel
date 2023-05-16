namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_PostFile
    {
        [Key]
        public long postFileID { get; set; }

        public long fk_postID { get; set; }

        public string FileAddress { get; set; }

        public string picAddress { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_post Tbl_post { get; set; }
    }
}
