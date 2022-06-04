using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace CarRepairShopDatabaseImplement.Models
{
    public class repair
    {
        public int Id { get; set; }

        [ForeignKey("RepairId")]
        public virtual List<RepairComponent> RepairComponent { get; set; }

        [ForeignKey("RepairId")]
        public virtual List<Order> Order { get; set; }

        [Required]
        public string RepairName { get; set; }

        [Required]
        public decimal Price { get; set; }
    }
}
