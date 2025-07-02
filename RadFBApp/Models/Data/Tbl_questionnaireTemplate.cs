namespace RadFBApp.Models.Data
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;


    public class Tbl_questionnaireTemplate
    {
        [Key]
        public long questionnaireTemplateID { get; set; }

        public string questionnaireTemplateTitle { get; set; }

        public string questionnaireTemplateDescription { get; set; }

        public long fk_jobCategoryID { get; set; }

        public string questionnaireTemplateAddress { get; set; }

        public bool DeleteStatus { get; set; }


        [ForeignKey("fk_jobCategoryID")]
        public Tbl_jobCategory JobCategories { get; set; }
    }
}
