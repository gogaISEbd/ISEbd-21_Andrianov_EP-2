using System;
using System.Collections.Generic;
using System.Linq;
using CarRepairShopBusinessLogic.OfficePackage;
using CarRepairShopBusinessLogic.OfficePackage.HelperModels;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.BusinessLogicsContacts;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;


namespace CarRepairShopBusinessLogic.BusinessLogics
{
    public class ReportLogic : IReportLogic
    {
        private readonly IRepairStorage _repairStorage;

        private readonly IOrderStorage _orderStorage;

        private readonly IWareHouseStorage _wareHouseStorage;

        private readonly AbstractSaveToExcel _saveToExcel;

        private readonly AbstractSaveToWord _saveToWord;

        private readonly AbstractSaveToPdf _saveToPdf;

        public ReportLogic(IRepairStorage repairStorage, IOrderStorage orderStorage, IWareHouseStorage wareHouseStorage,
            AbstractSaveToExcel saveToExcel, AbstractSaveToWord saveToWord, AbstractSaveToPdf saveToPdf)
        {
            _repairStorage = repairStorage;
            _orderStorage = orderStorage;
            _wareHouseStorage = wareHouseStorage;
            _saveToExcel = saveToExcel;
            _saveToWord = saveToWord;
            _saveToPdf = saveToPdf;
        }

        public List<ReportRepairComponentViewModel> GetRepairComponent()
        {
            var repairs = _repairStorage.GetFullList();
            var list = new List<ReportRepairComponentViewModel>();
            foreach (var repair in repairs)
            {
                var record = new ReportRepairComponentViewModel
                {
                    RepairName = repair.repairName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in repair.RepairComponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public List<ReportOrdersViewModel> GetOrders(ReportBindingModel model)
        {
            return _orderStorage.GetFilteredList(new OrderBindingModel
            {
                DateFrom = model.DateFrom,
                DateTo = model.DateTo
            })
            .Select(x => new ReportOrdersViewModel
            {
                DateCreate = x.DateCreate,
                RepairName = x.ProductName,
                Count = x.Count,
                Sum = x.Sum,
                Status = x.Status
            })
           .ToList();
        }

        public List<ReportOrdersByDateViewModel> GetOrdersByDate()
        {
            return _orderStorage.GetFullList()
                .GroupBy(order => order.DateCreate.ToShortDateString())
                .Select(rec => new ReportOrdersByDateViewModel
                {
                    Date = Convert.ToDateTime(rec.Key),
                    Count = rec.Count(),
                    Sum = rec.Sum(order => order.Sum)
                })
                .ToList();
        }

        public List<ReportWareHouseComponentViewModel> GetWareHouseComponent()
        {
            var wareHouses = _wareHouseStorage.GetFullList();
            var list = new List<ReportWareHouseComponentViewModel>();
            foreach (var wareHouse in wareHouses)
            {
                var record = new ReportWareHouseComponentViewModel
                {
                    WareHouseName = wareHouse.WareHouseName,
                    Components = new List<Tuple<string, int>>(),
                    TotalCount = 0
                };
                foreach (var component in wareHouse.WareHousecomponents)
                {
                    record.Components.Add(new Tuple<string, int>(component.Value.Item1, component.Value.Item2));
                    record.TotalCount += component.Value.Item2;
                }
                list.Add(record);
            }
            return list;
        }

        public void SaveRepairToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateDoc(new WordInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                Repairs = _repairStorage.GetFullList()
            });
        }

        public void SaveWareHousesToWordFile(ReportBindingModel model)
        {
            _saveToWord.CreateWareHousesDoc(new WordInfoWareHouses
            {
                FileName = model.FileName,
                Title = "Список складов",
                WareHouses = _wareHouseStorage.GetFullList()
            });
        }

        public void SaveRepairComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReport(new ExcelInfo
            {
                FileName = model.FileName,
                Title = "Список изделий",
                RepairComponents = GetRepairComponent()
            });
        }

        public void SaveWareHouseComponentToExcelFile(ReportBindingModel model)
        {
            _saveToExcel.CreateReportWareHouses(new ExcelInfoWareHouses
            {
                FileName = model.FileName,
                Title = "Список складов",
                WareHouseComponents = GetWareHouseComponent()
            });
        }

        public void SaveOrdersToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDoc(new PdfInfo
            {
                FileName = model.FileName,
                Title = "Список заказов",
                DateFrom = model.DateFrom.Value,
                DateTo = model.DateTo.Value,
                Orders = GetOrders(model)
            });
        }

        public void SaveOrdersByDateToPdfFile(ReportBindingModel model)
        {
            _saveToPdf.CreateDocOrderReportByDate(new PdfInfoOrderReportByDate
            {
                FileName = model.FileName,
                Title = "Список заказов за весь период",
                Orders = GetOrdersByDate()
            });
        }
    }
}
