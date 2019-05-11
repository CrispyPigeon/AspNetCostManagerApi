﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TempApi.Models.Db
{
    using Microsoft.AspNet.Identity.EntityFramework;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class costmanagerdbEntities : DbContext
    {
        public costmanagerdbEntities()
            : base(Consts.DbConnectionString)
        {
            this.Configuration.LazyLoadingEnabled = false;
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema(Consts.DbSchema);
        }

        public virtual DbSet<CostCategory> CostCategories { get; set; }
        public virtual DbSet<Cost> Costs { get; set; }
        public virtual DbSet<Currency> Currencies { get; set; }
        public virtual DbSet<Income> Income { get; set; }
        public virtual DbSet<MonthPlan> MonthPlans { get; set; }
        public virtual DbSet<StorageType> StorageTypes { get; set; }
        public virtual DbSet<User> Users { get; set; }
    }
}
