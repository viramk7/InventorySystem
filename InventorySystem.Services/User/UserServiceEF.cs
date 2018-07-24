using InventorySystem.Data.Database;
using InventorySystem.Data.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using InventorySystem.Common;
using InventorySystem.Entities;

namespace InventorySystem.Services.User
{
    public class UserServiceEF : IUserService
    {
        #region Initilization

        private readonly log4net.ILog _logger;
        private readonly IRepository<UserMaster> _repository;

        public UserServiceEF(IRepository<UserMaster> repository)
        {
            _repository = repository;
            _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        #endregion

        #region Methods

        public ApiResponse<UserModel> GetUsers(int? userId)
        {
            var response = new ApiResponse<UserModel>();

            try
            {
                var result = _repository.Table.Where(w => w.UserId == userId || userId == null).ToList();

                //TODO : Implement automapper here
                var listUserModel = new List<UserModel>();
                foreach (var item in result)
                {
                    listUserModel.Add(new UserModel
                    {
                        UserId = item.UserId,
                        UserName = item.UserName,
                        FirstName = item.FirstName,
                        LastName = item.LastName,
                        Email = item.Email,
                        Contact = item.Contact
                    });
                }

                response.Data = listUserModel;
                response.Success = true;
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse SaveUser(UserModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                var userMaster = new UserMaster
                {
                    UserId = model.UserId,
                    UserName = model.UserName,
                    FirstName = model.FirstName,
                    LastName = model.LastName,
                    Email = model.Email,
                    Contact = model.Contact,
                    CreatedBy = 1, // This will be logged in user id 
                    CreatedDate = DateTime.Now
                };

                if (model.UserId > 0)
                    _repository.Update(userMaster);
                else
                    _repository.Insert(userMaster);

                _repository.SaveChanges();

                response.Success = true;
                response.Message.Add(Resources.Resources.SaveSuccess); 
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }

        public BaseApiResponse DeleteUser(UserModel model)
        {
            var response = new BaseApiResponse();

            try
            {
                var userMaster = _repository.GetById(model.UserId);
                _repository.Delete(userMaster);
                _repository.SaveChanges();

                response.Success = true;
                response.Message.Add(Resources.Resources.DeleteSuccess);
            }
            catch (Exception ex)
            {
                _logger.Error(ex);
                response.Message.Add(ex.Message);
            }

            return response;
        }
        
        #endregion
    }
}
