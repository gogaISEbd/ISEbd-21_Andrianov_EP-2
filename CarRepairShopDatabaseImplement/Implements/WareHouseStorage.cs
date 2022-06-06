using Microsoft.EntityFrameworkCore;
using CarRepairShopDatabaseImplement.Models;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRepairShopDatabaseImplement.Implements
{
    public class WareHouseStorage : IWareHouseStorage
    {
        public List<WareHouseViewModel> GetFullList()
        {
            using (var context = new CarRepairDatabase())
            {
                return context.WareHouses
                    .Include(rec => rec.WareHouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .ToList()
                    .Select(rec => new WareHouseViewModel
                    {
                        Id = rec.Id,
                        WareHouseName = rec.WareHouseName,
                        ResponsiblePersonFIO = rec.ResponsiblePersonFIO,
                        DateCreate = rec.DateCreate,
                        WareHousecomponents = rec.WareHouseComponents
                    .ToDictionary(recSC => recSC.ComponentId, recSC => (recSC.Component?.ComponentName, recSC.Count))
                    })
                    .ToList();
            }
        }

        public List<WareHouseViewModel> GetFilteredList(WareHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarRepairDatabase())
            {
                return context.WareHouses
                    .Include(rec => rec.WareHouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .Where(rec => rec.WareHouseName.Contains(model.WareHouseName))
                    .ToList()
                    .Select(rec => new WareHouseViewModel
                    {
                        Id = rec.Id,
                        WareHouseName = rec.WareHouseName,
                        ResponsiblePersonFIO = rec.ResponsiblePersonFIO,
                        DateCreate = rec.DateCreate,
                        WareHousecomponents = rec.WareHouseComponents
                    .ToDictionary(recWHI => recWHI.ComponentId, recWHI => (recWHI.Component?.ComponentName, recWHI.Count))
                    })
                    .ToList();
            }
        }

        public WareHouseViewModel GetElement(WareHouseBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarRepairDatabase())
            {
                var wareHouse = context.WareHouses
                    .Include(rec => rec.WareHouseComponents)
                    .ThenInclude(rec => rec.Component)
                    .FirstOrDefault(rec => rec.WareHouseName == model.WareHouseName || rec.Id == model.Id);
                return wareHouse != null ?
                new WareHouseViewModel
                {
                    Id = wareHouse.Id,
                    WareHouseName = wareHouse.WareHouseName,
                    ResponsiblePersonFIO = wareHouse.ResponsiblePersonFIO,
                    DateCreate = wareHouse.DateCreate,
                    WareHousecomponents = wareHouse.WareHouseComponents
                    .ToDictionary(rec => rec.ComponentId, rec => (rec.Component?.ComponentName, rec.Count))
                } :
                null;
            }
        }

        public void Insert(WareHouseBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        var wareHouse = new WareHouse
                        {
                            WareHouseName = model.WareHouseName,
                            ResponsiblePersonFIO = model.ResponsiblePersonFIO,
                            DateCreate = model.DateCreate
                        };
                        context.WareHouses.Add(wareHouse);
                        context.SaveChanges();

                        CreateModel(model, wareHouse, context);
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

        public void Update(WareHouseBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                using (var transaction = context.Database.BeginTransaction())
                {
                    try
                    {
                        WareHouse wareHouse = context.WareHouses.FirstOrDefault(rec => rec.Id == model.Id);
                        if (wareHouse == null)
                        {
                            throw new Exception("Элемент не найден");
                        }
                        wareHouse.WareHouseName = model.WareHouseName;
                        wareHouse.ResponsiblePersonFIO = model.ResponsiblePersonFIO;

                        CreateModel(model, wareHouse, context);
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

        public void Delete(WareHouseBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                WareHouse wareHouse = context.WareHouses.FirstOrDefault(rec => rec.Id == model.Id);
                if (wareHouse != null)
                {
                    context.WareHouses.Remove(wareHouse);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private WareHouse CreateModel(WareHouseBindingModel model, WareHouse wareHouse, CarRepairDatabase context)
        {
            if (model.Id.HasValue)
            {
                var wareHouseComponents = context.WareHouseComponents.Where(rec => rec.WareHouseId == model.Id.Value).ToList();
                // удалили те, которых нет в модели
                context.WareHouseComponents.RemoveRange(wareHouseComponents.Where(rec => !model.WareHouseComponents.ContainsKey(rec.ComponentId)).ToList());
                context.SaveChanges();
                // обновили количество у существующих записей
                foreach (var updateComponent in wareHouseComponents)
                {
                    updateComponent.Count = model.WareHouseComponents[updateComponent.ComponentId].Item2;
                    model.WareHouseComponents.Remove(updateComponent.ComponentId);
                }
                context.SaveChanges();
            }
            // добавили новые
            foreach (var whi in model.WareHouseComponents)
            {
                context.WareHouseComponents.Add(new WareHouseComponents
                {
                    WareHouseId = wareHouse.Id,
                    ComponentId = whi.Key,
                    Count = whi.Value.Item2
                });
                try
                {
                    context.SaveChanges();
                }
                catch (DbUpdateException)
                {
                    throw new Exception("Возникла ошибка при сохранении");
                }
            }
            return wareHouse;
        }

        public bool WriteOffComponents(Dictionary<int, (string, int)> repairComponents, int repairCount)
        {
            using var context = new CarRepairDatabase();
            using var transaction = context.Database.BeginTransaction();
            try
            {
                foreach (var cond in repairComponents)
                {
                    int count = cond.Value.Item2 * repairCount;
                    var repaircom = context.RepairComponent.Where(rec => rec.ComponentId == cond.Key);

                    foreach (var comp in repaircom)
                    {
                        if (comp.Count <= count)
                        {
                            count -= comp.Count;
                            context.RepairComponent.Remove(comp);
                        }
                        else
                        {
                            comp.Count -= count;
                            count = 0;
                        }

                        if (count == 0)
                        {
                            break;
                        }
                    }
                    if (count != 0)
                    {
                        throw new Exception("Недостаточно компонентов");
                    }
                }

                context.SaveChanges();
                transaction.Commit();
                return true;
            }
            catch
            {
                transaction.Rollback();
                throw;
            }
        }
            }
        }
 
