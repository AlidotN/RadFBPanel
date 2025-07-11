﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmRadfbUsers
    {
        public long RadFbUserID { get; set; }

        public string UserPic { get; set; }

        public string fullName { get; set; }

        public string phoneNumber { get; set; }

        public string email { get; set; }

        public string userType { get; set; }

        public int UserTypeID { get; set; }

        public string lastSeenDate { get; set; }

        public string userStatus { get; set; }
    }
}
