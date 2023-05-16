using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.ViewModels
{
    public class VmQuestionnairTemplate
    {
        public long questionnaireTemplateID { get; set; }

        public string questionnaireTemplateTitle { get; set; }

        public string questionnaireTemplateDescription { get; set; }

        public long fk_jobCategoryID { get; set; }

        public IFormFile questionnaireTemplateAddress { get; set; }

        public IFormFile templatePic { get; set; }

    }
}
