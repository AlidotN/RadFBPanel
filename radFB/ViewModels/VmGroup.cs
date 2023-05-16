using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.ViewModels
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
