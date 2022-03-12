using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;

namespace CarRepairShopContracts.ViewModels
{
    public class RepairViewModel
    {
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        public string repairName { get; set; }
        [DisplayName("Цена")]
        public decimal Price { get; set; }
        public Dictionary<int, (string, int)> RepairComponents { get; set; }
    }
}
