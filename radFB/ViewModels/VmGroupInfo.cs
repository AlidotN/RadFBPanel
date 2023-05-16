using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.ViewModels
{
    public class VmGroupInfo
    {
        public long groupID { get; set; }

        public string GroupTitle { get; set; }

        public string groupDescription{ get; set; }

        public string creatorUser { get; set; }

        public string phoneNumber { get; set; }
    }
}
