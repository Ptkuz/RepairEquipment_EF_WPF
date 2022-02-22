﻿// <auto-generated />
using System;
using ApplicationRepairPhoneEntityFramework;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace ApplicationRepairPhoneEntityFramework.Migrations
{
    [DbContext(typeof(ApplicationContext))]
    [Migration("20220221141837_2")]
    partial class _2
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RepaifPhoneDB.Client", b =>
                {
                    b.Property<Guid>("ID_Client")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("FIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Client");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RepaifPhoneDB.Device", b =>
                {
                    b.Property<Guid>("ID_Device")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Description")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Manufacturer")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Model")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Serial_Number")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Device");

                    b.ToTable("Devices");
                });

            modelBuilder.Entity("RepaifPhoneDB.Employee", b =>
                {
                    b.Property<Guid>("ID_Employee")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Address")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("EmploymentDate")
                        .HasColumnType("datetime2");

                    b.Property<int>("Experience")
                        .HasColumnType("int");

                    b.Property<string>("FIO")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid>("ID_Position")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Phone_Number")
                        .HasColumnType("nvarchar(max)");

                    b.Property<Guid?>("PositionID_Position")
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Series_Number_Password")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Employee");

                    b.HasIndex("PositionID_Position");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RepaifPhoneDB.Order", b =>
                {
                    b.Property<Guid>("ID_Order")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("ClientID_Client")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("Date_Order")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("DeviceID_Device")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("EmployeeID_Employee")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_Client")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_Device")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_Employee")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_Performance")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_Status")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("Order_StatusID_Status")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PerformanceID_Performance")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID_Order");

                    b.HasIndex("ClientID_Client");

                    b.HasIndex("DeviceID_Device");

                    b.HasIndex("EmployeeID_Employee");

                    b.HasIndex("Order_StatusID_Status");

                    b.HasIndex("PerformanceID_Performance");

                    b.ToTable("Orders");
                });

            modelBuilder.Entity("RepaifPhoneDB.Order_Status", b =>
                {
                    b.Property<Guid>("ID_Status")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name_Status")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Status");

                    b.ToTable("order_Statuses");

                    b.HasData(
                        new
                        {
                            ID_Status = new Guid("3307ac4c-dbb2-440c-8f9c-d54c8000d64c"),
                            Name_Status = "Заказ зарегестрирован"
                        },
                        new
                        {
                            ID_Status = new Guid("e9ebf366-3193-4468-aa32-0e07ada74eb2"),
                            Name_Status = "Заказ выполняется"
                        },
                        new
                        {
                            ID_Status = new Guid("9e2b3499-37f6-4612-8a3b-120f01610f65"),
                            Name_Status = "Заказ выполнен"
                        });
                });

            modelBuilder.Entity("RepaifPhoneDB.Performance", b =>
                {
                    b.Property<Guid>("ID_Performance")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime?>("Date_Performance")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description_Repair")
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Detail_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Discount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Final_Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<decimal>("Work_Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_Performance");

                    b.ToTable("performances");
                });

            modelBuilder.Entity("RepaifPhoneDB.Position", b =>
                {
                    b.Property<Guid>("ID_Position")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<string>("Name_Position")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ID_Position");

                    b.ToTable("positions");

                    b.HasData(
                        new
                        {
                            ID_Position = new Guid("d2d952a3-c2d1-40c7-a7dc-d9a56d7a48ef"),
                            Name_Position = "Стажер"
                        },
                        new
                        {
                            ID_Position = new Guid("409fd5d8-3ad7-45ff-9d39-d127b5dc2419"),
                            Name_Position = "Мастер"
                        },
                        new
                        {
                            ID_Position = new Guid("0e8bdf42-4fdc-4c50-8453-65cc737e501c"),
                            Name_Position = "Старший мастер"
                        });
                });

            modelBuilder.Entity("RepaifPhoneDB.Relationship", b =>
                {
                    b.Property<Guid>("ID_Performance")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid>("ID_Detail")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("PerformanceID_Performance")
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("StockDetailsID_Detail")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("ID_Performance", "ID_Detail");

                    b.HasIndex("PerformanceID_Performance");

                    b.HasIndex("StockDetailsID_Detail");

                    b.ToTable("Relationships");
                });

            modelBuilder.Entity("RepaifPhoneDB.StockDetails", b =>
                {
                    b.Property<Guid>("ID_Detail")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<decimal>("FullPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<string>("Name_Detail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("QuantityStock")
                        .HasColumnType("int");

                    b.Property<decimal>("Unit_Price")
                        .HasColumnType("decimal(18,2)");

                    b.HasKey("ID_Detail");

                    b.ToTable("stockDetails");
                });

            modelBuilder.Entity("RepaifPhoneDB.Employee", b =>
                {
                    b.HasOne("RepaifPhoneDB.Position", "Position")
                        .WithMany("Employees")
                        .HasForeignKey("PositionID_Position");

                    b.Navigation("Position");
                });

            modelBuilder.Entity("RepaifPhoneDB.Order", b =>
                {
                    b.HasOne("RepaifPhoneDB.Client", "Client")
                        .WithMany("Orders")
                        .HasForeignKey("ClientID_Client");

                    b.HasOne("RepaifPhoneDB.Device", "Device")
                        .WithMany("Orders")
                        .HasForeignKey("DeviceID_Device");

                    b.HasOne("RepaifPhoneDB.Employee", "Employee")
                        .WithMany("Orders")
                        .HasForeignKey("EmployeeID_Employee");

                    b.HasOne("RepaifPhoneDB.Order_Status", "Order_Status")
                        .WithMany("Orders")
                        .HasForeignKey("Order_StatusID_Status");

                    b.HasOne("RepaifPhoneDB.Performance", "Performance")
                        .WithMany("Orders")
                        .HasForeignKey("PerformanceID_Performance");

                    b.Navigation("Client");

                    b.Navigation("Device");

                    b.Navigation("Employee");

                    b.Navigation("Order_Status");

                    b.Navigation("Performance");
                });

            modelBuilder.Entity("RepaifPhoneDB.Relationship", b =>
                {
                    b.HasOne("RepaifPhoneDB.Performance", "Performance")
                        .WithMany()
                        .HasForeignKey("PerformanceID_Performance");

                    b.HasOne("RepaifPhoneDB.StockDetails", "StockDetails")
                        .WithMany()
                        .HasForeignKey("StockDetailsID_Detail");

                    b.Navigation("Performance");

                    b.Navigation("StockDetails");
                });

            modelBuilder.Entity("RepaifPhoneDB.Client", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RepaifPhoneDB.Device", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RepaifPhoneDB.Employee", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RepaifPhoneDB.Order_Status", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RepaifPhoneDB.Performance", b =>
                {
                    b.Navigation("Orders");
                });

            modelBuilder.Entity("RepaifPhoneDB.Position", b =>
                {
                    b.Navigation("Employees");
                });
#pragma warning restore 612, 618
        }
    }
}
