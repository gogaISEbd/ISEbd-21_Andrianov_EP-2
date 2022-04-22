using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using CarRepairShopFileImplement.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRepairShopFileImplement.Implements
{
    public class OrderStorage : IOrderStorage
    {
        private readonly FileDataListSingleton _source;

        public OrderStorage()
        {
            _source = FileDataListSingleton.GetInstance();
        }

        public List<OrderViewModel> GetFullList()
        {
            return _source.Orders
                .Select(CreateModel)
                .ToList();
        }

        public List<OrderViewModel> GetFilteredList(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return _source.Orders
                .Where(rec => (!model.DateFrom.HasValue && !model.DateTo.HasValue && rec.DateCreate.Date == model.DateCreate.Date) ||
                (model.DateFrom.HasValue && model.DateTo.HasValue && rec.DateCreate.Date >= model.DateFrom.Value.Date && rec.DateCreate.Date <= model.DateTo.Value.Date) ||
                (model.ClientId.HasValue && rec.ClientId == model.ClientId))
                .Select(CreateModel)
                .ToList();
        }

        public OrderViewModel GetElement(OrderBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            Order order = _source.Orders.FirstOrDefault(recOder => recOder.Id == model.Id);
            return order != null ? CreateModel(order) : null;
        }

        public void Insert(OrderBindingModel model)
        {
            int maxId = _source.Orders.Count > 0 ? _source.Orders.Max(recOder => recOder.Id) : 0;
            var order = new Order { Id = maxId + 1 };
            _source.Orders.Add(CreateModel(model, order));
        }

        public void Update(OrderBindingModel model)
        {
            Order order = _source.Orders.FirstOrDefault(recOder => recOder.Id == model.Id);
            if (order == null)
            {
                throw new Exception("Заказ не найден");
            }
            CreateModel(model, order);
        }

        public void Delete(OrderBindingModel model)
        {
            Order order = _source.Orders.FirstOrDefault(recOrder => recOrder.Id == model.Id);
            if (order != null)
            {
                _source.Orders.Remove(order);
            }
            else
            {
                throw new Exception("Заказ не найден");
            }
        }

        private Order CreateModel(OrderBindingModel model, Order order)
        {
            order.ClientId = (int)model.ClientId;
            order.ProductId = model.ProductId;
            order.Count = model.Count;
            order.Sum = model.Sum;
            order.Status = model.Status;
            order.DateCreate = model.DateCreate;
            order.DateImplement = model.DateImplement;
            return order;
        }

        private OrderViewModel CreateModel(Order order)
        {
            return new OrderViewModel
            {
                Id = order.Id,
                ProductName = _source.repairs.FirstOrDefault(repair => repair.Id == order.ProductId)?.repairName,
                ProductId = order.ProductId,
                Count = order.Count,
                Sum = order.Sum,
                Status = Enum.GetName(order.Status),
                DateCreate = order.DateCreate,
                DateImplement = order.DateImplement,
                ClientId = order.ClientId,
                ClientFIO = _source.Clients.FirstOrDefault(rec => rec.Id == order.ClientId)?.ClientFIO,
            };
        }
    }
}
