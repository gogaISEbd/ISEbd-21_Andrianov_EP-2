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
            using var context = new CarRepairDatabase();

            return context.Orders.Include(rec => rec.Repair).Include(rec => rec.Client).Include(rec => rec.Implementer).Select(rec => new OrderViewModel
            {
                Id = rec.Id,
                ProductId = rec.RepairId,
                ClientId = rec.ClientId,
                ClientFIO = rec.Client.ClientFIO,
                ImplementerId = rec.ImplementerId,
                ImplementerFIO = rec.Implementer.ImplementerFIO,
                ProductName = rec.Repair.RepairName,
                Count = rec.Count,
                Sum = rec.Sum,
                Status = rec.Status.ToString(),
                DateCreate = rec.DateCreate,
                DateImplement = rec.DateImplement
            }).ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new CarRepairDatabase();

            return context.Orders.Include(rec => rec.Repair).Include(rec => rec.Client)
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
                    (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
                    (model.ClientId.HasValue && rec.ClientId == model.ClientId) ||
                    (model.SearchStatus.HasValue && model.SearchStatus.Value == rec.Status) ||
                    (model.ImplementerId.HasValue && rec.ImplementerId == model.ImplementerId && model.Status == rec.Status))
                    .Select(rec => new OrderViewModel
                    {
                    Id = rec.Id,
                    ProductId = rec.RepairId,
                    ClientId = rec.ClientId,
                    ClientFIO = rec.Client.ClientFIO,
                        ImplementerId = rec.ImplementerId,
                        ImplementerFIO = rec.Implementer.ImplementerFIO,
                        ProductName = rec.Repair.RepairName,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status.ToString(),
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
                }).ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using var context = new CarRepairDatabase();

            var order = context.Orders.Include(rec => rec.Repair).Include(rec => rec.Client).Include(rec => rec.Implementer).FirstOrDefault(rec => rec.Id == model.Id);

            return order != null ? CreateModel(order, context) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            using var context = new CarRepairDatabase();

            context.Orders.Add(CreateModel(model, new Order()));
            context.SaveChanges();
        }

        public void Update(OrderBindingModel model)
        {
            using var context = new CarRepairDatabase();
            var element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);
            if (element == null)
            {
                throw new Exception("Элемент не найден");
            }
            CreateModel(model, element);
            context.SaveChanges();
        }

        public void Delete(OrderBindingModel model)
        {
            using var context = new CarRepairDatabase();
            Order element = context.Orders.FirstOrDefault(rec => rec.Id == model.Id);

            if (element != null)
            {
                context.Orders.Remove(element);
                context.SaveChanges();
            }
            else
            {
                throw new Exception("Элемент не найден");
            }
        }

        private static Order CreateModel(OrderBindingModel model, Order order)
        {
            order.RepairId = model.ProductId;
            order.ClientId = model.ClientId.Value;
            order.ImplementerId = model.ImplementerId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private static OrderViewModel CreateModel(Order order, CarRepairDatabase context)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ProductId = order.RepairId,
                ClientId = order.ClientId,
                ClientFIO = order.Client.ClientFIO,
                ImplementerId = order.ImplementerId,
                ProductName = order.Repair.RepairName,
                Count = order.Count,
                Sum = order.Sum,
                Status = order.Status.ToString(),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement
            };
        }
    }
 }

