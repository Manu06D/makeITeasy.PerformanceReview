// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using makeITeasy.PerformanceReview.Infrastructure;
using makeITeasy.PerformanceReview.Infrastructure.Data;
using makeITeasy.PerformanceReview.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace makeITeasy.PerformanceReview.Infrastructure.Data.Configurations
{
    public partial class EvaluationItemConfiguration : IEntityTypeConfiguration<EvaluationItem>
    {
        public void Configure(EntityTypeBuilder<EvaluationItem> entity)
        {
            entity.ToTable("EvaluationItem", "perfReview");

            entity.Property(e => e.UserIdentityId)
                .IsRequired()
                .HasMaxLength(450);

            entity.HasOne(d => d.Evaluation)
                .WithMany(p => p.EvaluationItems)
                .HasForeignKey(d => d.EvaluationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerformanceReviewEvaluationItem_ToPerformanceReviewEvalution");

            entity.HasOne(d => d.FormItem)
                .WithMany(p => p.EvaluationItems)
                .HasForeignKey(d => d.FormItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerformanceReviewEvaluationItem_ToPerformanceReviewItem");

            entity.HasOne(d => d.UserIdentity)
                .WithMany(p => p.EvaluationItems)
                .HasForeignKey(d => d.UserIdentityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_EvaluationItem_ToTable");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<EvaluationItem> entity);
    }
}
