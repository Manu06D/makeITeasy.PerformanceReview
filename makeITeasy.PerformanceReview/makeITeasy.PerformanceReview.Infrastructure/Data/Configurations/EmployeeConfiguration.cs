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
    public partial class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> entity)
        {
            entity.HasKey(e => e.UserIdentityId);

            entity.ToTable("Employee", "perfReview");

            entity.Property(e => e.Id).ValueGeneratedOnAdd();

            entity.Property(e => e.ManagerIdentityId)
                .IsRequired()
                .HasMaxLength(450);

            entity.HasOne(d => d.ManagerIdentity)
                .WithMany(p => p.EmployeeManagerIdentities)
                .HasForeignKey(d => d.ManagerIdentityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_ToTable_1");

            entity.HasOne(d => d.UserIdentity)
                .WithOne(p => p.EmployeeUserIdentity)
                .HasForeignKey<Employee>(d => d.UserIdentityId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Employee_ToTable");

            OnConfigurePartial(entity);
        }

        partial void OnConfigurePartial(EntityTypeBuilder<Employee> entity);
    }
}
