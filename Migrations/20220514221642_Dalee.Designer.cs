﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using UcsCrudV1.Data;

namespace UcsCrudV1.Migrations
{
    [DbContext(typeof(Context))]
    [Migration("20220514221642_Dalee")]
    partial class Dalee
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.13")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("UcsCrudV1.Models.CustomerModel", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Cod");

                    b.ToTable("tab_customer");
                });

            modelBuilder.Entity("UcsCrudV1.Models.EmployerModel", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FirstName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("LastName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Salary")
                        .HasColumnType("int");

                    b.HasKey("Cod");

                    b.ToTable("tab_employer");
                });

            modelBuilder.Entity("UcsCrudV1.Models.OrderModel", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreationDate")
                        .HasColumnType("datetime2");

                    b.Property<decimal>("ProductsQuantity")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint");

                    b.Property<decimal>("TotalValue")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Cod");

                    b.ToTable("tab_order");
                });

            modelBuilder.Entity("UcsCrudV1.Models.OrderProductModel", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("OrderCod")
                        .HasColumnType("int");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("ProductCod")
                        .HasColumnType("int");

                    b.Property<decimal>("Quantity")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Cod");

                    b.HasIndex("OrderCod");

                    b.HasIndex("ProductCod");

                    b.ToTable("tab_orders_itens");
                });

            modelBuilder.Entity("UcsCrudV1.Models.ProductModel", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("Cod");

                    b.ToTable("tab_products");
                });

            modelBuilder.Entity("UcsCrudV1.Models.UserModel", b =>
                {
                    b.Property<int>("Cod")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FullName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mobile")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProfilePicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PublicIdPicture")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte?>("isLogged")
                        .HasColumnType("tinyint");

                    b.HasKey("Cod");

                    b.ToTable("tab_user");
                });

            modelBuilder.Entity("UcsCrudV1.Models.OrderProductModel", b =>
                {
                    b.HasOne("UcsCrudV1.Models.OrderModel", "Order")
                        .WithMany("OrderProductModel")
                        .HasForeignKey("OrderCod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("UcsCrudV1.Models.ProductModel", "Product")
                        .WithMany("OrderProductModel")
                        .HasForeignKey("ProductCod")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Order");

                    b.Navigation("Product");
                });

            modelBuilder.Entity("UcsCrudV1.Models.OrderModel", b =>
                {
                    b.Navigation("OrderProductModel");
                });

            modelBuilder.Entity("UcsCrudV1.Models.ProductModel", b =>
                {
                    b.Navigation("OrderProductModel");
                });
#pragma warning restore 612, 618
        }
    }
}