using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TempApi.Models.Db;
using TempApi.Models.Requests;
using TempApi.Models.Requests.Base;

namespace TempApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/storagetype")]
    public class StorageTypeController : BaseController
    {
        public Message<List<StorageType>> Get()
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                var data = dbContext.StorageTypes.ToList();
                var result = new OkMessage<List<StorageType>> { Data = data };

                return result;
            }
        }
    }
}
