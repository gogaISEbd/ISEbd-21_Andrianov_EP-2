﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShopContracts.ViewModels;

namespace CarRepairShopBusinessLogic.OfficePackage.HelperModels
{
    public class ExcelInfoWareHouses
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportWareHouseComponentViewModel> WareHouseComponents { get; set; }
    }
}
