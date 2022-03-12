using System;
using System.Collections.Generic;
using System.Text;

namespace CarRepairShopListImplement.Models
{
    public class repair
    {
        public int Id { get; set; }
        public string ProductName { get; set; }
        public decimal Price { get; set; }
        public Dictionary<int, int> ProductComponents { get; set; }
    }
}
