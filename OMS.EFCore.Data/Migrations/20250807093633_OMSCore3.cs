using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace OMS.EFCore.Data.Migrations
{
    /// <inheritdoc />
    public partial class OMSCore3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CateId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 7, 16, 36, 33, 184, DateTimeKind.Local).AddTicks(9006), new DateTime(2025, 8, 7, 16, 36, 33, 184, DateTimeKind.Local).AddTicks(9018) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CateId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 7, 16, 36, 33, 184, DateTimeKind.Local).AddTicks(9020), new DateTime(2025, 8, 7, 16, 36, 33, 184, DateTimeKind.Local).AddTicks(9021) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CateId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 7, 16, 36, 33, 184, DateTimeKind.Local).AddTicks(9023), new DateTime(2025, 8, 7, 16, 36, 33, 184, DateTimeKind.Local).AddTicks(9023) });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CateId",
                keyValue: 1,
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 7, 16, 36, 9, 942, DateTimeKind.Local).AddTicks(4120), new DateTime(2025, 8, 7, 16, 36, 9, 942, DateTimeKind.Local).AddTicks(4135) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CateId",
                keyValue: 2,
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 7, 16, 36, 9, 942, DateTimeKind.Local).AddTicks(4138), new DateTime(2025, 8, 7, 16, 36, 9, 942, DateTimeKind.Local).AddTicks(4139) });

            migrationBuilder.UpdateData(
                table: "Categories",
                keyColumn: "CateId",
                keyValue: 3,
                columns: new[] { "CreateDate", "ModifiedDate" },
                values: new object[] { new DateTime(2025, 8, 7, 16, 36, 9, 942, DateTimeKind.Local).AddTicks(4141), new DateTime(2025, 8, 7, 16, 36, 9, 942, DateTimeKind.Local).AddTicks(4141) });
        }
    }
}
