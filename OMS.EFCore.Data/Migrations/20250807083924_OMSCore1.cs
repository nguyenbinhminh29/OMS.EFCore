using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace OMS.EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class OMSCore1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Categories",
                columns: new[] { "CateId", "CreateDate", "Description", "ModifiedDate", "Name", "Status" },
                values: new object[,]
                {
                    { 1, new DateTime(2025, 8, 7, 15, 39, 23, 915, DateTimeKind.Local).AddTicks(11), "Phân loại 01", new DateTime(2025, 8, 7, 15, 39, 23, 915, DateTimeKind.Local).AddTicks(23), "Cate_01", "A" },
                    { 2, new DateTime(2025, 8, 7, 15, 39, 23, 915, DateTimeKind.Local).AddTicks(26), "Phân loại 02", new DateTime(2025, 8, 7, 15, 39, 23, 915, DateTimeKind.Local).AddTicks(26), "Cate_02", "A" },
                    { 3, new DateTime(2025, 8, 7, 15, 39, 23, 915, DateTimeKind.Local).AddTicks(28), "Phân loại 03", new DateTime(2025, 8, 7, 15, 39, 23, 915, DateTimeKind.Local).AddTicks(28), "Cate_03", "A" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CateId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CateId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Categories",
                keyColumn: "CateId",
                keyValue: 3);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Categories",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);
        }
    }
}
