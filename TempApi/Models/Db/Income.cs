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
    using System.ComponentModel.DataAnnotations.Schema;

    [Table("Income")]
    public partial class Income
    {
        public Income()
        {
            this.Costs = new HashSet<Cost>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
        public int StorageTypeID { get; set; }
        public int CurrencyID { get; set; }
        public int UserID { get; set; }
        public decimal Sum { get; set; }
    
        public virtual ICollection<Cost> Costs { get; set; }
        public virtual Currency Currency { get; set; }
        public virtual StorageType StorageType { get; set; }
        public virtual User User { get; set; }
    }
}