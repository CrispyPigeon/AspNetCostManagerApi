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
            if (item == null)
                return new BadMessage();
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                if (item.ID == 0)
                {
                    item.UserID = id;
                    dbContext.Wallets.Add(item);
                }
                else
                {
                    var wallet = dbContext.Wallets.FirstOrDefault(x => x.ID == item.ID);
                    wallet.Name = item.Name;
                }
                dbContext.SaveChanges();
                var result = new OkMessage();
                result.ReturnMessage = "Item successfully added!";
                return result;
            }
        }

        [HttpDelete, Route("{walletId}")]
        public Message RemoveItem(int walletId)
        {
            if (walletId == 0)
                return new BadMessage();
            using (var dbContext = InitializeDbContext())
            {
                var wallet = dbContext.Wallets.FirstOrDefault(x => x.ID == walletId);
                if (wallet == null)
                {
                    return new BadMessage("Wallet not found!");
                }
                var incomeNotes = dbContext.IncomeNotes.Where(x => x.WalletID == walletId).ToList();
                dbContext.IncomeNotes.RemoveRange(incomeNotes);
                var costs = dbContext.Costs.Where(x => x.WalletID == walletId).ToList();
                dbContext.Costs.RemoveRange(costs);
                dbContext.Wallets.Remove(wallet);
                dbContext.SaveChanges();
                var result = new OkMessage();
                result.ReturnMessage = "Wallet and Incomes successfully deleted!";
                return result;
            }
        }
    }
}
