using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace RadFBApp.Models.Data
{
    public class Tbl_EmploymentAdvApply
    {
            [Key]
            public long EmploymentAdvApplyID { get; set; }

            public long fk_ApplicantUserID { get; set; }

            public long fk_postID { get; set; }

            public bool DeleteStatus { get; set; }

            [ForeignKey("fk_ApplicantUserID")]
            public Tbl_RadFBUsers Users { get; set; }

            [ForeignKey("fk_postID")]
            public Tbl_post Posts { get; set; }

    }
}
