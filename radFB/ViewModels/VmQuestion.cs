using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.ViewModels
{
    public class VmQuestion
    {
        public long ID { get; set; }

        public string name { get; set; }

        public string textTitle { get; set; }

        public string subject { get; set; }

        public string category { get; set; }

        public string pic { get; set; }

        public string date { get; set; }

        public string time { get; set; }

        public int answerCount { get; set; }
    }
}
