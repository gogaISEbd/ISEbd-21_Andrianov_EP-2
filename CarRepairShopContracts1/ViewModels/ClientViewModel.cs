using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Serialization;
using CarRepairShopContracts.Attributes;

namespace CarRepairShopContracts.ViewModels
{
    [DataContract]
    public class ClientViewModel
    {
        [Column(title: "Номер", width: 100)]
        [DataMember]
        public int Id { get; set; }

        [Column(title: "Клиент", width: 150)]
        [DataMember]
        [DisplayName("ФИО клиента")]
        public string ClientFIO { get; set; }

        [Column(title: "Логин", width: 100)]
        [DataMember]
        [DisplayName("Логин")]
        public string Email { get; set; }

        [Column(title: "Пароль", width: 100)]
        [DataMember]
        [DisplayName("Пароль")]
        public string Password { get; set; }
    }
}
