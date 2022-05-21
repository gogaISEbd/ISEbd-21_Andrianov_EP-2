﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShopFileImplement.Models;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;

namespace CarRepairShopFileImplement.Implements
{
    public class WareHouseStorage : IWareHouseStorage
    {
        private readonly FileDataListSingleton _source;

        public WareHouseStorage()
        {
            _source = FileDataListSingleton.GetInstance();
        }

        public List<WareHouseViewModel> GetFullList()
        {
            return _source.WareHouses
                .Select(CreateModel)
                .ToList();
        }

        public List<WareHouseViewModel> GetFilteredList(WareHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return _source.WareHouses
                .Where(rec => rec.WareHouseName.Contains(model.WareHouseName))
                .Select(CreateModel)
                .ToList();
        }

        public WareHouseViewModel GetElement(WareHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            WareHouse wareHouse = _source.WareHouses.FirstOrDefault(rec => rec.WareHouseName == model.WareHouseName || rec.Id == model.Id);
            return wareHouse != null ? CreateModel(wareHouse) : null;
        }

        public void Insert(WareHouseBindingModel model)
        {
            int maxId = _source.WareHouses.Count > 0 ? _source.WareHouses.Max(rec => rec.Id) : 0;
            var wareHouse = new WareHouse
            {
                Id = maxId + 1,
                WareHouseComponents = new Dictionary<int, int>()
            };

            _source.WareHouses.Add(CreateModel(model, wareHouse));
        }

        public void Update(WareHouseBindingModel model)
        {
            WareHouse wareHouse = _source.WareHouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (wareHouse == null)
            {
                throw new Exception("Склад не найден");
            }

            CreateModel(model, wareHouse);
        }

        public void Delete(WareHouseBindingModel model)
        {
            WareHouse wareHouse = _source.WareHouses.FirstOrDefault(rec => rec.Id == model.Id);
            if (wareHouse != null)
            {
                _source.WareHouses.Remove(wareHouse);
            }
            else
            {
                throw new Exception("Склад не найден");
            }
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
                    wareHouse.WareHouseComponents[component.Key] = model.WareHouseComponents[component.Key].Item2;
                }
                else
                {
                    wareHouse.WareHouseComponents.Add(component.Key, model.WareHouseComponents[component.Key].Item2);
                }
            }
            return wareHouse;
        }

        private WareHouseViewModel CreateModel(WareHouse wareHouse)
        {

            var wareHouseComponents = new Dictionary<int, (string, int)>();
            foreach (var sc in wareHouse.WareHouseComponents)
            {
                string componentName = string.Empty;
                foreach (var component in _source.Components)
                {
                    if (sc.Key == component.Id)
                    {
                        componentName = component.ComponentName;
                        break;
                    }
                }
                wareHouseComponents.Add(sc.Key, (componentName, sc.Value));
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
            foreach (var repairCompanent in repairComponents)
            {
                int wareHouseComponentCount = _source.WareHouses
                    .Where(wareHouse => wareHouse.WareHouseComponents.ContainsKey(repairCompanent.Key))
                    .Sum(wareHouse => wareHouse.WareHouseComponents[repairCompanent.Key]);

                if (wareHouseComponentCount < (repairCompanent.Value.Item2 * repairCount))
                {
                    return false;
                }
            }

            foreach (var repairComponent in repairComponents)
            {
                int repairComponentCount = repairComponent.Value.Item2 * repairCount;

                var wareHousesWithRepairComponents = _source.WareHouses
                    .Where(wareHouse => wareHouse.WareHouseComponents.ContainsKey(repairComponent.Key));

                foreach (var wareHouse in wareHousesWithRepairComponents)
                {
                    if (wareHouse.WareHouseComponents[repairComponent.Key] <= repairComponentCount)
                    {
                        repairComponentCount -= wareHouse.WareHouseComponents[repairComponent.Key];
                        wareHouse.WareHouseComponents.Remove(repairComponent.Key);
                    }
                    else
                    {
                        wareHouse.WareHouseComponents[repairComponent.Key] -= repairComponentCount;
                        repairComponentCount = 0;
                    }

                    if (repairComponentCount == 0)
                    {
                        break;
                    }
                }
            }
            return true;
        }
    }
}
