﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace GovHack.Data.Entities
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class aayaDbEntities : DbContext
    {
        public aayaDbEntities()
            : base("name=aayaDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<ChildCareOperations> ChildCareOperations { get; set; }
        public virtual DbSet<Crime> Crime { get; set; }
        public virtual DbSet<Locations> Locations { get; set; }
        public virtual DbSet<transport> transport { get; set; }
    }
}