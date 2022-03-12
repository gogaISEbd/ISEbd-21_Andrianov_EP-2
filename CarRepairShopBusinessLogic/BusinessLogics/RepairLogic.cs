﻿using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.BusinessLogicsContacts;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using System;
using System.Collections.Generic;

namespace CarRepairShopBusinessLogic.BusinessLogics
{
    public class RepairLogic: IRepairLogic
    {
        private readonly IRepairStorage _repairStorage;
        public RepairLogic(IRepairStorage componentStorage)
        {
            _repairStorage = componentStorage;
        }

        public List<RepairViewModel> Read(RepairBindingModel model)
        {
            if (model == null)
            {
                return _repairStorage.GetFullList();
            }
            if (model.Id.HasValue)
            {
                return new List<RepairViewModel> { _repairStorage.GetElement(model) };
            }
            return _repairStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(RepairBindingModel model)
        {
            var element = _repairStorage.GetElement(new RepairBindingModel
            {
                RepairName = model.RepairName
            });
            if (element != null && element.Id != model.Id)
            {
                throw new Exception("Уже есть компонент с таким названием");
            }
            if (model.Id.HasValue)
            {
                _repairStorage.Update(model);
            }
            else
            {
                _repairStorage.Insert(model);
            }
        }
        public void Delete(RepairBindingModel model)
        {
            var element = _repairStorage.GetElement(new RepairBindingModel
            {
                Id = model.Id
            });
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            _repairStorage.Delete(model);
        }

    }
}
