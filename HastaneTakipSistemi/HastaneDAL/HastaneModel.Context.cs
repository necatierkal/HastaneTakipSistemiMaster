﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HastaneTakipSistemi.HastaneDAL
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class htoEntities : DbContext
    {
        public htoEntities()
            : base("name=htoEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<admin> admin { get; set; }
        public virtual DbSet<doktorlar> doktorlar { get; set; }
        public virtual DbSet<eczacilar> eczacilar { get; set; }
        public virtual DbSet<hastalar> hastalar { get; set; }
        public virtual DbSet<hemsireler> hemsireler { get; set; }
        public virtual DbSet<klinikler> klinikler { get; set; }
        public virtual DbSet<kliniklerx> kliniklerx { get; set; }
        public virtual DbSet<lab> lab { get; set; }
        public virtual DbSet<randevular> randevular { get; set; }
        public virtual DbSet<recete> recete { get; set; }
        public virtual DbSet<Ilceler> Ilceler { get; set; }
        public virtual DbSet<Iller> Iller { get; set; }
    }
}
