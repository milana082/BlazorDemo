using System.Net;

namespace CrudOperations.Models
{
    
    public class BaseApiResponse
    {
        public BaseApiResponse()
        {

        }

        public bool Success { get; set; }

        public string Message { get; set; }

        public string Id { get; set; }
        public HttpStatusCode StatusCode { get; set; }
    }

    public class ApiResponse<T> : BaseApiResponse
    {
        public virtual IList<T> Data { get; set; }

    }
   
}
