﻿// <auto-generated />
using System;
using InternetMagazin.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace InternetMagazin.Migrations
{
    [DbContext(typeof(AppDbContent))]
    [Migration("20220710192341_Orders")]
    partial class Orders
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("InternetMagazin.Data.Models.Car", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<bool>("Available");

                    b.Property<string>("Img");

                    b.Property<bool>("IsFavourite");

                    b.Property<string>("LongDesc");

                    b.Property<string>("Name");

                    b.Property<int>("Price");

                    b.Property<string>("ShortDesc");

                    b.Property<int>("categoryId");

                    b.HasKey("Id");

                    b.HasIndex("categoryId");

                    b.ToTable("Car");
                });

            modelBuilder.Entity("InternetMagazin.Data.Models.Category", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("categoryName");

                    b.Property<string>("desc");

                    b.HasKey("Id");

                    b.ToTable("Category");
                });

            modelBuilder.Entity("InternetMagazin.Data.Models.Order", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Adress");

                    b.Property<string>("Email");

                    b.Property<string>("Name");

                    b.Property<DateTime>("OrderTime");

                    b.Property<string>("Phone");

                    b.Property<string>("Surname");

                    b.HasKey("Id");

                    b.ToTable("Order");
                });

            modelBuilder.Entity("InternetMagazin.Data.Models.OrderDetail", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("CarId");

                    b.Property<int?>("CarId1");

                    b.Property<string>("OrderId");

                    b.Property<int?>("OrderId1");

                    b.Property<long>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CarId1");

                    b.HasIndex("OrderId1");

                    b.ToTable("OrderDetail");
                });

            modelBuilder.Entity("InternetMagazin.Data.Models.ShopCartItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("CarId");

                    b.Property<int>("Price");

                    b.HasKey("Id");

                    b.HasIndex("CarId");

                    b.ToTable("ShopCartItem");
                });

            modelBuilder.Entity("InternetMagazin.Data.Models.Car", b =>
                {
                    b.HasOne("InternetMagazin.Data.Models.Category", "Category")
                        .WithMany("cars")
                        .HasForeignKey("categoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("InternetMagazin.Data.Models.OrderDetail", b =>
                {
                    b.HasOne("InternetMagazin.Data.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId1");

                    b.HasOne("InternetMagazin.Data.Models.Order", "Order")
                        .WithMany("OrderDetails")
                        .HasForeignKey("OrderId1");
                });

            modelBuilder.Entity("InternetMagazin.Data.Models.ShopCartItem", b =>
                {
                    b.HasOne("InternetMagazin.Data.Models.Car", "Car")
                        .WithMany()
                        .HasForeignKey("CarId");
                });
#pragma warning restore 612, 618
        }
    }
}
