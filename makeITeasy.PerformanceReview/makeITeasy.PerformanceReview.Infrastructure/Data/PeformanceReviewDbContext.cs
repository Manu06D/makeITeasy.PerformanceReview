
using makeITeasy.PerformanceReview.Infrastructure;
using makeITeasy.PerformanceReview.Infrastructure.Data.Configurations;
using makeITeasy.PerformanceReview.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
namespace makeITeasy.PerformanceReview.Infrastructure.Data
{
    public partial class PeformanceReviewDbContext : IdentityDbContext<AppUser>
    {
        public virtual DbSet<AppUser> AppUsers { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<Evaluation> Evaluations { get; set; }
        public virtual DbSet<EvaluationItem> EvaluationItems { get; set; }
        public virtual DbSet<Form> Forms { get; set; }
        public virtual DbSet<FormItem> FormItems { get; set; }

        public PeformanceReviewDbContext(DbContextOptions<PeformanceReviewDbContext> options) : base(options)
        {
        }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=makeITeasy.PerformanceReview.Databases;Integrated Security=true");

            modelBuilder.ApplyConfiguration(new Configurations.AppUserConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EvaluationConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.EvaluationItemConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FormConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.FormItemConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    }
