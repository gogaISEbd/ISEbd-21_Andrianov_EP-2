using System;
using System.Collections.Generic;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.ViewModels;

namespace CarRepairShopContracts.BusinessLogicsContacts
{
    public interface IImplementerLogic
    {
        List<ImplementerViewModel> Read(ImplementerBindingModel model);

        void CreateOrUpdate(ImplementerBindingModel model);

        void Delete(ImplementerBindingModel model);
    }
}
