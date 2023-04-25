using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bijjamAPI.Migrations
{
    /// <inheritdoc />
    public partial class dump : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 17, 42, 863, DateTimeKind.Local).AddTicks(1526));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 17, 42, 863, DateTimeKind.Local).AddTicks(1539));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 17, 42, 863, DateTimeKind.Local).AddTicks(1541));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 17, 42, 863, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 17, 42, 863, DateTimeKind.Local).AddTicks(1545));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 56, 25, 96, DateTimeKind.Local).AddTicks(3566));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 56, 25, 96, DateTimeKind.Local).AddTicks(3584));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 56, 25, 96, DateTimeKind.Local).AddTicks(3587));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 56, 25, 96, DateTimeKind.Local).AddTicks(3589));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 56, 25, 96, DateTimeKind.Local).AddTicks(3591));
        }
    }
}
