namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_SuggestionUsers
    {
        [Key]
        public long SuggestionUsersID { get; set; }

        public long fk_UserID { get; set; }

        public long fk_SuggestedUSerID { get; set; }

        [ForeignKey("fk_UserID")]
        public Tbl_RadFBUsers Users { get; set; }
    }
}
