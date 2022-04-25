
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
    public partial class PeformanceReviewDbContext : IdentityDbContext<IdentityUser>
    {
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<PerformanceReviewEvaluationItem> PerformanceReviewEvaluationItems { get; set; }
        public virtual DbSet<PerformanceReviewEvalutation> PerformanceReviewEvalutations { get; set; }
        public virtual DbSet<PerformanceReviewForm> PerformanceReviewForms { get; set; }
        public virtual DbSet<PerformanceReviewItem> PerformanceReviewItems { get; set; }

        public PeformanceReviewDbContext(DbContextOptions<PeformanceReviewDbContext> options) : base(options)
        {
        }

            protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=makeITeasy.PerformanceReview.Databases;Integrated Security=true");

            modelBuilder.ApplyConfiguration(new Configurations.EmployeeConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PerformanceReviewEvaluationItemConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PerformanceReviewEvalutationConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PerformanceReviewFormConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PerformanceReviewItemConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
    }
