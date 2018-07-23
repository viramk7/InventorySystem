using System;
using InventorySystem.Common;
using InventorySystem.Entities;
using InventorySystem.Data.Repositories;
using InventorySystem.Data.Database;
using System.Data.SqlClient;
using System.Linq;
using System.Collections.Generic;

namespace InventorySystem.Services.User
{
    public class UserService : IUserService
    {
        #region Initilization

        private readonly IRepository<UserMaster> _repository;

        public UserService(IRepository<UserMaster> repository)
        {
            _repository = repository;
        }

        #endregion

        #region Methods 

        public ApiResponse<UserModel> GetUsers(int? userId)
        {
            var response = new ApiResponse<UserModel>();

            try
            {
                object[] paramList =
                {
                    new SqlParameter("UserId",(object)userId ?? DBNull.Value)
                };

                var result = _repository.ExecuteSql<UserModel>("USP_UserMaster_GetUsers", paramList).ToList();

                response.Data = result;
                response.Success = true;
            }
            catch (Exception ex)
            {
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveUser(UserModel model)
        {
            throw new NotImplementedException();
        }

        public BaseApiResponse DeleteUser(UserModel model)
        {
            throw new NotImplementedException();
        }

        #endregion
        
    }
}
