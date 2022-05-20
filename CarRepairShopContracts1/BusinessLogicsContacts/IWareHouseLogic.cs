using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.ViewModels;


namespace CarRepairShopContracts.BusinessLogicsContacts
{
    public interface IWareHouseLogic
    {
        List<WareHouseViewModel> Read(WareHouseBindingModel model);

        void CreateOrUpdate(WareHouseBindingModel model);

        void Delete(WareHouseBindingModel model);

        void ReplenishByComponent(WareHouseReplenishmentBindingModel model);
    }
}
