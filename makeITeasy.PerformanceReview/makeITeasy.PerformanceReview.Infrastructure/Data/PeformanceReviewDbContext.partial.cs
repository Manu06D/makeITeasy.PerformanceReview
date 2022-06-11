using makeITeasy.PerformanceReview.Models;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace makeITeasy.PerformanceReview.Infrastructure.Data
{
    public partial class PeformanceReviewDbContext 
    {
        private const string adminId = "2301D884-221A-4E7D-B509-0113DCC043E1";
        private const string employeeId = "7D9B7113-A8F8-4035-99A7-A20DD400F6A3";
        private const string managerId = "78A7570F-3CE5-48BA-9461-80283ED1D94D";
        private const string adminUserId = "B22698B8-42A2-4115-9631-1C2D1E2AC5F7";
        private const string adminRoleId = "2301D884-221A-4E7D-B509-0113DCC043E1";

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
            {
                b.Property<string>("Id")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("ConcurrencyStamp")
                    .IsConcurrencyToken()
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.Property<string>("NormalizedName")
                    .HasColumnType("nvarchar(256)")
                    .HasMaxLength(256);

                b.HasKey("Id");

                b.HasIndex("NormalizedName")
                    .IsUnique()
                    .HasName("RoleNameIndex")
                    .HasFilter("[NormalizedName] IS NOT NULL");

                b.ToTable("AspNetRoles", "perfReview");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("RoleId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("Id");

                b.HasIndex("RoleId");

                b.ToTable("AspNetRoleClaims", "perfReview");
            });

            //modelBuilder.Entity("makeITeasy.PerformanceReview.Models.AppUser", b =>
            //{
            //    b.Property<string>("Id")
            //        .HasColumnType("nvarchar(450)");

            //    b.Property<int>("AccessFailedCount")
            //        .HasColumnType("int");

            //    b.Property<string>("ConcurrencyStamp")
            //        .IsConcurrencyToken()
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<string>("Email")
            //        .HasColumnType("nvarchar(256)")
            //        .HasMaxLength(256);

            //    b.Property<bool>("EmailConfirmed")
            //        .HasColumnType("bit");

            //    b.Property<bool>("LockoutEnabled")
            //        .HasColumnType("bit");

            //    b.Property<DateTimeOffset?>("LockoutEnd")
            //        .HasColumnType("datetimeoffset");

            //    b.Property<string>("NormalizedEmail")
            //        .HasColumnType("nvarchar(256)")
            //        .HasMaxLength(256);

            //    b.Property<string>("NormalizedUserName")
            //        .HasColumnType("nvarchar(256)")
            //        .HasMaxLength(256);

            //    b.Property<string>("PasswordHash")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<string>("PhoneNumber")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<bool>("PhoneNumberConfirmed")
            //        .HasColumnType("bit");

            //    b.Property<string>("SecurityStamp")
            //        .HasColumnType("nvarchar(max)");

            //    b.Property<bool>("TwoFactorEnabled")
            //        .HasColumnType("bit");

            //    b.Property<string>("UserName")
            //        .HasColumnType("nvarchar(256)")
            //        .HasMaxLength(256);

            //    b.HasKey("Id");

            //    b.HasIndex("NormalizedEmail")
            //        .HasName("EmailIndex");

            //    b.HasIndex("NormalizedUserName")
            //        .IsUnique()
            //        .HasName("UserNameIndex")
            //        .HasFilter("[NormalizedUserName] IS NOT NULL");

            //    b.ToTable("AppUser");
            //});

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.Property<int>("Id")
                    .ValueGeneratedOnAdd()
                    .HasColumnType("int")
                    .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                b.Property<string>("ClaimType")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("ClaimValue")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("Id");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserClaims", "perfReview");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.Property<string>("LoginProvider")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                b.Property<string>("ProviderKey")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                b.Property<string>("ProviderDisplayName")
                    .HasColumnType("nvarchar(max)");

                b.Property<string>("UserId")
                    .IsRequired()
                    .HasColumnType("nvarchar(450)");

                b.HasKey("LoginProvider", "ProviderKey");

                b.HasIndex("UserId");

                b.ToTable("AspNetUserLogins");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("RoleId")
                    .HasColumnType("nvarchar(450)");

                b.HasKey("UserId", "RoleId");

                b.HasIndex("RoleId");

                b.ToTable("AspNetUserRoles", "perfReview");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.Property<string>("UserId")
                    .HasColumnType("nvarchar(450)");

                b.Property<string>("LoginProvider")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                b.Property<string>("Name")
                    .HasColumnType("nvarchar(128)")
                    .HasMaxLength(128);

                b.Property<string>("Value")
                    .HasColumnType("nvarchar(max)");

                b.HasKey("UserId", "LoginProvider", "Name");

                b.ToTable("AspNetUserTokens", "perfReview");
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
            {
                b.HasOne("makeITeasy.PerformanceReview.Models.AppUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
            {
                b.HasOne("makeITeasy.PerformanceReview.Models.AppUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
            {
                b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole", null)
                    .WithMany()
                    .HasForeignKey("RoleId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();

                b.HasOne("makeITeasy.PerformanceReview.Models.AppUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
            {
                b.HasOne("makeITeasy.PerformanceReview.Models.AppUser", null)
                    .WithMany()
                    .HasForeignKey("UserId")
                    .OnDelete(DeleteBehavior.Cascade)
                    .IsRequired();
            });
#pragma warning restore 612, 618
        }
    }
}
