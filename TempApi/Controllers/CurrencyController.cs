using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TempApi.Models.Db;
using TempApi.Models.Requests;
using TempApi.Models.Requests.Base;

namespace TempApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/currency")]
    public class CurrencyController : BaseController
    {
        public Message<List<Currency>> Get()
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                var data = dbContext.Currencies.ToList();
                var result = new OkMessage<List<Currency>> { Data = data };

                return result;
            }
        }
    }
}
