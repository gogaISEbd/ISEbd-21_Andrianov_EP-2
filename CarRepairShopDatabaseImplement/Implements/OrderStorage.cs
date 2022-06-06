using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using CarRepairShopDatabaseImplement;
using CarRepairShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;


namespace CarRepairShopDatabaseImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new CarRepairDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Repair)
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        ProductId = rec.RepairId,
                        ProductName = rec.Repair.RepairName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                    })
                    .ToList();
            }
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarRepairDatabase())
            {
                return context.Orders
                    .Include(rec => rec.Repair)
                    .Where(rec => rec.RepairId == model.ProductId ||
                        (model.DateFrom.GetHashCode() != 0 && model.DateTo.GetHashCode() != 0 && rec.DateCreate >= model.DateFrom && rec.DateCreate <= model.DateTo))
                    .Select(rec => new OrderViewModel
                    {
                        Id = rec.Id,
                        ProductId = rec.RepairId,
                        ProductName = rec.Repair.RepairName,
                        Count = rec.Count,
                        Sum = rec.Sum,
                        Status = rec.Status,
                        DateCreate = rec.DateCreate,
                        DateImplement = rec.DateImplement,
                    })
                    .ToList();
            }
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarRepairDatabase())
            {
                Order order = context.Orders.Include(rec => rec.Repair).FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    ProductId = order.RepairId,
                    ProductName = order.Repair.RepairName,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement,
                } :
                null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                var order = new Order
                {
                    RepairId = model.ProductId,
                    Count = model.Count,
                    Sum = model.Sum,
                    Status = model.Status,
                    DateCreate = model.DateCreate,
                    DateImplement = model.DateImplement,
                };
                context.Orders.Add(order);
                context.SaveChanges();
                CreateModel(model, order);
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order == null)
                {
                    throw new Exception("Элемент не найден");
                }
                order.RepairId = model.ProductId;
                order.Count = model.Count;
                order.Sum = model.Sum;
                order.Status = model.Status;
                order.DateCreate = model.DateCreate;
                order.DateImplement = model.DateImplement;

                CreateModel(model, order);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                Order order = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
                if (order != null)
                {
                    context.Orders.Remove(order);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarRepairDatabase())
            {
                repair repair = context.Repair.FirstOrDefault(rec => rec.Id == model.ProductId);
                if (repair != null)
                {
                    if (repair.Order == null)
                    {
                        repair.Order = new List<Order>();
                    }

                    repair.Order.Add(order);
                    context.Repair.Update(repair);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Элемент не найден");
                }
            }
            return order;
        }
    }
}
