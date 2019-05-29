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
            if (item == null)
                return new BadMessage();
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                if (item.ID == 0)
                {
                    item.UserID = id;
                    var wallet = dbContext.Wallets.FirstOrDefault(x => x.ID == item.WalletID);
                    var decresult = wallet.LastSum - item.Sum;
                    if (decresult < 0)
                        return new Message
                        {
                            StatusCode = (int)HttpStatusCode.Conflict,
                            IsSuccess = false,
                            ReturnMessage = "Wallet last sum can not be less than 0!"
                        };
                    wallet.LastSum = decresult;
                    dbContext.Costs.Add(item);
                }
                else
                {
                    var cost = dbContext.Costs.FirstOrDefault(x => x.ID == item.ID);
                    cost.Name = item.Name;
                }
                dbContext.SaveChanges();
                var result = new OkMessage();
                result.ReturnMessage = "Item successfully added!";
                return result;
            }
        }
    }
}
