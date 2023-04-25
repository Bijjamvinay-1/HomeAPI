using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bijjamAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHomeNumber2ToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 10, 55, 97, DateTimeKind.Local).AddTicks(6091));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 10, 55, 97, DateTimeKind.Local).AddTicks(6105));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 10, 55, 97, DateTimeKind.Local).AddTicks(6107));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 10, 55, 97, DateTimeKind.Local).AddTicks(6109));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 17, 10, 55, 97, DateTimeKind.Local).AddTicks(6111));
        }
    }
}
