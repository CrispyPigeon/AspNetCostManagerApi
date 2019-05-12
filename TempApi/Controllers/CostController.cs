using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Threading;
using System.Web.Http;
using TempApi.Models.Db;
using TempApi.Models.Requests;
using TempApi.Models.Requests.Base;

namespace TempApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/cost")]
    public class CostController : BaseController
    {
        public Message<List<Cost>> Get()
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                var data = dbContext.Costs.Where(x => x.UserID == id).ToList();
                var result = new OkMessage<List<Cost>> { Data = data };

                return result;
            }
        }

        public Message Post([FromBody]Cost item)
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                dbContext.Costs.Add(item);
                var income = dbContext.Income.FirstOrDefault(x => x.ID == item.ID);
                income.LastSum -= item.Sum; //Updating INCOME
                dbContext.SaveChanges();
                var result = new OkMessage();
                result.ReturnMessage = "Item successfully added!";
                return result;
            }
        }
    }
}
