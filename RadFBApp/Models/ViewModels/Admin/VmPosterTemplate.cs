using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmPosterTemplate
    {
        public long posterTemplateID { get; set; }

        public string posterName { get; set; }

        public string posterDescription { get; set; }

        public IFormFile posterFileAddress { get; set; }

        public bool DeleteStatus { get; set; }
    }
}
