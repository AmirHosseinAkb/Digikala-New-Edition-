﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UserManagement.Infrastructure.EfCore;

#nullable disable

namespace UserManagement.Infrastructure.EfCore.Migrations
{
    [DbContext(typeof(AccountContext))]
    [Migration("20220730164253_RemovePermissionTitleProperty")]
    partial class RemovePermissionTitleProperty
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.6")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("UserManagement.Domain.RoleAgg.Permission", b =>
                {
                    b.Property<long>("PermissionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("PermissionId"), 1L, 1);

                    b.Property<int>("PermissionCode")
                        .HasColumnType("int");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.HasKey("PermissionId");

                    b.HasIndex("RoleId");

                    b.ToTable("Permissions", (string)null);
                });

            modelBuilder.Entity("UserManagement.Domain.RoleAgg.Role", b =>
                {
                    b.Property<long>("RoleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("RoleId"), 1L, 1);

                    b.Property<string>("RoleTitle")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("RoleId");

                    b.ToTable("Roles", (string)null);

                    b.HasData(
                        new
                        {
                            RoleId = 1L,
                            RoleTitle = "مدیر سایت"
                        },
                        new
                        {
                            RoleId = 2L,
                            RoleTitle = "دستیار مدیر"
                        },
                        new
                        {
                            RoleId = 3L,
                            RoleTitle = "کاربر سایت"
                        });
                });

            modelBuilder.Entity("UserManagement.Domain.TransactionAgg.Transaction", b =>
                {
                    b.Property<long>("TransactionId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TransactionId"), 1L, 1);

                    b.Property<int>("Amount")
                        .HasColumnType("int");

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsSucceeded")
                        .HasColumnType("bit");

                    b.Property<long>("TypeId")
                        .HasColumnType("bigint");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("TransactionId");

                    b.HasIndex("TypeId");

                    b.HasIndex("UserId");

                    b.ToTable("Transactions", (string)null);
                });

            modelBuilder.Entity("UserManagement.Domain.TransactionAgg.TransactionType", b =>
                {
                    b.Property<long>("TypeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("TypeId"), 1L, 1);

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.HasKey("TypeId");

                    b.ToTable("TransactionTypes", (string)null);

                    b.HasData(
                        new
                        {
                            TypeId = 1L,
                            Type = "واریز"
                        },
                        new
                        {
                            TypeId = 2L,
                            Type = "برداشت"
                        });
                });

            modelBuilder.Entity("UserManagement.Domain.UserAgg.User", b =>
                {
                    b.Property<long>("UserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("UserId"), 1L, 1);

                    b.Property<string>("AccountNumber")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("ActivationCode")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("AvatarName")
                        .IsRequired()
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<DateTime?>("BirthDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Email")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("FirstName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<bool>("IsDeleted")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("NationalNumber")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("Password")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<string>("PhoneNumber")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<byte>("RefundType")
                        .HasColumnType("tinyint");

                    b.Property<DateTime>("RegisterDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<int>("VerificationCode")
                        .HasMaxLength(200)
                        .HasColumnType("int");

                    b.HasKey("UserId");

                    b.HasIndex("RoleId");

                    b.ToTable("Users", (string)null);
                });

            modelBuilder.Entity("UserManagement.Domain.RoleAgg.Permission", b =>
                {
                    b.HasOne("UserManagement.Domain.RoleAgg.Role", "Role")
                        .WithMany("Permissions")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UserManagement.Domain.TransactionAgg.Transaction", b =>
                {
                    b.HasOne("UserManagement.Domain.TransactionAgg.TransactionType", "TransactionType")
                        .WithMany("Transactions")
                        .HasForeignKey("TypeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UserManagement.Domain.UserAgg.User", "User")
                        .WithMany("Transactions")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("TransactionType");

                    b.Navigation("User");
                });

            modelBuilder.Entity("UserManagement.Domain.UserAgg.User", b =>
                {
                    b.HasOne("UserManagement.Domain.RoleAgg.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("UserManagement.Domain.RoleAgg.Role", b =>
                {
                    b.Navigation("Permissions");

                    b.Navigation("Users");
                });

            modelBuilder.Entity("UserManagement.Domain.TransactionAgg.TransactionType", b =>
                {
                    b.Navigation("Transactions");
                });

            modelBuilder.Entity("UserManagement.Domain.UserAgg.User", b =>
                {
                    b.Navigation("Transactions");
                });
#pragma warning restore 612, 618
        }
    }
}
