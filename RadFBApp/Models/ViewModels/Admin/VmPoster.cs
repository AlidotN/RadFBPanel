using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmPoster
    {
        public long posterID { get; set; }

        public long fk_userID { get; set; }

        public string posterType { get; set; }

        public string posterContacts { get; set; }

        public string posterAddress { get; set; }

        public string posterPhoneNumber { get; set; }

        public bool posterStatus { get; set; }

        public string posterTitle { get; set; }
    }
}
