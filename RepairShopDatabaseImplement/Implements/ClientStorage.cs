﻿using Microsoft.EntityFrameworkCore;
using CarRepairShopDatabaseImplement.Models;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRepairShopDatabaseImplement.Implements
{
    public class ClientStorage : IClientStorage
    {
        public List<ClientViewModel> GetFullList()
        {
            using (var context = new CarRepairDatabase())
            {
                return context.Clients
                    .Select(rec => new ClientViewModel
                    {
                        Id = rec.Id,
                        ClientFIO = rec.ClientFIO,
                        Email = rec.Email,
                        Password = rec.Password
                    })
                .ToList();
            }
        }

        public List<ClientViewModel> GetFilteredList(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarRepairDatabase())
            {
                return context.Clients
                    .Include(x => x.Orders)
                    .Where(rec => rec.Email == model.Email && rec.Password == model.Password)
                    .Select(rec => new ClientViewModel
                    {
                        Id = rec.Id,
                        ClientFIO = rec.ClientFIO,
                        Email = rec.Email,
                        Password = rec.Password
                    })
                .ToList();
            }
        }

        public ClientViewModel GetElement(ClientBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            using (var context = new CarRepairDatabase())
            {
                Client client = context.Clients
                    .Include(x => x.Orders)
                    .FirstOrDefault(rec => rec.Email == model.Email || rec.Id == model.Id);
                return client != null ?
                new ClientViewModel
                {
                    Id = client.Id,
                    ClientFIO = client.ClientFIO,
                    Email = client.Email,
                    Password = client.Password
                } :
                null;
            }
        }

        public void Insert(ClientBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                context.Clients.Add(CreateModel(model, new Client()));
                context.SaveChanges();
            }
        }

        public void Update(ClientBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element == null)
                {
                    throw new Exception("Клиент не найден");
                }

                CreateModel(model, element);
                context.SaveChanges();
            }
        }

        public void Delete(ClientBindingModel model)
        {
            using (var context = new CarRepairDatabase())
            {
                Client element = context.Clients.FirstOrDefault(rec => rec.Id == model.Id);
                if (element != null)
                {
                    context.Clients.Remove(element);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("Клиент не найден");
                }
            }
        }

        private Client CreateModel(ClientBindingModel model, Client client)
        {
            client.ClientFIO = model.ClientFIO;
            client.Email = model.Email;
            client.Password = model.Password;
            return client;
        }
    }
}
