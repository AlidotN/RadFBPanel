namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_major
    {
        public Tbl_major()
        {
            this.UserEducationalBackgrounds = new HashSet<Tbl_UserEducationalBackground>();
        }

        [Key]
        public long majorID { get; set; }

        [StringLength(50)]
        public string PrMajorTitle { get; set; }

        [StringLength(50)]
        public string EnMajorTitle { get; set; }

        public virtual ICollection<Tbl_UserEducationalBackground> UserEducationalBackgrounds { get; set; }
    }
}
