using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.ViewModels.Admin
{
    public class VmUserReports
    {
        public long ID { get; set; }

        public string userType { get; set; }

        public string userName { get; set; }

        public string tell { get; set; }

        public string email { get; set; }

        public int postCount { get; set; }

        public int answerToQuestionCount { get; set; }

        public int advPostCount { get; set; }

        public int answerToAdvCount { get; set; }

        public int bookCount { get; set; }

        public int questionCount { get; set; }

        public int articleCount { get; set; }

        public int questinierCount { get; set; }

        public int answerToquestinierCount { get; set; }

        public int posterParticipateCount { get; set; }
    }
}
