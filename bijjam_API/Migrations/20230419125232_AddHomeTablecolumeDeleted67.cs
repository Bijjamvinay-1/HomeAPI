using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace bijjamAPI.Migrations
{
    /// <inheritdoc />
    public partial class AddHomeTablecolumeDeleted67 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 18, 22, 32, 69, DateTimeKind.Local).AddTicks(4766));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 18, 22, 32, 69, DateTimeKind.Local).AddTicks(4781));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 18, 22, 32, 69, DateTimeKind.Local).AddTicks(4783));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 18, 22, 32, 69, DateTimeKind.Local).AddTicks(4785));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 18, 22, 32, 69, DateTimeKind.Local).AddTicks(4788));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 1,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 17, 28, 35, 653, DateTimeKind.Local).AddTicks(8864));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 2,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 17, 28, 35, 653, DateTimeKind.Local).AddTicks(8878));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 3,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 17, 28, 35, 653, DateTimeKind.Local).AddTicks(8880));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 4,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 17, 28, 35, 653, DateTimeKind.Local).AddTicks(8882));

            migrationBuilder.UpdateData(
                table: "Homes",
                keyColumn: "Id",
                keyValue: 5,
                column: "CreatedDate",
                value: new DateTime(2023, 4, 19, 17, 28, 35, 653, DateTimeKind.Local).AddTicks(8884));

            migrationBuilder.InsertData(
                table: "Homes",
                columns: new[] { "Id", "Amenity", "CreatedDate", "Details", "ImageUrl", "Name", "Occupancy", "Rate", "Sqft", "UpdatedDate" },
                values: new object[,]
                {
                    { 6, "", new DateTime(2023, 4, 19, 17, 28, 35, 653, DateTimeKind.Local).AddTicks(8886), "Fusece 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://dotnetmasteryimages.blob.covre.windows.net/bluevillaimages/villa2.jpg", "Diamoend Pool Home", 54, 6050.0, 11500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 7, "", new DateTime(2023, 4, 19, 17, 28, 35, 653, DateTimeKind.Local).AddTicks(8887), "Fusfece 11 tincidunt maximus leo, sed scelerisque massa auctor sit amet. Donec ex mauris, hendrerit quis nibh ac, efficitur fringilla enim.", "https://doftnetmasteryimages.blob.covre.windows.net/bluevillaimages/villa2.jpg", "Diamoefnd Pool Home", 454, 60540.0, 114500, new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });
        }
    }
}
