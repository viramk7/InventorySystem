using InventorySystem.Common;
using InventorySystem.Entities;

namespace InventorySystem.Services.User
{
    public interface IUserService
    {
        ApiResponse<UserModel> GetUsers(int? userId);

        BaseApiResponse SaveUser(UserModel model);

        BaseApiResponse DeleteUser(UserModel model);
    }
}
