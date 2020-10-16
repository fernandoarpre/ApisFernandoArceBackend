using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace Common.Responses
{
    public class BaseResponse<T>
    {
        public HttpStatusCode statusCode { get; set; }
        public string msg { get; set; }
        public T response { get; set; }
    }
}
