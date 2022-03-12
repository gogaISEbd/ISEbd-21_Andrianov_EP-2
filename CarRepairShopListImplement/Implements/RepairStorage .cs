using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using CarRepairShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CarRepairShopListImplement.Implements
{
    public class RepairStorage : IRepairStorage
    {
        private readonly DataListSingleton source;
        public RepairStorage()
        {
            source = DataListSingleton.GetInstance();
        }
        public List<RepairViewModel> GetFullList()
        {
            var result = new List<RepairViewModel>();
            foreach (var component in source.repair)
            {
                result.Add(CreateModel(component));
            }
            return result;
        }
        public List<RepairViewModel> GetFilteredList(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            var result = new List<RepairViewModel>();
            foreach (var product in source.repair)
            {
                if (product.ProductName.Contains(model.RepairName))
                {
                    result.Add(CreateModel(product));
                }
            }
            return result;
        }
        public RepairViewModel GetElement(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var product in source.repair)
            {
                if (product.Id == model.Id || product.ProductName ==
                model.RepairName)
                {
                    return CreateModel(product);
                }
            }
            return null;
        }
        public void Insert(RepairBindingModel model)
        {
            var tempProduct = new repair
            {
                Id = 1,
                ProductComponents = new
            Dictionary<int, int>()
            };
            foreach (var product in source.repair)
            {
                if (product.Id >= tempProduct.Id)
                {
                    tempProduct.Id = product.Id + 1;
                }
            }
            source.repair.Add(CreateModel(model, tempProduct));
        }
        public void Update(RepairBindingModel model)
        {
            repair tempProduct = null;
            foreach (var product in source.repair)
            {
                if (product.Id == model.Id)
                {
                    tempProduct = product;
                }
            }
            if (tempProduct == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempProduct);
        }
        public void Delete(RepairBindingModel model)
        {
            for (int i = 0; i < source.repair.Count; ++i)
            {
                if (source.repair[i].Id == model.Id)
                {
                    source.repair.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }
        private static repair CreateModel(RepairBindingModel model, repair
        product)
        {
            product.ProductName = model.RepairName;
            product.Price = model.Price;
            // удаляем убранные
            foreach (var key in product.ProductComponents.Keys.ToList())
            {
                if (!model.RepairComponents.ContainsKey(key))
                {
                    product.ProductComponents.Remove(key);
                }
            }
            // обновляем существуюущие и добавляем новые
            foreach (var component in model.RepairComponents)
            {
                if (product.ProductComponents.ContainsKey(component.Key))
                {
                    product.ProductComponents[component.Key] =
                    model.RepairComponents[component.Key].Item2;
                }
                else
                {
                    product.ProductComponents.Add(component.Key,
                    model.RepairComponents[component.Key].Item2);
                }
            }
            return product;
        }
        private RepairViewModel CreateModel(repair product)
        {
            // требуется дополнительно получить список компонентов для изделия с
            //названиями и их количество
        var productComponents = new Dictionary<int, (string, int)>();
            foreach (var pc in product.ProductComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (pc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                productComponents.Add(pc.Key, (componentName, pc.Value));
            }
            return new RepairViewModel
            {
                Id = product.Id,
                repairName = product.ProductName,
                Price = product.Price,
                RepairComponents = productComponents
            };
        }

    }
}
