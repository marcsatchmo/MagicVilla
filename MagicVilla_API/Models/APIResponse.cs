using System.Net;

namespace MagicVilla_API.Modelos
{
    public class APIResponse
    {
        public HttpStatusCode  StatusCode { get; set; }
        public bool IsSuccessful { get; set; }
        public List<string> ErrorMessage { get; set; }
        public object Result { get; set; }
    }
}
