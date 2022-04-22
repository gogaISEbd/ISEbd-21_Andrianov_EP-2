using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using System.Runtime.Serialization;
namespace CarRepairShopContracts.ViewModels
{
    [DataContract]
    public class RepairViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DisplayName("Название изделия")]
        [DataMember]
        public string repairName { get; set; }
        [DisplayName("Цена")]
        [DataMember]
        public decimal Price { get; set; }
        [DataMember]
        public Dictionary<int, (string, int)> RepairComponents { get; set; }
    }
}
