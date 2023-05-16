using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.ViewModels
{
    public class VmUnauthorizedWords
    {
        public long wordID { get; set; }

        public string creatorUser { get; set; }

        public string date { get; set; }

        public string word { get; set; }
    }
}
