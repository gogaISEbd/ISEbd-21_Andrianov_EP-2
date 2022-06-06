using System.ComponentModel.DataAnnotations;

namespace CarRepairShopDatabaseImplement.Models
{
    public class WareHouseComponents
    {
        public int Id { get; set; }

        public int WareHouseId { get; set; }

        public int ComponentId { get; set; }

        [Required]
        public int Count { get; set; }

        public virtual Component Component { get; set; }

        public virtual WareHouse WareHouse { get; set; }
    }
}
