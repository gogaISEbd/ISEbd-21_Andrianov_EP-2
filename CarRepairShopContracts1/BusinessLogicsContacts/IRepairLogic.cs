using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.ViewModels;
using System.Collections.Generic;


namespace CarRepairShopContracts.BusinessLogicsContacts
{
    public interface IRepairLogic
    {
        List<RepairViewModel> Read(RepairBindingModel model);
        void CreateOrUpdate(RepairBindingModel model);
        void Delete(RepairBindingModel model);

    }
}
