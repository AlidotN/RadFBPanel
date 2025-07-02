namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Tbl_posterTemplate
    {
        public Tbl_posterTemplate()
        {
            this.Posters = new HashSet<Tbl_poster>();
        }

        [Key]
        public long posterTemplateID { get; set; }

        public string posterName { get; set; }

        public string posterDescription { get; set; }

        public string posterFileAddress { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual ICollection<Tbl_poster> Posters { get; set; }
    }
}
