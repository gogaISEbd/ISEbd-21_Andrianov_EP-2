using CarRepairShopFileImplement.Models;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CarRepairShopFileImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        private readonly FileDataListSingleton _source;

        public ImplementerStorage()
        {
            _source = FileDataListSingleton.GetInstance();
        }

        public List<ImplementerViewModel> GetFullList()
        {
            return _source.Implementers
                .Select(CreateModel)
                .ToList();
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            return _source.Implementers
                .Where(rec => rec.ImplementerFIO.Equals(model.ImplementerFIO))
                .Select(CreateModel)
                .ToList();
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }

            Implementer implementer = _source.Implementers.FirstOrDefault(rec => rec.ImplementerFIO.Equals(model.ImplementerFIO) || rec.Id.Equals(model.Id));
            return implementer != null ? CreateModel(implementer) : null;
        }

        public void Insert(ImplementerBindingModel model)
        {
            int maxId = _source.Implementers.Count > 0 ? _source.Implementers.Max(rec => rec.Id) : 0;
            var implementer = new Implementer { Id = maxId + 1 };
            _source.Implementers.Add(CreateModel(model, implementer));
        }

        public void Update(ImplementerBindingModel model)
        {
            Implementer implementer = _source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (implementer == null)
            {
                throw new Exception("Исполнитель не найден");
            }
            CreateModel(model, implementer);
        }

        public void Delete(ImplementerBindingModel model)
        {
            Implementer implementer = _source.Implementers.FirstOrDefault(rec => rec.Id == model.Id);
            if (implementer != null)
            {
                _source.Implementers.Remove(implementer);
            }
            else
            {
                throw new Exception("Исполнитель не найден");
            }
        }

        private Implementer CreateModel(ImplementerBindingModel model, Implementer implementer)
        {
            implementer.ImplementerFIO = model.ImplementerFIO;
            implementer.WorkingTime = model.WorkingTime;
            implementer.PauseTime = model.PauseTime;
            return implementer;
        }

        private ImplementerViewModel CreateModel(Implementer implementer)
        {
            return new ImplementerViewModel
            {
                Id = implementer.Id,
                ImplementerFIO = implementer.ImplementerFIO,
                WorkingTime = implementer.WorkingTime,
                PauseTime = implementer.PauseTime
            };
        }
    }
}
