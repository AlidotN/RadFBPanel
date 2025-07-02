using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace RadFBApp.Models.Data
{
    public partial class maritalStatus
    {
        public maritalStatus()
        {
            this.RealClients = new HashSet<Tbl_RealCient>();
        }
        [Key]
        public int maritalstatusID { get; set; }

        public string FaMaritalstatusTitle { get; set; }

        public string EnMaritalstatusTitle { get; set; }


        public virtual ICollection<Tbl_RealCient> RealClients { get; set; }
    }
}
