using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using TempApi.Models.Requests.Base;

namespace TempApi.Models.Requests
{
    public class OkMessage<T> : Message<T>
    {
        public OkMessage()
        {
            IsSuccess = true;
            StatusCode = (int)HttpStatusCode.OK;
        }
    }

    public class OkMessage : Message
    {
        public OkMessage()
        {
            IsSuccess = true;
            StatusCode = (int)HttpStatusCode.OK;
        }
    }
}