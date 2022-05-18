using System.ComponentModel;
using CarRepairShopContracts.Attributes;

namespace CarRepairShopContracts.ViewModels
{
    public class ImplementerViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }

        [Column(title: "Исполнитель", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("ФИО исполнителя")]
        public string ImplementerFIO { get; set; }

        [Column(title: "Время на заказ", width: 50)]
        [DisplayName("Время на заказ")]
        public int WorkingTime { get; set; }

        [Column(title: "Время на перерыв", width: 50)]
        [DisplayName("Время на перерыв")]
        public int PauseTime { get; set; }
    }
}
