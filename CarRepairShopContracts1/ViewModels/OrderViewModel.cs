using System;
using System.Collections.Generic;
using System.Text;

using CarRepairShopContracts.Enums;
using System.ComponentModel;
using System.Runtime.Serialization;


namespace CarRepairShopContracts.ViewModels
{
    [DataContract]
    public class OrderViewModel
    {
        [DataMember]
        public int Id { get; set; }
        [DataMember]
        public int ClientId { get; set; }
        [DataMember]
        public int ProductId { get; set; }
        [DataMember]
        [DisplayName("Клиент")]
        public string ClientFIO { get; set; }
        [DisplayName("Изделие")]
        [DataMember]
        public string ProductName { get; set; }
        [DisplayName("Количество")]
        [DataMember]
        public int Count { get; set; }
        [DisplayName("Сумма")]
        [DataMember]
        public decimal Sum { get; set; }
        [DisplayName("Статус")]
        [DataMember]
        public string Status { get; set; }
        [DisplayName("Дата создания")]
        [DataMember]
        public DateTime DateCreate { get; set; }
        [DisplayName("Дата выполнения")]
        [DataMember]
        public DateTime? DateImplement { get; set; }
    }
}
