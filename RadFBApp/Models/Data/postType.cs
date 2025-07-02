namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    

    [Table("postType")]
    public partial class postType
    {
        public postType()
        {
            Posts = new HashSet<Tbl_post>();
        }

        public long PostTypeID { get; set; }

        public string FaPostTypeTitle { get; set; }

        public string EnPostTypeTitle { get; set; }

        public virtual ICollection<Tbl_post> Posts { get; set; }
    }
}
