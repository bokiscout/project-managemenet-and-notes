﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace project_management_and_notes
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class ProjectsDbEntities : DbContext
    {
        public ProjectsDbEntities()
            : base("name=ProjectsDbEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<Assignment> Assignments { get; set; }
        public virtual DbSet<CSSCode> CSSCodes { get; set; }
        public virtual DbSet<LoginInfo> LoginInfoes { get; set; }
        public virtual DbSet<Project> Projects { get; set; }
    }
}