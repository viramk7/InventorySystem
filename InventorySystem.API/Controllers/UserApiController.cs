using InventorySystem.Common;
using InventorySystem.Entities;
using InventorySystem.Services.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace InventorySystem.API.Controllers
{
    [RoutePrefix("api")]
    public class UserApiController : ApiController
    {
        #region Initializations

        private readonly IUserService _service;

        public UserApiController()
        {
            _service = EngineContext.Resolve<IUserService>();
        }

        #endregion

        #region Methods

        [HttpGet]
        [Route("GetUsers")]
        public ApiResponse<UserModel> GetUsers(int? userId = null)
        {
            return _service.GetUsers(userId);
        }

        [HttpPost]
        [Route("SaveUser")]
        public BaseApiResponse SaveUser(UserModel model)
        {
            return _service.SaveUser(model);
        }

        [HttpPost]
        [Route("DeleteUser")]
        public BaseApiResponse DeleteUser(UserModel model)
        {
            return _service.DeleteUser(model);
        }

        #endregion
    }
}
