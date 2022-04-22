using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShopContracts.ViewModels
{
   public  class ReportRepairComponentViewModel
    {
        public string RepairName { get; set; }
        public int TotalCount { get; set; }
        public List<Tuple<string, int>> Components{ get; set; }

    }
}
