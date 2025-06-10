using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace api_project.api.Migrations
{
    /// <inheritdoc />
    public partial class SeedingdataforDifficultiesandRegions : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Difficulties",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("1f47584e-8a47-4ec9-8705-d95fba905964"), "Hard" },
                    { new Guid("27d53c7c-4d97-422e-876a-6093659436f9"), "Easy" },
                    { new Guid("e9b4e741-b526-414a-96fd-fdc6d7d13e98"), "Medium" }
                });

            migrationBuilder.InsertData(
                table: "Regions",
                columns: new[] { "Id", "Code", "Name", "RegionImageUrl" },
                values: new object[,]
                {
                    { new Guid("b1c8f0d2-3e4f-4c5a-9b6d-7e8f9a0b1c2d"), "REG001", "North Region", "https://example.com/north-region.jpg" },
                    { new Guid("c2d3e4f5-6a7b-8c9d-a0b1-c2d3e4f5a6b7"), "REG002", "South Region", "https://example.com/south-region.jpg" },
                    { new Guid("d3e4f5a6-b7c8-d9e0-f1a2-b3c4d5e6f7a8"), "REG003", "East Region", "https://example.com/east-region.jpg" },
                    { new Guid("e4f5a6b7-c8d9-e0f1-a2b3-c4d5e6f7a8b9"), "REG004", "West Region", "https://example.com/west-region.jpg" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("1f47584e-8a47-4ec9-8705-d95fba905964"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("27d53c7c-4d97-422e-876a-6093659436f9"));

            migrationBuilder.DeleteData(
                table: "Difficulties",
                keyColumn: "Id",
                keyValue: new Guid("e9b4e741-b526-414a-96fd-fdc6d7d13e98"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("b1c8f0d2-3e4f-4c5a-9b6d-7e8f9a0b1c2d"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("c2d3e4f5-6a7b-8c9d-a0b1-c2d3e4f5a6b7"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("d3e4f5a6-b7c8-d9e0-f1a2-b3c4d5e6f7a8"));

            migrationBuilder.DeleteData(
                table: "Regions",
                keyColumn: "Id",
                keyValue: new Guid("e4f5a6b7-c8d9-e0f1-a2b3-c4d5e6f7a8b9"));
        }
    }
}
