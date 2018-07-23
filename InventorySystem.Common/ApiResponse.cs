using System.Collections.Generic;

namespace InventorySystem.Common
{
    public class ApiResponse<T> : BaseApiResponse
    {
        public virtual IList<T> Data { get; set; }
    }

    public class BaseApiResponse
    {
        public BaseApiResponse()
        {
            Message = new List<string> { };
        }

        public bool Success { get; set; }

        public IList<string> Message { get; set; }
    }
}
