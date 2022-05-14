using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using CarRepairShopListImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRepairShopListImplement.Implements
{
    public class WareHouseStorage : IWareHouseStorage
    {
        private readonly DataListSingleton source;

        public WareHouseStorage()
        {
            source = DataListSingleton.GetInstance();
        }

        public List<WareHouseViewModel> GetFullList()
        {
            List<WareHouseViewModel> result = new List<WareHouseViewModel>();
            foreach (var wareHouse in source.Warehouses)
            {
                result.Add(CreateModel(wareHouse));
            }
            return result;
        }

        public List<WareHouseViewModel> GetFilteredList(WareHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<WareHouseViewModel> result = new List<WareHouseViewModel>();
            foreach (var wareHouse in source.Warehouses)
            {
                if (wareHouse.WareHouseName.Contains(model.WareHouseName))
                {
                    result.Add(CreateModel(wareHouse));
                }
            }
            return result;
        }

        public WareHouseViewModel GetElement(WareHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var wareHouse in source.Warehouses)
            {
                if (wareHouse.Id == model.Id || wareHouse.WareHouseName ==
                model.WareHouseName)
                {
                    return CreateModel(wareHouse);
                }
            }
            return null;
        }

        public void Insert(WareHouseBindingModel model)
        {
            var tempWareHouse = new WareHouse
            {
                Id = 1,
                WareHouseComponents = new Dictionary<int, int>(),
                DateCreate = model.DateCreate
            };
            foreach (var wareHouse in source.Warehouses)
            {
                if (wareHouse.Id >= tempWareHouse.Id)
                {
                    tempWareHouse.Id = wareHouse.Id + 1;
                }
            }
            source.Warehouses.Add(CreateModel(model, tempWareHouse));
        }

        public void Update(WareHouseBindingModel model)
        {
            WareHouse tempWareHouse = null;
            foreach (var wareHouse in source.Warehouses)
            {
                if (wareHouse.Id == model.Id)
                {
                    tempWareHouse = wareHouse;
                }
            }
            if (tempWareHouse == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, tempWareHouse);
        }

        public void Delete(WareHouseBindingModel model)
        {
            for (int i = 0; i < source.Warehouses.Count; ++i)
            {
                if (source.Warehouses[i].Id == model.Id)
                {
                    source.Warehouses.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Элемент не найден");
        }

        private WareHouse CreateModel(WareHouseBindingModel model, WareHouse wareHouse)
        {
            wareHouse.WareHouseName = model.WareHouseName;
            wareHouse.ResponsiblePersonFIO = model.ResponsiblePersonFIO;
            wareHouse.DateCreate = model.DateCreate;
            foreach (var key in wareHouse.WareHouseComponents.Keys.ToList())
            {
                if (!model.WareHouseComponents.ContainsKey(key))
                {
                    wareHouse.WareHouseComponents.Remove(key);
                }
            }
            foreach (var component in model.WareHouseComponents)
            {
                if (wareHouse.WareHouseComponents.ContainsKey(component.Key))
                {
                    wareHouse.WareHouseComponents[component.Key] =
                    model.WareHouseComponents[component.Key].Item2;
                }
                else
                {
                    wareHouse.WareHouseComponents.Add(component.Key,
                    model.WareHouseComponents[component.Key].Item2);
                }
            }
            return wareHouse;
        }

        private WareHouseViewModel CreateModel(WareHouse wareHouse)
        {
            var wareHouseComponents = new Dictionary<int, (string, int)>();

            foreach (var whi in wareHouse.WareHouseComponents)
            {
                string componentName = string.Empty;
                foreach (var component in source.Components)
                {
                    if (whi.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                wareHouseComponents.Add(whi.Key, (componentName, whi.Value));
            }
            return new WareHouseViewModel
            {
                Id = wareHouse.Id,
                WareHouseName = wareHouse.WareHouseName,
                ResponsiblePersonFIO = wareHouse.ResponsiblePersonFIO,
                DateCreate = wareHouse.DateCreate,
                WareHousecomponents = wareHouseComponents
            };
            
        }
        public bool WriteOffComponents(Dictionary<int, (string, int)> repairComponents, int repairCount)
        {
            throw new NotImplementedException();
        }
    }
}
