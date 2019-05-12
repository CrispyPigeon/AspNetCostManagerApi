using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempApi.Models.Requests.Base
{
    public class Message
    {
        public bool IsSuccess { get; set; }

        public int StatusCode { get; set; }

        public string ReturnMessage { get; set; }       
    }

    public class Message<T> : Message
    {
        public T Data { get; set; }
    }
}
