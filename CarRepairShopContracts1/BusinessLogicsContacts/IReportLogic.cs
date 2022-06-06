using System;
using System.Collections.Generic;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.ViewModels;

namespace CarRepairShopContracts.BusinessLogicsContacts
{
    public interface IReportLogic
    {
        List<ReportRepairComponentViewModel> GetRepairComponent();

        List<ReportOrdersViewModel> GetOrders(ReportBindingModel model);

        List<ReportOrdersByDateViewModel> GetOrdersByDate();

        List<ReportWareHouseComponentViewModel> GetWareHouseComponent();

        void SaveWareHouseComponentToExcelFile(ReportBindingModel model);

        void SaveRepairToWordFile(ReportBindingModel model);

        void SaveRepairComponentToExcelFile(ReportBindingModel model);

        void SaveOrdersToPdfFile(ReportBindingModel model);

        void SaveOrdersByDateToPdfFile(ReportBindingModel model);

        void SaveWareHousesToWordFile(ReportBindingModel model);
    }
}
