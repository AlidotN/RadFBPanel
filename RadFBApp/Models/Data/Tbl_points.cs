namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_points
    {
        public Tbl_points()
        {
            this.PointsDetails = new HashSet<Tbl_pointsDetail>();
        }

        [Key]
        public long pointID { get; set; }

        public string pointTitle { get; set; }

        public int pointValue { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual ICollection<Tbl_pointsDetail> PointsDetails { get; set; }
    }
}
