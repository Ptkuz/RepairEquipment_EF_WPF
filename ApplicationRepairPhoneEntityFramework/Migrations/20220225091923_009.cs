using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ApplicationRepairPhoneEntityFramework.Migrations
{
    public partial class _009 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Orders_performances_PerformanceID_Performance",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_PerformanceID_Performance",
                table: "Orders");

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

            migrationBuilder.DropColumn(
                name: "ID_Performance",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "PerformanceID_Performance",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Experience",
                table: "Employees");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Clients",
                newName: "Series_Number_Passport");

            migrationBuilder.AlterColumn<string>(
                name: "Name_Detail",
                table: "stockDetails",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Choise",
                table: "stockDetails",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AlterColumn<int>(
                name: "ID_Position",
                table: "positions",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<Guid>(
                name: "OrderKey",
                table: "performances",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AlterColumn<int>(
                name: "Order_StatusID_Status",
                table: "Orders",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_Status",
                table: "Orders",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ID_Employee",
                table: "Orders",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeID_Employee",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Order",
                table: "Orders",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "ID_Status",
                table: "order_Statuses",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier")
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<int>(
                name: "PositionID_Position",
                table: "Employees",
                type: "int",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "ID_Position",
                table: "Employees",
                type: "int",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<string>(
                name: "ID_Employee",
                table: "Employees",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Devices",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "DateAdded",
                table: "Clients",
                type: "datetime2",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "ID_Employee", "Address", "EmploymentDate", "FIO", "ID_Position", "Password", "Phone_Number", "PositionID_Position", "Series_Number_Password" },
                values: new object[] { "Gurrex", "Москва", new DateTime(2022, 2, 25, 16, 19, 22, 787, DateTimeKind.Local).AddTicks(716), "Тимоходцев Павел Евгеньевич", 5, "GurrexPassword", "89512289628", null, "3219 008001" });

            migrationBuilder.InsertData(
                table: "order_Statuses",
                columns: new[] { "ID_Status", "Name_Status" },
                values: new object[,]
                {
                    { 1, "Заказ зарегестрирован" },
                    { 2, "Заказ выполняется" },
                    { 3, "Заказ выполнен" },
                    { 4, "Заказ закрыт" }
                });

            migrationBuilder.InsertData(
                table: "positions",
                columns: new[] { "ID_Position", "Name_Position" },
                values: new object[,]
                {
                    { 1, "Стажер" },
                    { 2, "Мастер" },
                    { 3, "Старший мастер" },
                    { 4, "Менеджер" },
                    { 5, "Директор" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_performances_OrderKey",
                table: "performances",
                column: "OrderKey",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_performances_Orders_OrderKey",
                table: "performances",
                column: "OrderKey",
                principalTable: "Orders",
                principalColumn: "ID_Order",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_performances_Orders_OrderKey",
                table: "performances");

            migrationBuilder.DropIndex(
                name: "IX_performances_OrderKey",
                table: "performances");

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "ID_Employee",
                keyValue: "Gurrex");

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "order_Statuses",
                keyColumn: "ID_Status",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "positions",
                keyColumn: "ID_Position",
                keyValue: 5);

            migrationBuilder.DropColumn(
                name: "Choise",
                table: "stockDetails");

            migrationBuilder.DropColumn(
                name: "OrderKey",
                table: "performances");

            migrationBuilder.DropColumn(
                name: "Password",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Devices");

            migrationBuilder.DropColumn(
                name: "DateAdded",
                table: "Clients");

            migrationBuilder.RenameColumn(
                name: "Series_Number_Passport",
                table: "Clients",
                newName: "Address");

            migrationBuilder.AlterColumn<string>(
                name: "Name_Detail",
                table: "stockDetails",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Position",
                table: "positions",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "Order_StatusID_Status",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Status",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Employee",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EmployeeID_Employee",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date_Order",
                table: "Orders",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ID_Performance",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "PerformanceID_Performance",
                table: "Orders",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Status",
                table: "order_Statuses",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int")
                .OldAnnotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AlterColumn<Guid>(
                name: "PositionID_Position",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Position",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<Guid>(
                name: "ID_Employee",
                table: "Employees",
                type: "uniqueidentifier",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<int>(
                name: "Experience",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

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

            migrationBuilder.CreateIndex(
                name: "IX_Orders_PerformanceID_Performance",
                table: "Orders",
                column: "PerformanceID_Performance");

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_performances_PerformanceID_Performance",
                table: "Orders",
                column: "PerformanceID_Performance",
                principalTable: "performances",
                principalColumn: "ID_Performance");
        }
    }
}
