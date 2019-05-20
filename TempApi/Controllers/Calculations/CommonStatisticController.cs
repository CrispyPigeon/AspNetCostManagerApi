using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using TempApi.Models.Db;
using TempApi.Models.Requests;
using TempApi.Models.Requests.Base;
using TempApi.Models.Requests.CostsByIncome;

namespace TempApi.Controllers.Calculations
{
    [Authorize]
    [RoutePrefix("api/commonstatistic")]
    public class CommonStatisticController : BaseController
    {
        public Message<List<CostByWallet>> Get()
        {
            using (var dbContext = InitializeDbContext())
            {
                var userId = GetUserDbId();
                //var incomes = dbContext.Wallets.Where(x => x.UserID == userId)
                //    .Select(x => new Wallet
                //{
                //    Name = x.Name,
                //    Sum = x.Sum,
                //    LastSum = x.LastSum,
                //    Costs = x.Costs.AsQueryable().Select(y => new Cost
                //    {
                //        Sum = y.Sum,
                //        CostCategory = y.CostCategory

                //    }).ToList(),
                //    Currency = x.Currency
                //}).ToList();

                var incomes = dbContext.Wallets.Where(x => x.UserID == userId)
                    .Include(y => y.Costs.Select(z => z.CostCategory))
                    .Include("Currency")
                    .ToList();

                List<CostByWallet> result = new List<CostByWallet>();

                foreach (var income in incomes)
                {
                    result.Add(new CostByWallet
                    {
                        Wallet = new IncomeForCosts
                        {
                            Name = income.Name,
                            Sum = income.Sum,
                            LastSum = income.LastSum,
                            Currency = income.Currency.Name
                        },
                        Costs = income.Costs.Select(x => new CostByCategory
                        {
                            CategoryName = x.CostCategory.Name,
                            Sum = x.Sum
                        }).ToList()
                    });
                }

                var resultMessage = new OkMessage<List<CostByWallet>>();
                resultMessage.ReturnMessage = "Common Statistic!";
                resultMessage.Data = result;
                return resultMessage;
            }
        }
    }
}
