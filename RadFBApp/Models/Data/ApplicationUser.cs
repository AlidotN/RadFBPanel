
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace RadFBApp.Models.Data
{
    public class ApplicationUser : IdentityUser
    {

        public ApplicationUser()
        {
            this.EmploymentAdvApplies = new HashSet<Tbl_EmploymentAdvApply>();
            this.UnauthorizedWords = new HashSet<Tbl_UnauthorizedWords>();
            this.UsersQuestions = new HashSet<Tbl_usersQuestions>();
            this.PanelActivities = new HashSet<Tbl_PanelActivities>();
        }


        public string FullName { get; set; }

        public string UserPic { get; set; }

        public int Fk_userAccessID { get; set; }

        public bool DeleteStatus { get; set; }



        [ForeignKey("Fk_userAccessID")]
        public Tbl_userAccess UserAccess { get; set; }
        public virtual ICollection<Tbl_EmploymentAdvApply> EmploymentAdvApplies { get; set; }
        public virtual ICollection<Tbl_UnauthorizedWords> UnauthorizedWords { get; set; }
        public virtual ICollection<Tbl_usersQuestions> UsersQuestions { get; set; }
        public virtual ICollection<Tbl_PanelActivities> PanelActivities { get; set; }




    }
}
