namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_countries
    {
        public Tbl_countries()
        {
            this.Tbl_EmploymentAdvPost = new HashSet<Tbl_EmploymentAdvPost>();
            this.Posters = new HashSet<Tbl_poster>();
            this.PosterFilters = new HashSet<Tbl_posterFilter>();
            this.Provinces = new HashSet<Tbl_province>();
            this.Tbl_RadFBUsers = new HashSet<Tbl_RadFBUsers>();
        }

        [Key]
        public int countryID { get; set; }

        public string countryName { get; set; }

        public virtual ICollection<Tbl_EmploymentAdvPost> Tbl_EmploymentAdvPost { get; set; }

        public virtual ICollection<Tbl_poster> Posters { get; set; }

        public virtual ICollection<Tbl_posterFilter> PosterFilters { get; set; }

        public virtual ICollection<Tbl_province> Provinces { get; set; }

        public virtual ICollection<Tbl_RadFBUsers> Tbl_RadFBUsers { get; set; }
    }
}
