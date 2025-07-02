using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmSearchPoster
    {
        public string posterTitle { get; set; }

        public string posterSubject { get; set; }

        public string posterContacts { get; set; }

        public string posterAddress { get; set; }

        public string posterPhoneNumber { get; set; }

        public string posterDegree { get; set; }

        public string posterPrerequisites { get; set; }

        public string posterOtherThings { get; set; }

        public string country  { get; set; }

        public string posterCity { get; set; }

        public string posterStartDate { get; set; }

        public string posterEndDate { get; set; }

        public int OnlineOflineStatus { get; set; }

        public string gender { get; set; }

        public int PosterCapacity { get; set; }

        public string posterCoust { get; set; }

        public string posterType { get; set; }

        public string daysOfWeek { get; set; }

        public string timesOfDay { get; set; }

        public string user { get; set; }

        public int posterStatus { get; set; }
    }
}
