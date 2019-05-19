using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempApi.Models.Requests.CostsByIncome
{
    public class CostByCategory
    {
        public string CategoryName { get; set; }

        public decimal Sum { get; set; }
    }
}