﻿using Microsoft.AspNetCore.Mvc;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.BusinessLogicsContacts;
using CarRepairShopContracts.ViewModels;

namespace CarRepairShopRestApi.Controllers
{
    
    
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class ClientController : ControllerBase
        {
            private readonly IClientLogic _logic;

            public ClientController(IClientLogic logic)
            {
                _logic = logic;
            }

            [HttpGet]
            public ClientViewModel Login(string login, string password)
            {
                var list = _logic.Read(new ClientBindingModel { Email = login, Password = password });
                return (list != null && list.Count > 0) ? list[0] : null;
            }

            [HttpPost]
            public void Register(ClientBindingModel model) => _logic.CreateOrUpdate(model);

            [HttpPost]
            public void UpdateData(ClientBindingModel model) => _logic.CreateOrUpdate(model);
        }
}
