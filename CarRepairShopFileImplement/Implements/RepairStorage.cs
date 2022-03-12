using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using CarRepairShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CarRepairShopFileImplement.Implements
{
    public class RepairStorage : IRepairStorage
    {
        private readonly FileDataListSingleton source;
        public RepairStorage()
        {
            source = FileDataListSingleton.GetInstance();
        }
        public List<RepairViewModel> GetFullList()
        {
            return source.repairs
            .Select(CreateModel)
            .ToList();
        }
        public List<RepairViewModel> GetFilteredList(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            return source.repairs
            .Where(rec => rec.repairName.Contains(model.RepairName))
            .Select(CreateModel)
            .ToList();
        }
        public RepairViewModel GetElement(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var product = source.repairs
            .FirstOrDefault(rec => rec.repairName == model.RepairName || rec.Id
           == model.Id);
            return product != null ? CreateModel(product) : null;
        }
        public void Insert(RepairBindingModel model)
        {
            int maxId = source.repairs.Count > 0 ? source.Components.Max(rec => rec.Id)
   : 0;
            var element = new repair
            {
                Id = maxId + 1,
                repairComponents = new
           Dictionary<int, int>()
            };
            source.repairs.Add(CreateModel(model, element));
        }
        public void Update(RepairBindingModel model)
        {
            var element = source.repairs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
        }
        public void Delete(RepairBindingModel model)
        {
            repair element = source.repairs.FirstOrDefault(rec => rec.Id == model.Id);
            if (element != null)
            {
                source.repairs.Remove(element);
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }
        private static repair CreateModel(RepairBindingModel model, repair product)
        {
            product.repairName = model.RepairName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.repairComponents.Keys.ToList())
            {
                if (!model.RepairComponents.ContainsKey(key))
                {
                    product.repairComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.RepairComponents)
            {
                if (product.repairComponents.ContainsKey(component.Key))
                {
                    product.repairComponents[component.Key] =
                   model.RepairComponents[component.Key].Item2;
                }
                else
                {
                    product.repairComponents.Add(component.Key,
                   model.RepairComponents[component.Key].Item2);
                }
            }
            return product;
        }
        private RepairViewModel CreateModel(repair product) {
            return new RepairViewModel
            {
                Id = product.Id,
                repairName = product.repairName,
                Price = product.Price,
                RepairComponents = product.repairComponents
.ToDictionary(recPC => recPC.Key, recPC =>
(source.Components.FirstOrDefault(recC => recC.Id ==
recPC.Key)?.ComponentName, recPC.Value))
            };
        }

    }
}

