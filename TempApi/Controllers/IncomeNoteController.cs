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
    public class IncomeNoteController : BaseController
    {
        public Message<List<IncomeNote>> Get()
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                var data = dbContext.IncomeNotes.Where(x => x.UserID == id).ToList();
                var result = new OkMessage<List<IncomeNote>> { Data = data };

                return result;
            }
        }

        public Message Post([FromBody]Cost item)
        {
            using (var dbContext = InitializeDbContext())
            {
                var id = GetUserDbId();
                dbContext.Costs.Add(item);
                dbContext.SaveChanges();
                var result = new OkMessage();
                result.ReturnMessage = "Item successfully added!";
                return result;
            }
        }
    }
}
