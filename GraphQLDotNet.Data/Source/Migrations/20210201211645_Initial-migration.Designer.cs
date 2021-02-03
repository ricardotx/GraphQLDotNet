﻿// <auto-generated />
using System;
using GraphQLDotNet.Data.Source.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQLDotNet.Data.Source.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20210201211645_Initial-migration")]
    partial class Initialmigration
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.2");

            modelBuilder.Entity("GraphQLDotNet.Core.Source.Models.Account", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Description")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("OwnerId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Type")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("OwnerId");

                    b.ToTable("Accounts");

                    b.HasData(
                        new
                        {
                            Id = new Guid("768e238b-3fb6-4b1d-a8ed-ec9111a41bea"),
                            Description = "Cash account for our users",
                            OwnerId = new Guid("4fc8c99e-d975-449c-9d2a-1ffe86c08f6d"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("67ad16a9-d217-4dc1-8f4a-069617f7d1ab"),
                            Description = "Savings account for our users",
                            OwnerId = new Guid("99e225ed-d0df-416b-b67c-e0cf416baf52"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("fccc5a20-dc27-43ca-ad17-f63f87dda843"),
                            Description = "Income account for our users",
                            OwnerId = new Guid("99e225ed-d0df-416b-b67c-e0cf416baf52"),
                            Type = 3
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.Models.Owner", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Address")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.ToTable("Owners");

                    b.HasData(
                        new
                        {
                            Id = new Guid("4fc8c99e-d975-449c-9d2a-1ffe86c08f6d"),
                            Address = "John Doe's address",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("99e225ed-d0df-416b-b67c-e0cf416baf52"),
                            Address = "Jane Doe's address",
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.Models.Role", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Code")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.HasKey("Id");

                    b.HasIndex("Code")
                        .IsUnique()
                        .HasDatabaseName("UniqueCode");

                    b.ToTable("Roles");

                    b.HasData(
                        new
                        {
                            Id = new Guid("31e0c425-aaa9-4315-b138-fd957e04bf0a"),
                            Code = "admin",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("d7a77eab-6b8c-44b9-a114-f36d81d80990"),
                            Code = "user",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("char(36)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(255) CHARACTER SET utf8mb4");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("longtext CHARACTER SET utf8mb4");

                    b.Property<Guid>("RoleId")
                        .HasColumnType("char(36)");

                    b.Property<int>("Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValue(1);

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique()
                        .HasDatabaseName("UniqueUserEmail");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");

                    b.HasData(
                        new
                        {
                            Id = new Guid("d368833f-6584-47a2-ae55-97962a527954"),
                            Email = "admin@mail.com",
                            Name = "Admin",
                            Password = "123",
                            RoleId = new Guid("31e0c425-aaa9-4315-b138-fd957e04bf0a"),
                            Status = 1
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.Models.Account", b =>
                {
                    b.HasOne("GraphQLDotNet.Core.Source.Models.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.Models.User", b =>
                {
                    b.HasOne("GraphQLDotNet.Core.Source.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.Models.Owner", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.Models.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}