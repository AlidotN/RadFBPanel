namespace radFB.db
{
    using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        public string templatePic { get; set; }

        public bool DeleteStatus { get; set; }
    }
}
