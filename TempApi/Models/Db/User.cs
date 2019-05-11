namespace TempApi.Models.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Costs = new HashSet<Cost>();
            this.Incomes = new HashSet<Income>();
            this.MonthPlans = new HashSet<MonthPlan>();
        }
    
        public int ID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
    
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual ICollection<Income> Incomes { get; set; }
        public virtual ICollection<MonthPlan> MonthPlans { get; set; }
    }
}
