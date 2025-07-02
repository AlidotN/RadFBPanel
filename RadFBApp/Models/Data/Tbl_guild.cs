namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_guild
    {
        public Tbl_guild()
        {
            this.jobCategories = new HashSet<Tbl_jobCategory>();
        }

        [Key]
        public long guildID { get; set; }

        public string FAguildNAme { get; set; }

        public string EnguildNAme { get; set; }

        public string guildColor { get; set; }

        public bool DeleteStatus { get; set; }

        public virtual ICollection<Tbl_jobCategory> jobCategories { get; set; }
    }
}
