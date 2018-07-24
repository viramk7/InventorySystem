using InventorySystem.Common;
using InventorySystem.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace InventorySystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly log4net.ILog _logger;
        private readonly WebClientHelper _client;

        public HomeController()
        {
            _client = WebClientHelper.Instance;
            _logger = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        }

        public async Task<ActionResult> Index()
        {
            var model = new List<UserModel>();

            var uri = "GetUsers";
            var result = await _client.GetRequest(new ApiResponse<UserModel>(), uri);

            if (result.Success)
                model = result.Data.ToList();

            return View();
        }

        public async Task<ActionResult> AddNewUser()
        {
            var model = new UserModel
            {
                UserName = "Poojak",
                FirstName = "Pooja",
                LastName = "Keshwala",
                Email = "poojak16@gmail.com",
                Contact = "789456123",
                UserId = 0 // Add mode
            };

            var uri = "SaveUser";
            var result = await _client.PostRequest<BaseApiResponse, UserModel>(model, uri);

            if (result.Success)
            {
                // Handle success here
            }
            else
            {
                // Handle error here
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> EditUser()
        {
            var model = new UserModel
            {
                UserName = "abc",
                FirstName = "xyz",
                LastName = "pqr",
                Email = "abc@gmail.com",
                Contact = "1234567890",
                UserId = 3 // Edit mode
            };

            var uri = "SaveUser";
            var result = await _client.PostRequest<BaseApiResponse, UserModel>(model, uri);

            if (result.Success)
            {
                // Handle success here
            }
            else
            {
                // Handle error here
            }

            return RedirectToAction("Index");
        }

        public async Task<ActionResult> DeleteUser()
        {
            var model = new UserModel
            {
                UserId = 3 
            };

            var uri = "DeleteUser";
            var result = await _client.PostRequest<BaseApiResponse, UserModel>(model, uri);

            if (result.Success)
            {
                // Handle success here
            }
            else
            {
                // Handle error here
            }

            return RedirectToAction("Index");
        }

    }
}