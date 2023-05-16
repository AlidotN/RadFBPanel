using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.ViewModels
{
    public class VmGroupMembersInfo
    {
        public long GroupID { get; set; }

        public long memberID { get; set; }

        public string memberName { get; set; }

        public string memberPhoneNumber { get; set; }

        public long memberMessagesCount { get; set; }
    }
}
