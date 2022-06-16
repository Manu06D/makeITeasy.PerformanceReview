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
    public partial class AppUserConfiguration : IEntityTypeConfiguration<AppUser>
    {
        public void Configure(EntityTypeBuilder<AppUser> entity)
        {
            entity.ToTable("AppUser", "perfReview");

            entity.HasIndex(e => e.NormalizedEmail, "EmailIndex");

            entity.HasIndex(e => e.NormalizedUserName, "UserNameIndex")
                .IsUnique()
                .HasFilter("([NormalizedUserName] IS NOT NULL)");

            entity.Property(e => e.Education).HasMaxLength(255);

            entity.Property(e => e.Email).HasMaxLength(256);

            entity.Property(e => e.ManagerId).HasMaxLength(450);

            entity.Property(e => e.Name)
                .HasMaxLength(250)
                .IsUnicode(false);

            entity.Property(e => e.NormalizedEmail).HasMaxLength(256);

            entity.Property(e => e.NormalizedUserName).HasMaxLength(256);

            entity.Property(e => e.UserName).HasMaxLength(256);

            entity.HasOne(d => d.Level)
                .WithMany(p => p.AppUsers)
                .HasForeignKey(d => d.LevelId)
                .HasConstraintName("FK_AppUser_ToLevel");

            entity.HasOne(d => d.Manager)
                .WithMany(p => p.InverseManager)
                .HasForeignKey(d => d.ManagerId)
                .HasConstraintName("FK_AppUser_ToTable");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<AppUser> entity);
    }
}
