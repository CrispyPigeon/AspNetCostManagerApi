using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempApi.Models.Requests
{
    public class MoneyLastResponse
    {
        public int IncomeId { get; set; }

        public decimal Sum { get; set; }
    }
}