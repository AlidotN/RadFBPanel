namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_keyWords
    {
        [Key]
        public long keyWordID { get; set; }

        public long fk_postID { get; set; }

        public string keyWord { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual Tbl_post Tbl_post { get; set; }
    }
}
