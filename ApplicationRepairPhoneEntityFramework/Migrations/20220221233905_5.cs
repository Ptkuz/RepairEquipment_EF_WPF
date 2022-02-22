using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationRepairPhoneEntityFramework.Migrations
{
    public partial class _5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<int>(
                name: "NeededQuantity",
                table: "stockDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "order_Statuses",
                columns: new[] { "ID_Status", "Name_Status" },
                values: new object[,]
                {
                    { new Guid("3feb6e7e-c114-49c4-b8c6-d3b4108ea586"), "Заказ зарегестрирован" },
                    { new Guid("93775238-3861-41a9-9352-7fdfecc133b0"), "Заказ выполняется" },
                    { new Guid("99ce6c12-98b4-4897-a928-bcc7403f042b"), "Заказ выполнен" }
                });

            migrationBuilder.InsertData(
                table: "positions",
                columns: new[] { "ID_Position", "Name_Position" },
                values: new object[,]
                {
                    { new Guid("5dd9ed53-e9e4-4fa0-9156-88b42a0c15e8"), "Стажер" },
                    { new Guid("d79698ce-6710-4bec-ba36-71bd15403470"), "Старший мастер" },
                    { new Guid("e713a1ef-27de-4e16-bdbd-288ddee95180"), "Мастер" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: new Guid("3feb6e7e-c114-49c4-b8c6-d3b4108ea586"));

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: new Guid("93775238-3861-41a9-9352-7fdfecc133b0"));

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: new Guid("99ce6c12-98b4-4897-a928-bcc7403f042b"));

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: new Guid("5dd9ed53-e9e4-4fa0-9156-88b42a0c15e8"));

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: new Guid("d79698ce-6710-4bec-ba36-71bd15403470"));

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: new Guid("e713a1ef-27de-4e16-bdbd-288ddee95180"));

            migrationBuilder.AlterColumn<int>(
                name: "NeededQuantity",
                table: "stockDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

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
    }
}
