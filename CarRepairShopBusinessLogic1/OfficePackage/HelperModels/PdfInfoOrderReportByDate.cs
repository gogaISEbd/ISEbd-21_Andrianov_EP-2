using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShopContracts.ViewModels;

namespace CarRepairShopBusinessLogic.OfficePackage.HelperModels
{
    public class PdfInfoOrderReportByDate
    {
        public string FileName { get; set; }

        public string Title { get; set; }

        public List<ReportOrdersByDateViewModel> Orders { get; set; }
    }
}
