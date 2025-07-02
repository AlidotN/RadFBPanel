using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmInactiveUser
    {
        public long RadFbUserID { get; set; }

        public string FullName { get; set; }

        public string phoneNumber { get; set; }

        public string email { get; set; }

        public string inactiveDate { get; set; }
    }
}
