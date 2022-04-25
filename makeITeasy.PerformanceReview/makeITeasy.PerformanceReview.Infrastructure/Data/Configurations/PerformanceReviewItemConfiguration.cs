﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
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
    public partial class PerformanceReviewItemConfiguration : IEntityTypeConfiguration<PerformanceReviewItem>
    {
        public void Configure(EntityTypeBuilder<PerformanceReviewItem> entity)
        {
            entity.ToTable("PerformanceReviewItem");

            entity.Property(e => e.Category)
                .HasMaxLength(50)
                .IsUnicode(false);

            entity.Property(e => e.Description)
                .IsRequired()
                .HasMaxLength(512)
                .IsUnicode(false);

            entity.HasOne(d => d.PerformanceReview)
                .WithMany(p => p.PerformanceReviewItems)
                .HasForeignKey(d => d.PerformanceReviewId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PerformanceReviewQuestion_ToPerformanceReview");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<PerformanceReviewItem> entity);
    }
}
