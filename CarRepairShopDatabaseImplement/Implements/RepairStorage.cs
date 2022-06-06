using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using CarRepairShopDatabaseImplement.Models;
using Microsoft.EntityFrameworkCore;
using CarRepairShopDatabaseImplement;
using System;
using System.Collections.Generic;
using System.Linq;



namespace CarRepairShopDatabaseImplement.Implements
{
    public class RepairStorage : IRepairStorage
    {
        public List<RepairViewModel> GetFullList()
        {
            using (var context = new CarRepairDatabase())
            {
                return context.Repair
                    .Include(rec => rec.RepairComponent)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public List<RepairViewModel> GetFilteredList(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarRepairDatabase())
            {
                return context.Repair
                    .Include(rec => rec.RepairComponent)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.RepairName.Contains(model.RepairName))
                    .ToList()
                    .Select(CreateModel)
                    .ToList();
            }
        }

        public RepairViewModel GetElement(RepairBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarRepairDatabase())
            {
                repair repair = context.Repair
                    .Include(rec => rec.RepairComponent)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.RepairName == model.RepairName || rec.Id == model.Id);

                return repair != null ? CreateModel(repair) : null;
            }
        }

        public void Insert(RepairBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var repair = new repair
                        {
                            RepairName = model.RepairName,
                            Price = model.Price
                        };
                        context.Repair.Add(repair);
                        context.SaveChanges();

                        CreateModel(model, repair, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Update(RepairBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        repair repair = context.Repair.FirstOrDefault(rec => rec.Id == model.Id);
                        if (repair == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        repair.RepairName = model.RepairName;
                        repair.Price = model.Price;

                        CreateModel(model, repair, context);
                        context.SaveChanges();
                        transaction.Commit();
                    }
                    catch
                    {
                        transaction.Rollback();
                        throw;
                    }
                }
            }
        }

        public void Delete(RepairBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                repair repair = context.Repair.FirstOrDefault(rec => rec.Id == model.Id);
                if (repair != null)
                {
                    context.Repair.Remove(repair);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private static repair CreateModel(RepairBindingModel model, repair repair, CarRepairDatabase context)
        {
            if (model.Id.HasValue)
            {
                var repairComponents = context.RepairComponent.Where(rec => rec.RepairId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.RepairComponent.RemoveRange(repairComponents.Where(rec => !model.RepairComponents.ContainsKey(rec.RepairId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateIngredient in repairComponents)
                {
                    updateIngredient.Count = model.RepairComponents[updateIngredient.ComponentId].Item2;
                    model.RepairComponents.Remove(updateIngredient.ComponentId);
                }
                context.SaveChanges();
            }

            foreach (var pc in model.RepairComponents)
            {
                context.RepairComponent.Add(new RepairComponent
                {
                    RepairId = repair.Id,
                    ComponentId = pc.Key,
                    Count = pc.Value.Item2
                });

                context.SaveChanges();
            }

            return repair;
        }

        private static RepairViewModel CreateModel(repair repair)
        {
            return new RepairViewModel
            {
                Id = repair.Id,
                repairName = repair.RepairName,
                Price = repair.Price,
                RepairComponents = repair.RepairComponent
                .ToDictionary(recPC => recPC.ComponentId, recPC => (recPC.Component?.ComponentName, recPC.Count))
            };
        }
    }
}