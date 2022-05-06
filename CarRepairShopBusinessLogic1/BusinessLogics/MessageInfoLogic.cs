using System;
using System.Collections.Generic;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.BusinessLogicsContacts;
using CarRepairShopContracts.StoragesContracts;
using CarRepairShopContracts.ViewModels;

namespace CarRepairShopBusinessLogic.BusinessLogics
{
    public class MessageInfoLogic : IMessageInfoLogic
    {
        private readonly IMessageInfoStorage _messageInfoStorage;

        private readonly IClientStorage _clientStorage;

        public MessageInfoLogic(IMessageInfoStorage messageInfoStorage, IClientStorage clientStorage)
        {
            _messageInfoStorage = messageInfoStorage;
            _clientStorage = clientStorage;
        }

        public List<MessageInfoViewModel> Read(MessageInfoBindingModel model)
        {
            if (model == null)
            {
                return _messageInfoStorage.GetFullList();
            }
            return _messageInfoStorage.GetFilteredList(model);
        }

        public void CreateOrUpdate(MessageInfoBindingModel model)
        {
            var client = _clientStorage.GetElement(new ClientBindingModel { Email = model.FromMailAddress });
            model.ClientId = client?.Id;
            _messageInfoStorage.Insert(model);
        }
    }
}
