using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace CarRepairShopContracts.BindingModels
{
    [DataContract]
    public class CreateOrderBindingModel
    {

        [DataMember]
        public int ClientId { get; set; }

        [DataMember]
        public int ProductId { get; set; }

        [DataMember]
        public int Count { get; set; }

        [DataMember]
        public decimal Sum { get; set; }
    } 
}
