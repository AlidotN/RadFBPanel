namespace radFB.db
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
 

    public partial class Tbl_province
    {
        [Key]
        public long provinceID { get; set; }

        public string provinceName { get; set; }

        public int? fk_countryID { get; set; }

        public virtual Tbl_countries Tbl_countries { get; set; }
    }
}
