﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace TechnicalKnowledge
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class TechnicalKnowledgeDBEntities : DbContext
    {
        public TechnicalKnowledgeDBEntities()
            : base("name=TechnicalKnowledgeDBEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Clientes> Clientes { get; set; }
        public virtual DbSet<Filme> Filme { get; set; }
        public virtual DbSet<Locacao> Locacao { get; set; }
    }
}
