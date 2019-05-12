using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using TempApi.Models.Requests.Base;

namespace TempApi.Models.Requests
{
    public class BadMessage<T> : Message<T>
    {
        public BadMessage()
        {
            IsSuccess = false;
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }

    public class BadMessage : Message
    {
        public BadMessage()
        {
            IsSuccess = false;
            StatusCode = (int)HttpStatusCode.InternalServerError;
        }
    }
}