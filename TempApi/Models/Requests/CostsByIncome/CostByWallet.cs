using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TempApi.Models.Requests.CostsByIncome
{
    public class CostByWallet
    {
        public WalletOfCosts Wallet { get; set; }

        public List<CostByCategory> Costs { get; set; }
    }
}