
using makeITeasy.PerformanceReview.Infrastructure;
using makeITeasy.PerformanceReview.Infrastructure.Data.Configurations;
using makeITeasy.PerformanceReview.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
namespace makeITeasy.PerformanceReview.Infrastructure.Data
{
    public partial class PeformanceReviewDbContext : DbContext
    {
        public virtual DbSet<PerformanceReviewCategory> PerformanceReviewCategories { get; set; }
        public virtual DbSet<PerformanceReviewEvaluationItem> PerformanceReviewEvaluationItems { get; set; }
        public virtual DbSet<PerformanceReviewEvalutation> PerformanceReviewEvalutations { get; set; }
        public virtual DbSet<PerformanceReviewItem> PerformanceReviewItems { get; set; }
        public virtual DbSet<PerformanceReviewMain> PerformanceReviewMains { get; set; }
        public virtual DbSet<User> Users { get; set; }

        public PeformanceReviewDbContext(DbContextOptions<PeformanceReviewDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Scaffolding:ConnectionString", "Data Source=(local);Initial Catalog=makeITeasy.PerformanceReview.Databases;Integrated Security=true");

            modelBuilder.ApplyConfiguration(new Configurations.PerformanceReviewCategoryConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PerformanceReviewEvaluationItemConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PerformanceReviewEvalutationConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PerformanceReviewItemConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.PerformanceReviewMainConfiguration());
            modelBuilder.ApplyConfiguration(new Configurations.UserConfiguration());
            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
