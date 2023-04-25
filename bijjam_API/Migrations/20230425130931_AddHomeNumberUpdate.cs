using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace bijjamAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHomeNumberUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeNO",
                table: "HomeNumbers",
                newName: "HomeNo");

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 39, 30, 16, DateTimeKind.Local).AddTicks(422));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 39, 30, 16, DateTimeKind.Local).AddTicks(487));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 39, 30, 16, DateTimeKind.Local).AddTicks(490));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 39, 30, 16, DateTimeKind.Local).AddTicks(493));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 25, 18, 39, 30, 16, DateTimeKind.Local).AddTicks(496));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "HomeNo",
                table: "HomeNumbers",
                newName: "HomeNO");

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
    }
}
