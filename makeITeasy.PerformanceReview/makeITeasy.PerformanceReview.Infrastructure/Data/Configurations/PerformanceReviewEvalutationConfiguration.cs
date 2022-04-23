﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using makeITeasy.PerformanceReview.Infrastructure;
using makeITeasy.PerformanceReview.Infrastructure.Data;
using makeITeasy.PerformanceReview.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;

namespace makeITeasy.PerformanceReview.Infrastructure.Data.Configurations
{
    public partial class PerformanceReviewEvalutationConfiguration : IEntityTypeConfiguration<PerformanceReviewEvalutation>
    {
        public void Configure(EntityTypeBuilder<PerformanceReviewEvalutation> entity)
        {
            entity.ToTable("PerformanceReviewEvalutation");

            entity.HasOne(d => d.Employee)
                .WithMany(p => p.PerformanceReviewEvalutations)
                .HasForeignKey(d => d.EmployeeId)
                .HasConstraintName("FK_PerformanceReviewEvalutation_ToEmployee");

            entity.HasOne(d => d.PerformanceReviewForm)
                .WithMany(p => p.PerformanceReviewEvalutations)
                .HasForeignKey(d => d.PerformanceReviewFormId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerformanceReviewEvalutation_ToPerformanceReviewForm");

            entity.HasOne(d => d.User)
                .WithMany(p => p.PerformanceReviewEvalutations)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK_PerformanceReviewEvalutation_ToUser");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PerformanceReviewEvalutation> entity);
    }
}
