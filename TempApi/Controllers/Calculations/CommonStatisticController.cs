using System;
using System.Collections.Generic;
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
        public Message<List<CostByIncome>> Get()
        {
            using (var dbContext = InitializeDbContext())
            {
                var incomes = dbContext.Income.Select(x => new Income
                {
                    Name = x.Name,
                    Sum = x.Sum,
                    LastSum = x.LastSum,
                    Costs = x.Costs.AsQueryable().Select(y => new Cost
                    {
                        Sum = y.Sum,
                        CostCategory = y.CostCategory

                    }).ToList(),
                    Currency = x.Currency
                }).ToList();

                List<CostByIncome> result = new List<CostByIncome>();

                foreach (var income in incomes)
                {
                    result.Add(new CostByIncome
                    {
                        Income = new IncomeForCosts
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

                var resultMessage = new OkMessage<List<CostByIncome>>();
                resultMessage.ReturnMessage = "Common Statistic!";
                resultMessage.Data = result;
                return resultMessage;
            }
        }
    }
}
