﻿// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;
using TabRepository.Data;
using TabRepository.Models;
using TabRepository.Models.AccountViewModels;

namespace TabRepository.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.0-rtm-26452")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .IsUnique()
                        .HasName("RoleNameIndex")
                        .HasFilter("[NormalizedName] IS NOT NULL");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("TabRepository.Models.Album", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CurrentVersion");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("ImageFileName");

                    b.Property<string>("ImageFilePath");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Order");

                    b.Property<int>("ProjectId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("ProjectId");

                    b.HasIndex("UserId");

                    b.ToTable("Albums");
                });

            modelBuilder.Entity("TabRepository.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AccessFailedCount");

                    b.Property<int>("AccountType");

                    b.Property<string>("Bio");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasMaxLength(256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("FirstName");

                    b.Property<string>("ImageFileName");

                    b.Property<string>("ImageFilePath");

                    b.Property<string>("LastName");

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasMaxLength(256);

                    b.Property<string>("NormalizedUserName")
                        .HasMaxLength(256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<int?>("ProjectId");

                    b.Property<string>("SecurityStamp");

                    b.Property<DateTime?>("SubscriptionExpiration");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasMaxLength(256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex")
                        .HasFilter("[NormalizedUserName] IS NOT NULL");

                    b.HasIndex("ProjectId");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("TabRepository.Models.Friend", b =>
                {
                    b.Property<string>("User1Id");

                    b.Property<string>("User2Id");

                    b.Property<string>("ActingUserId");

                    b.Property<int>("Status");

                    b.HasKey("User1Id", "User2Id");

                    b.HasIndex("ActingUserId");

                    b.HasIndex("User2Id");

                    b.ToTable("Friends");
                });

            modelBuilder.Entity("TabRepository.Models.Notification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("FromUserId");

                    b.Property<string>("Message");

                    b.Property<int>("NotificationType");

                    b.Property<int?>("ProjectId");

                    b.Property<DateTime>("Timestamp");

                    b.Property<string>("Title");

                    b.Property<string>("ToUserId");

                    b.HasKey("Id");

                    b.HasIndex("FromUserId");

                    b.HasIndex("ProjectId");

                    b.HasIndex("ToUserId");

                    b.ToTable("Notifications");
                });

            modelBuilder.Entity("TabRepository.Models.NotificationUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<bool>("IsRead");

                    b.Property<int>("NotificationId");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("NotificationId");

                    b.HasIndex("UserId");

                    b.ToTable("NotificationUsers");
                });

            modelBuilder.Entity("TabRepository.Models.PayPalBillingAgreement", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("BillingAgreementId");

                    b.Property<string>("Description");

                    b.Property<string>("ExecuteURL");

                    b.Property<string>("Json");

                    b.Property<string>("PlanId");

                    b.Property<string>("RequestToken");

                    b.Property<string>("State");

                    b.Property<string>("Token");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("PayPalBillingAgreement");
                });

            modelBuilder.Entity("TabRepository.Models.PayPalBillingPlan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Json");

                    b.Property<string>("Name");

                    b.Property<string>("State");

                    b.HasKey("Id");

                    b.ToTable("PayPalBillingPlan");
                });

            modelBuilder.Entity("TabRepository.Models.PayPalPlan", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Json");

                    b.Property<string>("Name");

                    b.Property<string>("ProductId");

                    b.Property<string>("Status");

                    b.HasKey("Id");

                    b.HasIndex("ProductId");

                    b.ToTable("PayPalPlans");
                });

            modelBuilder.Entity("TabRepository.Models.PayPalProduct", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Json");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("PayPalProducts");
                });

            modelBuilder.Entity("TabRepository.Models.PayPalSubscription", b =>
                {
                    b.Property<string>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Json");

                    b.Property<string>("Name");

                    b.Property<string>("PlanId");

                    b.Property<string>("Status");

                    b.Property<string>("SubscriptionToken");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("PlanId");

                    b.HasIndex("UserId");

                    b.ToTable("PayPalSubscriptions");
                });

            modelBuilder.Entity("TabRepository.Models.Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("ImageFileName");

                    b.Property<string>("ImageFilePath");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("Projects");
                });

            modelBuilder.Entity("TabRepository.Models.ProjectContributor", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("ProjectId");

                    b.HasKey("UserId", "ProjectId");

                    b.HasAlternateKey("ProjectId", "UserId");

                    b.ToTable("ProjectContributors");
                });

            modelBuilder.Entity("TabRepository.Models.Tab", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("AlbumId");

                    b.Property<int>("CurrentVersion");

                    b.Property<DateTime>("DateCreated");

                    b.Property<DateTime>("DateModified");

                    b.Property<string>("Description");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(255);

                    b.Property<int>("Order");

                    b.Property<string>("UserId");

                    b.HasKey("Id");

                    b.HasIndex("AlbumId");

                    b.HasIndex("UserId");

                    b.ToTable("Tabs");
                });

            modelBuilder.Entity("TabRepository.Models.TabFile", b =>
                {
                    b.Property<int>("Id");

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Name");

                    b.Property<byte[]>("TabData");

                    b.HasKey("Id");

                    b.ToTable("TabFiles");
                });

            modelBuilder.Entity("TabRepository.Models.TabVersion", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<DateTime>("DateCreated");

                    b.Property<string>("Description");

                    b.Property<int>("TabId");

                    b.Property<string>("UserId");

                    b.Property<int>("Version");

                    b.HasKey("Id");

                    b.HasIndex("TabId");

                    b.HasIndex("UserId");

                    b.ToTable("TabVersions");
                });

            modelBuilder.Entity("TabRepository.Models.UserTabVersion", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<int>("TabId");

                    b.Property<int>("Version");

                    b.HasKey("UserId", "TabId");

                    b.HasIndex("TabId");

                    b.ToTable("UserTabVersions");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("TabRepository.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("TabRepository.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.IdentityRole")
                        .WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabRepository.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.HasOne("TabRepository.Models.ApplicationUser")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TabRepository.Models.Album", b =>
                {
                    b.HasOne("TabRepository.Models.Project", "Project")
                        .WithMany("Albums")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabRepository.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TabRepository.Models.ApplicationUser", b =>
                {
                    b.HasOne("TabRepository.Models.Project")
                        .WithMany("Contributors")
                        .HasForeignKey("ProjectId");
                });

            modelBuilder.Entity("TabRepository.Models.Friend", b =>
                {
                    b.HasOne("TabRepository.Models.ApplicationUser", "ActingUser")
                        .WithMany()
                        .HasForeignKey("ActingUserId");

                    b.HasOne("TabRepository.Models.ApplicationUser", "User1")
                        .WithMany()
                        .HasForeignKey("User1Id")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TabRepository.Models.ApplicationUser", "User2")
                        .WithMany()
                        .HasForeignKey("User2Id")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TabRepository.Models.Notification", b =>
                {
                    b.HasOne("TabRepository.Models.ApplicationUser", "FromUser")
                        .WithMany()
                        .HasForeignKey("FromUserId");

                    b.HasOne("TabRepository.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId");

                    b.HasOne("TabRepository.Models.ApplicationUser", "ToUser")
                        .WithMany()
                        .HasForeignKey("ToUserId");
                });

            modelBuilder.Entity("TabRepository.Models.NotificationUser", b =>
                {
                    b.HasOne("TabRepository.Models.Notification", "Notification")
                        .WithMany()
                        .HasForeignKey("NotificationId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabRepository.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TabRepository.Models.PayPalBillingAgreement", b =>
                {
                    b.HasOne("TabRepository.Models.PayPalBillingPlan", "Plan")
                        .WithMany("BillingAgreements")
                        .HasForeignKey("PlanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabRepository.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TabRepository.Models.PayPalPlan", b =>
                {
                    b.HasOne("TabRepository.Models.PayPalProduct", "Product")
                        .WithMany("Plans")
                        .HasForeignKey("ProductId");
                });

            modelBuilder.Entity("TabRepository.Models.PayPalSubscription", b =>
                {
                    b.HasOne("TabRepository.Models.PayPalPlan", "Plan")
                        .WithMany()
                        .HasForeignKey("PlanId");

                    b.HasOne("TabRepository.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TabRepository.Models.Project", b =>
                {
                    b.HasOne("TabRepository.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TabRepository.Models.ProjectContributor", b =>
                {
                    b.HasOne("TabRepository.Models.Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.HasOne("TabRepository.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Restrict);
                });

            modelBuilder.Entity("TabRepository.Models.Tab", b =>
                {
                    b.HasOne("TabRepository.Models.Album", "Album")
                        .WithMany("Tabs")
                        .HasForeignKey("AlbumId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabRepository.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TabRepository.Models.TabFile", b =>
                {
                    b.HasOne("TabRepository.Models.TabVersion", "TabVersion")
                        .WithOne("TabFile")
                        .HasForeignKey("TabRepository.Models.TabFile", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("TabRepository.Models.TabVersion", b =>
                {
                    b.HasOne("TabRepository.Models.Tab", "Tab")
                        .WithMany("TabVersions")
                        .HasForeignKey("TabId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabRepository.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId");
                });

            modelBuilder.Entity("TabRepository.Models.UserTabVersion", b =>
                {
                    b.HasOne("TabRepository.Models.Tab", "Tab")
                        .WithMany()
                        .HasForeignKey("TabId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("TabRepository.Models.ApplicationUser", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
