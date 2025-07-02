using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmPost
    {
        public long postChangedID { get; set; }

        public IFormFile postChangedPic { get; set; }

        public string postChangedExplain { get; set; }

        public bool postChangedStatus { get; set; }

        public long fk_userID { get; set; }
    }
}
