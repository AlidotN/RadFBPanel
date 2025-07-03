using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadFBApp.Models.Data
{
    public partial class Tbl_PanelActivities
    {
        [Key]
        public long activityID { get; set; }

        public string activityTitle { get; set; }
        public string activityTitleEN { get; set; }

        public bool DeleteStatus { get; set; }

        public string fk_userID { get; set; }
        public DateTime activityDate { get; set; }

        [ForeignKey("fk_userID")]
        public ApplicationUser Users { get; set; }

    }
}
