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
    
    public partial class StorageType
    {
        public StorageType()
        {
            this.Incomes = new HashSet<Income>();
        }
    
        public int ID { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Income> Incomes { get; set; }
    }
}