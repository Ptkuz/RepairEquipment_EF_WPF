using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationRepairPhoneEntityFramework.Migrations
{
    public partial class _1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Order_Status",
                keyColumn: "ID_Status",
                keyValue: new Guid("664e2a66-3254-4083-99b5-64a29d9ba66c"));

            migrationBuilder.DeleteData(
                table: "Order_Status",
                keyColumn: "ID_Status",
                keyValue: new Guid("c05a471d-f0f3-4e86-8104-301cc5e9e0e8"));

            migrationBuilder.DeleteData(
                table: "Order_Status",
                keyColumn: "ID_Status",
                keyValue: new Guid("e34fd88f-ed68-4849-9a88-53a3f7eefa2e"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "ID_Position",
                keyValue: new Guid("18063fcb-d735-4249-8afc-f730b5f91c42"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "ID_Position",
                keyValue: new Guid("7227285e-562a-48e6-a6ca-f7a5e19a7cae"));

            migrationBuilder.DeleteData(
                table: "Position",
                keyColumn: "ID_Position",
                keyValue: new Guid("f384b41f-b0f2-43b3-a90c-48d4493fdc66"));

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
