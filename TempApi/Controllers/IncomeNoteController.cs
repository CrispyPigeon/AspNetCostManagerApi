﻿using System;
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
    [RoutePrefix("api/incomenote")]
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

        public Message Post([FromBody]IncomeNote item)
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
                    wallet.Sum += item.Sum;
                    wallet.LastSum += item.Sum;
                    dbContext.IncomeNotes.Add(item);
                }
                else
                {
                    var incomeNote = dbContext.IncomeNotes.FirstOrDefault(x => x.ID == item.ID);
                    incomeNote.Name = item.Name;
                }
                dbContext.SaveChanges();
                var result = new OkMessage();
                result.ReturnMessage = "Item successfully added!";
                return result;                
            }
        }
    }
}
