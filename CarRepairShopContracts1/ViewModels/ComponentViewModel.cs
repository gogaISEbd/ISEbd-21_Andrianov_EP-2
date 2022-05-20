using System;
using System.Collections.Generic;
using System.Text;
using System.ComponentModel;
using CarRepairShopContracts.Attributes;


namespace CarRepairShopContracts.ViewModels
{
   public class ComponentViewModel
    {
        [Column(title: "Номер", width: 100)]
        public int Id { get; set; }
        [Column(title: "Компоненты", gridViewAutoSize: GridViewAutoSize.Fill)]
        [DisplayName("Название компонента")]
        public string ComponentName { get; set; }
    }
}
