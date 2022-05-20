using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
using CarRepairShopContracts.Attributes;
namespace CarRepairShopContracts.ViewModels
{
    [DataContract]
    public class RepairViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }
        [Column(title: "изделия", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("Название изделия")]
        [DataMember]
        public string repairName { get; set; }
        [Column(title: "Цена", width: 50)]
        [DisplayName("Цена")]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> RepairComponents { get; set; }
    }
}
