using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarRepairShopFileImplement.Models
{
    public class repair
    {
        public int Id { get; set; }
        public string repairName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> repairComponents { get; set; }
    }
}
