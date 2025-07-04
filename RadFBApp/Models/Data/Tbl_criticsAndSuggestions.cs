namespace RadFBApp.Models.Data
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;


    public partial class Tbl_criticsAndSuggestions
    {
        [Key]
        public long criticsAndSuggestionsID { get; set; }

        public string txtMessage { get; set; }

        public bool Confirmation { get; set; }

        public string RegisterDate { get; set; }

        public long fk_senderUserID { get; set; }

        public bool DeleteStatus { get; set; }


        [ForeignKey("fk_senderUserID")]
        public Tbl_RadFBUsers Users { get; set; }


    }
}
