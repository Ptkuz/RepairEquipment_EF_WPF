using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationRepairPhoneEntityFramework.Migrations
{
    public partial class _3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<int>(
                name: "NeededQuantity",
                table: "stockDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "order_Statuses",
                columns: new[] { "ID_Status", "Name_Status" },
                values: new object[,]
                {
                    { new Guid("0a985c18-6c51-4dbe-9826-cf12bb878834"), "Заказ зарегестрирован" },
                    { new Guid("1204e2f6-206e-4956-9512-2ccc929717e7"), "Заказ выполнен" },
                    { new Guid("a6e208bc-346c-443a-b018-aadda577ad7d"), "Заказ выполняется" }
                });

            migrationBuilder.InsertData(
                table: "positions",
                columns: new[] { "ID_Position", "Name_Position" },
                values: new object[,]
                {
                    { new Guid("188d6305-f8d4-439f-b1f4-ead1d3787dcb"), "Старший мастер" },
                    { new Guid("30568c82-65db-4e79-9c70-11b6d3eeac61"), "Мастер" },
                    { new Guid("7608c7e9-e4c5-4c8f-a0df-78f4e7b9426c"), "Стажер" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: new Guid("0a985c18-6c51-4dbe-9826-cf12bb878834"));

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: new Guid("1204e2f6-206e-4956-9512-2ccc929717e7"));

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: new Guid("a6e208bc-346c-443a-b018-aadda577ad7d"));

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: new Guid("188d6305-f8d4-439f-b1f4-ead1d3787dcb"));

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: new Guid("30568c82-65db-4e79-9c70-11b6d3eeac61"));

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: new Guid("7608c7e9-e4c5-4c8f-a0df-78f4e7b9426c"));

            migrationBuilder.DropColumn(
                name: "NeededQuantity",
                table: "stockDetails");

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
        }
    }
}
