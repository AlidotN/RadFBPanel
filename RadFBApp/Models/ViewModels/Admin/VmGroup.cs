using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmGroup
    {
        public long groupID { get; set; }

        public string GroupTitle { get; set; }

        public int groupsMember { get; set; }

        public long messagesCount { get; set; }

        public string creatorUser { get; set; }
    }
}
