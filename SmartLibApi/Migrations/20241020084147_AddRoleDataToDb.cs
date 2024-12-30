using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartLibApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRoleDataToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7eb7bcb3-967b-4988-a11b-7dbe53577255", null, "Administrator", "ADMINISTRATOR" },
                    { "df6eda1d-b0c3-4d9e-b30a-cb06aad12cf0", null, "Manager", "MANAGER" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7eb7bcb3-967b-4988-a11b-7dbe53577255");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "df6eda1d-b0c3-4d9e-b30a-cb06aad12cf0");
        }
    }
}
