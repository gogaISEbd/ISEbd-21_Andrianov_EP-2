using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.ViewModels;
using System.Collections.Generic;

namespace CarRepairShopContracts.StoragesContracts
{
    public interface IMessageInfoStorage
    {
        List<MessageInfoViewModel> GetFullList();

        List<MessageInfoViewModel> GetFilteredList(MessageInfoBindingModel model);

        void Insert(MessageInfoBindingModel model);
    }
}
