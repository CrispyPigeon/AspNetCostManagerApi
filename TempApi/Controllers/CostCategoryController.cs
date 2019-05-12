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
    [RoutePrefix("api/costcategory")]
    public class CostCategoryController : BaseController
    {
        public Message<List<CostCategory>> Get()
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                var data = dbContext.CostCategories.ToList();
                var result = new OkMessage<List<CostCategory>> { Data = data };

                return result;
            }
        }
    }
}
