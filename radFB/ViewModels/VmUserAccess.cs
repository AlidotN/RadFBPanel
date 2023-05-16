using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.ViewModels
{
    public class VmUserAccess
    {
        public int userAccessID { get; set; }

        [Required]
        public string userAccessTitle { get; set; }

        public bool setting { get; set; }

        public bool users { get; set; }

        public bool groups { get; set; }

        public bool posts { get; set; }

        public bool financialDepartment { get; set; }

        public bool templates { get; set; }

        public bool reports { get; set; }

        public bool connectUsers { get; set; }

        public bool frequently { get; set; }

        public bool usersAdminPanel { get; set; }

        public bool deleteInformation { get; set; }
    }
}
