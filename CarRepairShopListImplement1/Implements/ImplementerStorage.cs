using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShopListImplement.Models;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;

namespace CarRepairShopListImplement.Implements
{
    public class ImplementerStorage : IImplementerStorage
    {
        private readonly DataListSingleton _source;

        public ImplementerStorage()
        {
            _source = DataListSingleton.GetInstance();
        }

        public List<ImplementerViewModel> GetFullList()
        {
            List<ImplementerViewModel> result = new List<ImplementerViewModel>();
            foreach (var implementer in _source.Implementers)
            {
                result.Add(CreateModel(implementer));
            }
            return result;
        }

        public List<ImplementerViewModel> GetFilteredList(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            List<ImplementerViewModel> result = new List<ImplementerViewModel>();
            foreach (var implementer in _source.Implementers)
            {
                if (implementer.ImplementerFIO.Equals(model.ImplementerFIO))
                {
                    result.Add(CreateModel(implementer));
                }
            }
            return result;
        }

        public ImplementerViewModel GetElement(ImplementerBindingModel model)
        {
            if (model == null)
            {
                return null;
            }
            foreach (var implementer in _source.Implementers)
            {
                if (implementer.ImplementerFIO == model.ImplementerFIO || implementer.Id == model.Id)
                {
                    return CreateModel(implementer);
                }
            }
            return null;
        }

        public void Insert(ImplementerBindingModel model)
        {
            Implementer tmpImplementer = new Implementer { Id = 1 };
            foreach (var implementer in _source.Implementers)
            {
                if (implementer.Id >= tmpImplementer.Id)
                {
                    tmpImplementer.Id = implementer.Id + 1;
                }
            }
            _source.Implementers.Add(CreateModel(model, tmpImplementer));
        }

        public void Update(ImplementerBindingModel model)
        {
            Implementer tmpImplementer = null;
            foreach (var implementer in _source.Implementers)
            {
                if (implementer.Id == model.Id)
                {
                    tmpImplementer = implementer;
                }
            }
            if (tmpImplementer == null)
            {
                throw new Exception("Исполнитель не найден");
            }
            CreateModel(model, tmpImplementer);
        }

        public void Delete(ImplementerBindingModel model)
        {
            for (int i = 0; i < _source.Implementers.Count; ++i)
            {
                if (_source.Implementers[i].Id == model.Id.Value)
                {
                    _source.Implementers.RemoveAt(i);
                    return;
                }
            }
            throw new Exception("Исполнитель не найден");
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
