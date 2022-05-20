using System;
using System.Collections.Generic;
using System.Text;
using CarRepairShopContracts.Attributes;
using CarRepairShopContracts.Enums;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace CarRepairShopContracts.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [Column(title: "Клиент", width: 150)]
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        [Column(title: "Изделие", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("Изделие")]
        [DataMember]
        public string ProductName { get; set; }
        [DataMember]
        public int? ImplementerId { get; set; }
        [Column(title: "Исполнитель", width: 150)]
        [DataMember]
        [DisplayName("Исполнитель")]
        public string ImplementerFIO { get; set; }
        [Column(title: "Количество", width: 100)]
        [DisplayName("Количество")]
        [DataMember]
        public int Count { get; set; }
        [Column(title: "Сумма", width: 50)]
        [DisplayName("Сумма")]
        [DataMember]
        public decimal Sum { get; set; }
        [Column(title: "Статус", width: 100)]
        [DisplayName("Статус")]
        [DataMember]
        public string Status { get; set; }
        [Column(title: "Дата создания", width: 100)]
        [DisplayName("Дата создания")]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [Column(title: "Дата выполнения", width: 100)]
        [DisplayName("Дата выполнения")]
        [DataMember]
        public DateTime? DateImplement { get; set; }
    }
}
