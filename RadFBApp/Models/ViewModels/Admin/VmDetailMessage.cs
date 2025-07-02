using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmDetailMessage
    {
        public long userID { get; set; }

        public long MessageID { get; set; }

        public string FullName { get; set; }

        public string date { get; set; }

        public string Time { get; set; }

        public string Text { get; set; }


    }
}
