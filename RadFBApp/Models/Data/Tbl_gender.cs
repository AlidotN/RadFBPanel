namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_gender
    {
        public Tbl_gender()
        {
            this.EmploymentAdvPosts = new HashSet<Tbl_EmploymentAdvPost>();
            this.Posters = new HashSet<Tbl_poster>();
            this.PosterFilters = new HashSet<Tbl_posterFilter>();
            this.RealClients = new HashSet<Tbl_RealCient>();
        }

        [Key]
        public int GenderID { get; set; }

        public string PrGenderTitle { get; set; }

        public string EnGenderTitle { get; set; }

        public virtual ICollection<Tbl_EmploymentAdvPost> EmploymentAdvPosts { get; set; }
        public virtual ICollection<Tbl_poster> Posters { get; set; }

        public virtual ICollection<Tbl_posterFilter> PosterFilters { get; set; }

        public virtual ICollection<Tbl_RealCient> RealClients { get; set; }
    }
}
