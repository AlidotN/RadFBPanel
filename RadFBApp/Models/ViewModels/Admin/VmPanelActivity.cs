using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmPanelActivity
    {
        public long activityID { get; set; }

        public string activityTitle { get; set; }
        public string activityTitleEN { get; set; }

        public string FullName { get; set; }
        public string activityDate { get; set; }
    }
}
