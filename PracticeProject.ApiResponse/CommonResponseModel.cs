using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace PracticeProject.ApiResponse
{
    public class CommonResponseModel
    {
        public HttpStatusCode HttpStatusCode { get; set; }
        public dynamic? Data { get; set; }
        public string Message { get; set; }
    }
}
