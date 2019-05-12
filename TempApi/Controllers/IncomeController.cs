using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using TempApi.Models.Db;
using TempApi.Models.Requests;
using TempApi.Models.Requests.Base;

namespace TempApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/income")]
    public class IncomeController : BaseController
    {
        public Message<List<Income>> Get()
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                var data = dbContext.Income.Where(x => x.UserID == id).ToList();
                var result = new OkMessage<List<Income>> { Data = data };

                return result;
            }
        }

        public Message Post([FromBody]Income item)
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                dbContext.Income.Add(item);
                var income = dbContext.Income.FirstOrDefault(x => x.ID == item.ID);
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
