using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmLegalClient
    {
        public long legalClientID { get; set; }

        public string email { get; set; }

        public string phoneNumber { get; set; }

        public string companyName { get; set; }

        public string RegisterNumber { get; set; }

        public string CEOName { get; set; }

        public string natioalCode { get; set; }

        public string province { get; set; }

        public string city { get; set; }

        public string interdusedEmail { get; set; }

        public string UserPic { get; set; }

        public string membersCount { get; set; }

        public string DateOfEstablishment { get; set; }

        public string companyType { get; set; }
    }
}
