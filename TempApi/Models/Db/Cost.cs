//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TempApi.Models.Db
{
    using System;
    using System.Collections.Generic;
    
    public partial class Cost
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public int IncomeID { get; set; }
        public int UserID { get; set; }
        public decimal Sum { get; set; }
        public System.DateTime Date { get; set; }
        public int CostCategoryID { get; set; }
    
        public virtual Income Income { get; set; }
        public virtual User User { get; set; }
        public virtual CostCategory CostCategory { get; set; }
    }
}
