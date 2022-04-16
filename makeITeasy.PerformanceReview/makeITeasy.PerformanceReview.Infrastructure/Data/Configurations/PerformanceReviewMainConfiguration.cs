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
    public partial class PerformanceReviewMainConfiguration : IEntityTypeConfiguration<PerformanceReviewMain>
    {
        public void Configure(EntityTypeBuilder<PerformanceReviewMain> entity)
        {
            entity.ToTable("PerformanceReviewMain");

            entity.Property(e => e.Id).ValueGeneratedNever();

            entity.Property(e => e.Name)
                .IsRequired()
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.HasOne(d => d.User)
                .WithMany(p => p.PerformanceReviewMains)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerformanceReview_ToUser");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PerformanceReviewMain> entity);
    }
}
