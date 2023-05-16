using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace radFB.ViewModels
{
    public class VmDiscont
    {
        public long discountID { get; set; }

        public string discountTitle { get; set; }

        public int discountPercent { get; set; }

        public string endDate { get; set; }
    }
}
