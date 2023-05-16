namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
   

    public partial class Tbl_UnauthorizedWords
    {
        [Key]
        public long UnauthorizedWordsID { get; set; }

        public string prWord { get; set; }

        public string enWord { get; set; }

        public string registerDate { get; set; }

        public string fk_ApplicationUser { get; set; }
    }
}
