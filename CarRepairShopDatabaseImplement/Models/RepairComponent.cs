using System.ComponentModel.DataAnnotations;

namespace CarRepairShopDatabaseImplement.Models
{
    public class RepairComponent
    {
        public int Id { get; set; }
        public int RepairId { get; set; }
        public int ComponentId { get; set; }
        [Required]
        public int Count { get; set; }
        public virtual Component Component { get; set; }
        public virtual repair Repair { get; set; }
    }
}
