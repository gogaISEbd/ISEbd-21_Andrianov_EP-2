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
                .Where(recRepairs => recRepairs.repairName.Contains(model.RepairName))
                .Select(CreateModel)
                .ToList();
        }

        public RepairViewModel GetElement(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            repair repair = source.repairs.FirstOrDefault(recRepairs => recRepairs.repairName == model.RepairName || recRepairs.Id == model.Id);
            return repair != null ? CreateModel(repair) : null;
        }

        public void Insert(RepairBindingModel model)
        {
            int maxId = source.repairs.Count > 0 ? source.repairs.Max(recRepair => recRepair.Id) : 0;
            var repair = new repair
            {
                Id = maxId + 1,
                repairComponents = new Dictionary<int, int>()
            };
            source.repairs.Add(CreateModel(model, repair));
        }

        public void Update(RepairBindingModel model)
        {
            repair repair = source.repairs.FirstOrDefault(recRepair => recRepair.Id == model.Id);
            if (repair == null)
            {
                throw new Exception("Изделие не найдена");
            }
            CreateModel(model, repair);
        }

        public void Delete(RepairBindingModel model)
        {
            repair repair = source.repairs.FirstOrDefault(recRepair => recRepair.Id == model.Id);
            if (repair != null)
            {
                source.repairs.Remove(repair);
            }
            else
            {
                throw new Exception("Пицца не найдена");
            }
        }

        private repair CreateModel(RepairBindingModel model, repair repair)
        {
            repair.repairName = model.RepairName;
            repair.Price = model.Price;

            foreach (var key in repair.repairComponents.Keys.ToList())
            {
                if (!model.RepairComponents.ContainsKey(key))
                {
                    repair.repairComponents.Remove(key);
                }
            }

            foreach (var component in model.RepairComponents)
            {
                if (repair.repairComponents.ContainsKey(component.Key))
                {
                    repair.repairComponents[component.Key] = model.RepairComponents[component.Key].Item2;
                }
                else
                {
                    repair.repairComponents.Add(component.Key, model.RepairComponents[component.Key].Item2);
                }
            }
            return repair;
        }

        private RepairViewModel CreateModel(repair repair)
        {
            return new RepairViewModel
            {
                Id = repair.Id,
                repairName = repair.repairName,
                Price = repair.Price,
                RepairComponents = repair.repairComponents
                .ToDictionary(repairComponent => repairComponent.Key, repairComponent =>
                (source.Components.FirstOrDefault(Component => Component.Id == repairComponent.Key)?.ComponentName, repairComponent.Value))
            };
        }

    }
}

