﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace JobTrackerWeb.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class DbJobTrackingEntities : DbContext
    {
        public DbJobTrackingEntities()
            : base("name=DbJobTrackingEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Admin> Admin { get; set; }
        public virtual DbSet<Call> Call { get; set; }
        public virtual DbSet<CallDetails> CallDetails { get; set; }
        public virtual DbSet<Companies> Companies { get; set; }
        public virtual DbSet<Departments> Departments { get; set; }
        public virtual DbSet<MissionDetails> MissionDetails { get; set; }
        public virtual DbSet<Missions> Missions { get; set; }
        public virtual DbSet<Personel> Personel { get; set; }
        public virtual DbSet<sysdiagrams> sysdiagrams { get; set; }
        public virtual DbSet<Messages> Messages { get; set; }
    }
}
