using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TempApi.Models.Db;
using TempApi.Models.Requests;
using TempApi.Models.Requests.Base;

namespace TempApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/wallets")]
    public class WalletsController : BaseController
    {
        public Message<List<Wallet>> Get()
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                var data = dbContext.Wallets.Where(x => x.UserID == id).ToList();
                var result = new OkMessage<List<Wallet>> { Data = data };

                return result;
            }
        }

        public Message Post([FromBody]Wallet item)
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                dbContext.Wallets.Add(item);
                var income = dbContext.Wallets.FirstOrDefault(x => x.ID == item.ID);
                income.Sum += item.Sum; //Updating INCOME
                income.LastSum += item.Sum;
                dbContext.SaveChanges();
                var result = new OkMessage();
                result.ReturnMessage = "Item successfully added!";
                return result;
            }
        }
    }
}
