﻿using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using CarRepairShopDatabaseImplement;
using CarRepairShopDatabaseImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;


namespace CarRepairShopDatabaseImplement.Implements
{
   public class OrderStorage : IOrderStorage
    {
        public List<OrderViewModel> GetFullList()
        {
            using (var context = new CarRepairDatabase())
            {
                return context.Orders.Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ProductName = context.Repair.FirstOrDefault(r => r.Id == rec.RepairId).RepairName,
                    ProductId = rec.RepairId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
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
                .Where(rec => rec.Id.Equals(model.Id))
                .Select(rec => new OrderViewModel
                {
                    Id = rec.Id,
                    ProductName = context.Repair.FirstOrDefault(r => r.Id == rec.RepairId).RepairName,
                    ProductId = rec.RepairId,
                    Count = rec.Count,
                    Sum = rec.Sum,
                    Status = rec.Status,
                    DateCreate = rec.DateCreate,
                    DateImplement = rec.DateImplement
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
                var order = context.Orders
                .FirstOrDefault(rec => rec.Id == model.Id);
                return order != null ?
                new OrderViewModel
                {
                    Id = order.Id,
                    ProductName = context.Repair.FirstOrDefault(r => r.Id == order.RepairId).RepairName,
                    ProductId = order.RepairId,
                    Count = order.Count,
                    Sum = order.Sum,
                    Status = order.Status,
                    DateCreate = order.DateCreate,
                    DateImplement = order.DateImplement
                } :
                null;
            }
        }

        public void Insert(OrderBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                context.Orders.Add(CreateModel(model, new Order()));
                context.SaveChanges();
            }
        }

        public void Update(OrderBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                var element = context.Orders.FirstOrDefault(rec => rec.Id ==
                model.Id);
                if (element == null)
                {
                    throw new Exception("Элемент не найден");
                }
                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(OrderBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                Order element = context.Orders.FirstOrDefault(rec => rec.Id ==
                model.Id);
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
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.RepairId = model.ProductId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }
    }
}
