using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.db
{
    public partial class maritalStatus
    {
        [Key]
        public int maritalstatusID { get; set; }

        public string FaMaritalstatusTitle { get; set; }

        public string EnMaritalstatusTitle { get; set; }
    }
}
