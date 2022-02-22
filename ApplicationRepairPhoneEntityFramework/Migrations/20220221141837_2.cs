using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationRepairPhoneEntityFramework.Migrations
{
    public partial class _2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employee_Position_PositionID_Position",
                table: "Employee");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Clients_ClientID_Client",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Device_DeviceID_Device",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Employee_EmployeeID_Employee",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Order_Status_Order_StatusID_Status",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Order_Performance_PerformanceID_Performance",
                table: "Order");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationship_Performance_PerformanceID_Performance",
                table: "Relationship");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationship_StockDetails_StockDetailsID_Detail",
                table: "Relationship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_StockDetails",
                table: "StockDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relationship",
                table: "Relationship");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Position",
                table: "Position");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Performance",
                table: "Performance");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order_Status",
                table: "Order_Status");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Order",
                table: "Order");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employee",
                table: "Employee");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Device",
                table: "Device");

            migrationBuilder.DeleteData(
                table: "Order_Status",
                keyColumn: "ID_Status",
                keyValue: new Guid("1336743d-ffba-4aec-917d-f65f70fec453"));

            migrationBuilder.DeleteData(
                table: "Order_Status",
                keyColumn: "ID_Status",
                keyValue: new Guid("2758cf7a-328c-4c1a-b619-6c903e922c2c"));

            migrationBuilder.DeleteData(
                table: "Order_Status",
                keyColumn: "ID_Status",
                keyValue: new Guid("8d26beaf-9dfc-4f65-a2dc-475026bb8be7"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "ID_Position",
                keyValue: new Guid("b9590592-3a31-4120-ba3d-3a46baae9443"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "ID_Position",
                keyValue: new Guid("d4e1c4b8-1aa1-4602-b90a-d5af7d4ca46c"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "ID_Position",
                keyValue: new Guid("d5c15ae5-9221-4f31-8935-8951e416e58c"));

            migrationBuilder.RenameTable(
                name: "StockDetails",
                newName: "stockDetails");

            migrationBuilder.RenameTable(
                name: "Relationship",
                newName: "Relationships");

            migrationBuilder.RenameTable(
                name: "Position",
                newName: "positions");

            migrationBuilder.RenameTable(
                name: "Performance",
                newName: "performances");

            migrationBuilder.RenameTable(
                name: "Order_Status",
                newName: "order_Statuses");

            migrationBuilder.RenameTable(
                name: "Order",
                newName: "Orders");

            migrationBuilder.RenameTable(
                name: "Employee",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Device",
                newName: "Devices");

            migrationBuilder.RenameIndex(
                name: "IX_Relationship_StockDetailsID_Detail",
                table: "Relationships",
                newName: "IX_Relationships_StockDetailsID_Detail");

            migrationBuilder.RenameIndex(
                name: "IX_Relationship_PerformanceID_Performance",
                table: "Relationships",
                newName: "IX_Relationships_PerformanceID_Performance");

            migrationBuilder.RenameIndex(
                name: "IX_Order_PerformanceID_Performance",
                table: "Orders",
                newName: "IX_Orders_PerformanceID_Performance");

            migrationBuilder.RenameIndex(
                name: "IX_Order_Order_StatusID_Status",
                table: "Orders",
                newName: "IX_Orders_Order_StatusID_Status");

            migrationBuilder.RenameIndex(
                name: "IX_Order_EmployeeID_Employee",
                table: "Orders",
                newName: "IX_Orders_EmployeeID_Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Order_DeviceID_Device",
                table: "Orders",
                newName: "IX_Orders_DeviceID_Device");

            migrationBuilder.RenameIndex(
                name: "IX_Order_ClientID_Client",
                table: "Orders",
                newName: "IX_Orders_ClientID_Client");

            migrationBuilder.RenameIndex(
                name: "IX_Employee_PositionID_Position",
                table: "Employees",
                newName: "IX_Employees_PositionID_Position");

            migrationBuilder.AddPrimaryKey(
                name: "PK_stockDetails",
                table: "stockDetails",
                column: "ID_Detail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relationships",
                table: "Relationships",
                columns: new[] { "ID_Performance", "ID_Detail" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_positions",
                table: "positions",
                column: "ID_Position");

            migrationBuilder.AddPrimaryKey(
                name: "PK_performances",
                table: "performances",
                column: "ID_Performance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_order_Statuses",
                table: "order_Statuses",
                column: "ID_Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "ID_Order");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "ID_Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Devices",
                table: "Devices",
                column: "ID_Device");

            migrationBuilder.InsertData(
                table: "order_Statuses",
                columns: new[] { "ID_Status", "Name_Status" },
                values: new object[,]
                {
                    { new Guid("3307ac4c-dbb2-440c-8f9c-d54c8000d64c"), "Заказ зарегестрирован" },
                    { new Guid("9e2b3499-37f6-4612-8a3b-120f01610f65"), "Заказ выполнен" },
                    { new Guid("e9ebf366-3193-4468-aa32-0e07ada74eb2"), "Заказ выполняется" }
                });

            migrationBuilder.InsertData(
                table: "positions",
                columns: new[] { "ID_Position", "Name_Position" },
                values: new object[,]
                {
                    { new Guid("0e8bdf42-4fdc-4c50-8453-65cc737e501c"), "Старший мастер" },
                    { new Guid("409fd5d8-3ad7-45ff-9d39-d127b5dc2419"), "Мастер" },
                    { new Guid("d2d952a3-c2d1-40c7-a7dc-d9a56d7a48ef"), "Стажер" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_positions_PositionID_Position",
                table: "Employees",
                column: "PositionID_Position",
                principalTable: "positions",
                principalColumn: "ID_Position");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Clients_ClientID_Client",
                table: "Orders",
                column: "ClientID_Client",
                principalTable: "Clients",
                principalColumn: "ID_Client");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Devices_DeviceID_Device",
                table: "Orders",
                column: "DeviceID_Device",
                principalTable: "Devices",
                principalColumn: "ID_Device");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Employees_EmployeeID_Employee",
                table: "Orders",
                column: "EmployeeID_Employee",
                principalTable: "Employees",
                principalColumn: "ID_Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_order_Statuses_Order_StatusID_Status",
                table: "Orders",
                column: "Order_StatusID_Status",
                principalTable: "order_Statuses",
                principalColumn: "ID_Status");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_performances_PerformanceID_Performance",
                table: "Orders",
                column: "PerformanceID_Performance",
                principalTable: "performances",
                principalColumn: "ID_Performance");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_performances_PerformanceID_Performance",
                table: "Relationships",
                column: "PerformanceID_Performance",
                principalTable: "performances",
                principalColumn: "ID_Performance");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationships_stockDetails_StockDetailsID_Detail",
                table: "Relationships",
                column: "StockDetailsID_Detail",
                principalTable: "stockDetails",
                principalColumn: "ID_Detail");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_positions_PositionID_Position",
                table: "Employees");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Clients_ClientID_Client",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Devices_DeviceID_Device",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Employees_EmployeeID_Employee",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_order_Statuses_Order_StatusID_Status",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_performances_PerformanceID_Performance",
                table: "Orders");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_performances_PerformanceID_Performance",
                table: "Relationships");

            migrationBuilder.DropForeignKey(
                name: "FK_Relationships_stockDetails_StockDetailsID_Detail",
                table: "Relationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_stockDetails",
                table: "stockDetails");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Relationships",
                table: "Relationships");

            migrationBuilder.DropPrimaryKey(
                name: "PK_positions",
                table: "positions");

            migrationBuilder.DropPrimaryKey(
                name: "PK_performances",
                table: "performances");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_order_Statuses",
                table: "order_Statuses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Devices",
                table: "Devices");

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: new Guid("3307ac4c-dbb2-440c-8f9c-d54c8000d64c"));

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: new Guid("9e2b3499-37f6-4612-8a3b-120f01610f65"));

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: new Guid("e9ebf366-3193-4468-aa32-0e07ada74eb2"));

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: new Guid("0e8bdf42-4fdc-4c50-8453-65cc737e501c"));

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: new Guid("409fd5d8-3ad7-45ff-9d39-d127b5dc2419"));

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: new Guid("d2d952a3-c2d1-40c7-a7dc-d9a56d7a48ef"));

            migrationBuilder.RenameTable(
                name: "stockDetails",
                newName: "StockDetails");

            migrationBuilder.RenameTable(
                name: "Relationships",
                newName: "Relationship");

            migrationBuilder.RenameTable(
                name: "positions",
                newName: "Position");

            migrationBuilder.RenameTable(
                name: "performances",
                newName: "Performance");

            migrationBuilder.RenameTable(
                name: "Orders",
                newName: "Order");

            migrationBuilder.RenameTable(
                name: "order_Statuses",
                newName: "Order_Status");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Employee");

            migrationBuilder.RenameTable(
                name: "Devices",
                newName: "Device");

            migrationBuilder.RenameIndex(
                name: "IX_Relationships_StockDetailsID_Detail",
                table: "Relationship",
                newName: "IX_Relationship_StockDetailsID_Detail");

            migrationBuilder.RenameIndex(
                name: "IX_Relationships_PerformanceID_Performance",
                table: "Relationship",
                newName: "IX_Relationship_PerformanceID_Performance");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_PerformanceID_Performance",
                table: "Order",
                newName: "IX_Order_PerformanceID_Performance");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_Order_StatusID_Status",
                table: "Order",
                newName: "IX_Order_Order_StatusID_Status");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_EmployeeID_Employee",
                table: "Order",
                newName: "IX_Order_EmployeeID_Employee");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_DeviceID_Device",
                table: "Order",
                newName: "IX_Order_DeviceID_Device");

            migrationBuilder.RenameIndex(
                name: "IX_Orders_ClientID_Client",
                table: "Order",
                newName: "IX_Order_ClientID_Client");

            migrationBuilder.RenameIndex(
                name: "IX_Employees_PositionID_Position",
                table: "Employee",
                newName: "IX_Employee_PositionID_Position");

            migrationBuilder.AddPrimaryKey(
                name: "PK_StockDetails",
                table: "StockDetails",
                column: "ID_Detail");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Relationship",
                table: "Relationship",
                columns: new[] { "ID_Performance", "ID_Detail" });

            migrationBuilder.AddPrimaryKey(
                name: "PK_Position",
                table: "Position",
                column: "ID_Position");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Performance",
                table: "Performance",
                column: "ID_Performance");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order",
                table: "Order",
                column: "ID_Order");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Order_Status",
                table: "Order_Status",
                column: "ID_Status");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employee",
                table: "Employee",
                column: "ID_Employee");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Device",
                table: "Device",
                column: "ID_Device");

            migrationBuilder.InsertData(
                table: "Order_Status",
                columns: new[] { "ID_Status", "Name_Status" },
                values: new object[,]
                {
                    { new Guid("1336743d-ffba-4aec-917d-f65f70fec453"), "Заказ зарегестрирован" },
                    { new Guid("2758cf7a-328c-4c1a-b619-6c903e922c2c"), "Заказ выполнен" },
                    { new Guid("8d26beaf-9dfc-4f65-a2dc-475026bb8be7"), "Заказ выполняется" }
                });

            migrationBuilder.InsertData(
                table: "Position",
                columns: new[] { "ID_Position", "Name_Position" },
                values: new object[,]
                {
                    { new Guid("b9590592-3a31-4120-ba3d-3a46baae9443"), "Мастер" },
                    { new Guid("d4e1c4b8-1aa1-4602-b90a-d5af7d4ca46c"), "Старший мастер" },
                    { new Guid("d5c15ae5-9221-4f31-8935-8951e416e58c"), "Стажер" }
                });

            migrationBuilder.AddForeignKey(
                name: "FK_Employee_Position_PositionID_Position",
                table: "Employee",
                column: "PositionID_Position",
                principalTable: "Position",
                principalColumn: "ID_Position");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Clients_ClientID_Client",
                table: "Order",
                column: "ClientID_Client",
                principalTable: "Clients",
                principalColumn: "ID_Client");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Device_DeviceID_Device",
                table: "Order",
                column: "DeviceID_Device",
                principalTable: "Device",
                principalColumn: "ID_Device");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Employee_EmployeeID_Employee",
                table: "Order",
                column: "EmployeeID_Employee",
                principalTable: "Employee",
                principalColumn: "ID_Employee");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Order_Status_Order_StatusID_Status",
                table: "Order",
                column: "Order_StatusID_Status",
                principalTable: "Order_Status",
                principalColumn: "ID_Status");

            migrationBuilder.AddForeignKey(
                name: "FK_Order_Performance_PerformanceID_Performance",
                table: "Order",
                column: "PerformanceID_Performance",
                principalTable: "Performance",
                principalColumn: "ID_Performance");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationship_Performance_PerformanceID_Performance",
                table: "Relationship",
                column: "PerformanceID_Performance",
                principalTable: "Performance",
                principalColumn: "ID_Performance");

            migrationBuilder.AddForeignKey(
                name: "FK_Relationship_StockDetails_StockDetailsID_Detail",
                table: "Relationship",
                column: "StockDetailsID_Detail",
                principalTable: "StockDetails",
                principalColumn: "ID_Detail");
        }
    }
}
