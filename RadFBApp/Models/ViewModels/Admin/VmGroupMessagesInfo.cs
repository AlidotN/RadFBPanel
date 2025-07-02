using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmGroupMessagesInfo
    {
        public long groupId { get; set; }

        public long messageId { get; set; }

        public string senderName { get; set; }

        public string date { get; set; }

        public string time { get; set; }

        public string messageText { get; set; }
    }
}
