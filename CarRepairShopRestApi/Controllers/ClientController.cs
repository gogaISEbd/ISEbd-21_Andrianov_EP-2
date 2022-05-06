using Microsoft.AspNetCore.Mvc;
using CarRepairShopContracts.BindingModels;
using CarRepairShopContracts.BusinessLogicsContacts;
using CarRepairShopContracts.ViewModels;
using System.Collections.Generic;

namespace CarRepairShopRestApi.Controllers
{
    
    
        [Route("api/[controller]/[action]")]
        [ApiController]
        public class ClientController : ControllerBase
        {
            private readonly IClientLogic _logic;
        private readonly IMessageInfoLogic _messageLogic;

        public ClientController(IClientLogic logic, IMessageInfoLogic messageLogic)
            {
                _logic = logic;
            _messageLogic = messageLogic;
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

        [HttpGet]
        public List<MessageInfoViewModel> GetMessages(int clientId) => _messageLogic.Read(new MessageInfoBindingModel { ClientId = clientId });
    }
}
