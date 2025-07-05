using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmFreQuestions
    {
        public long FreQuestionsID { get; set; }

        public string PrQuestion { get; set; }

        public string PrAnswer { get; set; }

        public string EnQuestion { get; set; }

        public string EnAnswer { get; set; }

        public bool Status { get; set; }

        public string SubjectName { get; set; }
        
    }
}
