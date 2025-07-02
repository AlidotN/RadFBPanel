using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmFinance
    {
        public long id { get; set; }

        public string username { get; set; }

        public string tell { get; set; }

        public string packageName { get; set; }

        public string price { get; set; }

        public string date { get; set; }

        public int status { get; set; }

        public bool active { get; set; }
    }
}
