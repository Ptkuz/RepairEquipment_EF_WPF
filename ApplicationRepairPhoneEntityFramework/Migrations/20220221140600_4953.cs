using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationRepairPhoneEntityFramework.Migrations
{
    public partial class _4953 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ID_Client = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ID_Client);
                });

            migrationBuilder.CreateTable(
                name: "Device",
                columns: table => new
                {
                    ID_Device = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Serial_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Manufacturer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Device", x => x.ID_Device);
                });

            migrationBuilder.CreateTable(
                name: "Order_Status",
                columns: table => new
                {
                    ID_Status = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order_Status", x => x.ID_Status);
                });

            migrationBuilder.CreateTable(
                name: "Performance",
                columns: table => new
                {
                    ID_Performance = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Description_Repair = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Work_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Detail_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Discount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Final_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Date_Performance = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Performance", x => x.ID_Performance);
                });

            migrationBuilder.CreateTable(
                name: "Position",
                columns: table => new
                {
                    ID_Position = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Position = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Position", x => x.ID_Position);
                });

            migrationBuilder.CreateTable(
                name: "StockDetails",
                columns: table => new
                {
                    ID_Detail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name_Detail = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Unit_Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QuantityStock = table.Column<int>(type: "int", nullable: false),
                    FullPrice = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StockDetails", x => x.ID_Detail);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    ID_Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FIO = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ID_Position = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PositionID_Position = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Series_Number_Password = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Phone_Number = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    EmploymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Experience = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.ID_Employee);
                    table.ForeignKey(
                        name: "FK_Employee_Position_PositionID_Position",
                        column: x => x.PositionID_Position,
                        principalTable: "Position",
                        principalColumn: "ID_Position");
                });

            migrationBuilder.CreateTable(
                name: "Relationship",
                columns: table => new
                {
                    ID_Performance = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Detail = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerformanceID_Performance = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    StockDetailsID_Detail = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Relationship", x => new { x.ID_Performance, x.ID_Detail });
                    table.ForeignKey(
                        name: "FK_Relationship_Performance_PerformanceID_Performance",
                        column: x => x.PerformanceID_Performance,
                        principalTable: "Performance",
                        principalColumn: "ID_Performance");
                    table.ForeignKey(
                        name: "FK_Relationship_StockDetails_StockDetailsID_Detail",
                        column: x => x.StockDetailsID_Detail,
                        principalTable: "StockDetails",
                        principalColumn: "ID_Detail");
                });

            migrationBuilder.CreateTable(
                name: "Order",
                columns: table => new
                {
                    ID_Order = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ID_Device = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DeviceID_Device = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ID_Client = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ClientID_Client = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ID_Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    EmployeeID_Employee = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ID_Status = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Order_StatusID_Status = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    ID_Performance = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PerformanceID_Performance = table.Column<Guid>(type: "uniqueidentifier", nullable: true),
                    Date_Order = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Order", x => x.ID_Order);
                    table.ForeignKey(
                        name: "FK_Order_Clients_ClientID_Client",
                        column: x => x.ClientID_Client,
                        principalTable: "Clients",
                        principalColumn: "ID_Client");
                    table.ForeignKey(
                        name: "FK_Order_Device_DeviceID_Device",
                        column: x => x.DeviceID_Device,
                        principalTable: "Device",
                        principalColumn: "ID_Device");
                    table.ForeignKey(
                        name: "FK_Order_Employee_EmployeeID_Employee",
                        column: x => x.EmployeeID_Employee,
                        principalTable: "Employee",
                        principalColumn: "ID_Employee");
                    table.ForeignKey(
                        name: "FK_Order_Order_Status_Order_StatusID_Status",
                        column: x => x.Order_StatusID_Status,
                        principalTable: "Order_Status",
                        principalColumn: "ID_Status");
                    table.ForeignKey(
                        name: "FK_Order_Performance_PerformanceID_Performance",
                        column: x => x.PerformanceID_Performance,
                        principalTable: "Performance",
                        principalColumn: "ID_Performance");
                });

            migrationBuilder.InsertData(
                table: "Order_Status",
                columns: new[] { "ID_Status", "Name_Status" },
                values: new object[,]
                {
                    { new Guid("664e2a66-3254-4083-99b5-64a29d9ba66c"), "Заказ выполняется" },
                    { new Guid("c05a471d-f0f3-4e86-8104-301cc5e9e0e8"), "Заказ зарегестрирован" },
                    { new Guid("e34fd88f-ed68-4849-9a88-53a3f7eefa2e"), "Заказ выполнен" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "ID_Position", "Name_Position" },
                values: new object[,]
                {
                    { new Guid("18063fcb-d735-4249-8afc-f730b5f91c42"), "Старший мастер" },
                    { new Guid("7227285e-562a-48e6-a6ca-f7a5e19a7cae"), "Стажер" },
                    { new Guid("f384b41f-b0f2-43b3-a90c-48d4493fdc66"), "Мастер" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_PositionID_Position",
                table: "Employee",
                column: "PositionID_Position");

            migrationBuilder.CreateIndex(
                name: "IX_Order_ClientID_Client",
                table: "Order",
                column: "ClientID_Client");

            migrationBuilder.CreateIndex(
                name: "IX_Order_DeviceID_Device",
                table: "Order",
                column: "DeviceID_Device");

            migrationBuilder.CreateIndex(
                name: "IX_Order_EmployeeID_Employee",
                table: "Order",
                column: "EmployeeID_Employee");

            migrationBuilder.CreateIndex(
                name: "IX_Order_Order_StatusID_Status",
                table: "Order",
                column: "Order_StatusID_Status");

            migrationBuilder.CreateIndex(
                name: "IX_Order_PerformanceID_Performance",
                table: "Order",
                column: "PerformanceID_Performance");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_PerformanceID_Performance",
                table: "Relationship",
                column: "PerformanceID_Performance");

            migrationBuilder.CreateIndex(
                name: "IX_Relationship_StockDetailsID_Detail",
                table: "Relationship",
                column: "StockDetailsID_Detail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Order");

            migrationBuilder.DropTable(
                name: "Relationship");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Device");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Order_Status");

            migrationBuilder.DropTable(
                name: "Performance");

            migrationBuilder.DropTable(
                name: "StockDetails");

            migrationBuilder.DropTable(
                name: "Position");
        }
    }
}
