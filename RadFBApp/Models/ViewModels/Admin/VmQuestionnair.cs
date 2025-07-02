using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmQuestionnair
    {
        public long ID { get; set; }

        public string name { get; set; }

        public string title { get; set; }

        public string JobCategory { get; set; }

        public string date { get; set; }

        public string subject { get; set; }

        public string benefit { get; set; }

        public string address { get; set; }

        public bool status { get; set; }

        public int answerType { get; set; }
    }
}
