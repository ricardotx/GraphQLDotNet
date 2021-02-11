﻿// <auto-generated />
using System;
using GraphQLDotNet.Data.Source.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GraphQLDotNet.Data.Source.Migrations
{
    [DbContext(typeof(StorageContext))]
    partial class StorageContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 64)
                .HasAnnotation("ProductVersion", "5.0.3");

            modelBuilder.Entity("GraphQLDotNet.Core.Source.DataModels.Account", b =>
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
                            Id = new Guid("eef35151-b79d-4a49-80f3-4835d88fadb2"),
                            Description = "Cash account for our users",
                            OwnerId = new Guid("bd692961-78d8-488e-bdec-3663d6401b61"),
                            Type = 0
                        },
                        new
                        {
                            Id = new Guid("d4f59aaa-789c-43ee-ba0b-4360086cba8b"),
                            Description = "Savings account for our users",
                            OwnerId = new Guid("7acdde20-2a8c-4b4e-b535-20d933a50308"),
                            Type = 1
                        },
                        new
                        {
                            Id = new Guid("8eab6378-7189-4359-bbd1-8759c8570706"),
                            Description = "Income account for our users",
                            OwnerId = new Guid("7acdde20-2a8c-4b4e-b535-20d933a50308"),
                            Type = 3
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.DataModels.Owner", b =>
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
                            Id = new Guid("bd692961-78d8-488e-bdec-3663d6401b61"),
                            Address = "John Doe's address",
                            Name = "John Doe"
                        },
                        new
                        {
                            Id = new Guid("7acdde20-2a8c-4b4e-b535-20d933a50308"),
                            Address = "Jane Doe's address",
                            Name = "Jane Doe"
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.DataModels.Role", b =>
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
                            Id = new Guid("7f027bad-48c1-448b-879f-d01aa1d0b7e2"),
                            Code = "admin",
                            Name = "Admin"
                        },
                        new
                        {
                            Id = new Guid("4cee5850-6572-4bcc-a7d3-cee687ddcfd9"),
                            Code = "user",
                            Name = "User"
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.DataModels.User", b =>
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
                            Id = new Guid("4954d130-1b75-4ee7-a234-02d95f696d38"),
                            Email = "admin@mail.com",
                            Name = "Admin",
                            Password = "123",
                            RoleId = new Guid("7f027bad-48c1-448b-879f-d01aa1d0b7e2"),
                            Status = 1
                        });
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.DataModels.Account", b =>
                {
                    b.HasOne("GraphQLDotNet.Core.Source.DataModels.Owner", "Owner")
                        .WithMany("Accounts")
                        .HasForeignKey("OwnerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Owner");
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.DataModels.User", b =>
                {
                    b.HasOne("GraphQLDotNet.Core.Source.DataModels.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.DataModels.Owner", b =>
                {
                    b.Navigation("Accounts");
                });

            modelBuilder.Entity("GraphQLDotNet.Core.Source.DataModels.Role", b =>
                {
                    b.Navigation("Users");
                });
#pragma warning restore 612, 618
        }
    }
}
