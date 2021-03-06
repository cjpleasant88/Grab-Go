﻿// <auto-generated />
using GrabAndGo.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace GrabAndGo.Migrations
{
    [DbContext(typeof(GrabAndGoContext))]
    [Migration("20200428060554_initial")]
    partial class initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "3.1.3")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GrabAndGo.Models.Aisle", b =>
                {
                    b.Property<int>("AisleID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("AisleNumber")
                        .HasColumnType("int");

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<int>("StoreID")
                        .HasColumnType("int");

                    b.HasKey("AisleID");

                    b.ToTable("Aisle");

                    b.HasData(
                        new
                        {
                            AisleID = 1,
                            AisleNumber = 1,
                            CategoryID = 1,
                            StoreID = 1
                        },
                        new
                        {
                            AisleID = 2,
                            AisleNumber = 2,
                            CategoryID = 3,
                            StoreID = 1
                        },
                        new
                        {
                            AisleID = 3,
                            AisleNumber = 1,
                            CategoryID = 2,
                            StoreID = 2
                        });
                });

            modelBuilder.Entity("GrabAndGo.Models.Category", b =>
                {
                    b.Property<int>("CategoryID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CategoryName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("CategoryID");

                    b.ToTable("Category");

                    b.HasData(
                        new
                        {
                            CategoryID = 1,
                            CategoryName = "Dairy"
                        },
                        new
                        {
                            CategoryID = 2,
                            CategoryName = "Bakery"
                        });
                });

            modelBuilder.Entity("GrabAndGo.Models.Product", b =>
                {
                    b.Property<int>("ProductID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("CategoryID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ProductID");

                    b.ToTable("Product");

                    b.HasData(
                        new
                        {
                            ProductID = 1,
                            CategoryID = 1,
                            ProductName = "Milk"
                        },
                        new
                        {
                            ProductID = 2,
                            CategoryID = 2,
                            ProductName = "Bread"
                        },
                        new
                        {
                            ProductID = 3,
                            CategoryID = 3,
                            ProductName = "Eggs"
                        });
                });

            modelBuilder.Entity("GrabAndGo.Models.ShoppingListLine", b =>
                {
                    b.Property<int>("ShoppingListLineID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ListID")
                        .HasColumnType("int");

                    b.Property<int>("ProductID")
                        .HasColumnType("int");

                    b.Property<string>("ProductName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Quantity")
                        .HasColumnType("int");

                    b.HasKey("ShoppingListLineID");

                    b.ToTable("ShoppingListLine");

                    b.HasData(
                        new
                        {
                            ShoppingListLineID = 1,
                            ListID = 1,
                            ProductID = 1,
                            ProductName = "Milk",
                            Quantity = 2
                        },
                        new
                        {
                            ShoppingListLineID = 2,
                            ListID = 2,
                            ProductID = 2,
                            ProductName = "Bread",
                            Quantity = 3
                        },
                        new
                        {
                            ShoppingListLineID = 3,
                            ListID = 2,
                            ProductID = 3,
                            ProductName = "Eggs",
                            Quantity = 12
                        });
                });

            modelBuilder.Entity("GrabAndGo.Models.Store", b =>
                {
                    b.Property<int>("StoreID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("City")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("State")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("StoreName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Street")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ZipCode")
                        .HasColumnType("int");

                    b.HasKey("StoreID");

                    b.ToTable("Store");

                    b.HasData(
                        new
                        {
                            StoreID = 1,
                            City = "Ocenaside",
                            State = "CA",
                            StoreName = "Target",
                            Street = "123 BeachTime",
                            ZipCode = 12345
                        },
                        new
                        {
                            StoreID = 2,
                            City = "Vista",
                            State = "CA",
                            StoreName = "Ralphs",
                            Street = "456 ImHungry",
                            ZipCode = 98765
                        });
                });

            modelBuilder.Entity("GrabAndGo.Models.User", b =>
                {
                    b.Property<int>("UserID")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ListID")
                        .HasColumnType("int");

                    b.Property<string>("ListName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("StorePref")
                        .HasColumnType("int");

                    b.HasKey("UserID");

                    b.ToTable("User");

                    b.HasData(
                        new
                        {
                            UserID = 1,
                            Email = "test123@456.com",
                            FirstName = "Test User",
                            LastName = "Test Last",
                            ListID = 123,
                            ListName = "Test List",
                            Password = "superSecret",
                            StorePref = 1
                        },
                        new
                        {
                            UserID = 2,
                            Email = "john@grabandgo.com",
                            FirstName = "John",
                            LastName = "Smith",
                            ListID = 3,
                            ListName = "John's List",
                            Password = "johnnyrocks",
                            StorePref = 2
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
