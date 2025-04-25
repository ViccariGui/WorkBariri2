using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkBariri2.Migrations
{
    /// <inheritdoc />
    public partial class TipoUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "787882fb-fff3-4b47-9441-b0244fa8704a", null, "Freelancer", "FREELANCER" },
                    { "7efc7065-12f4-4cb2-a678-65b1740e2eda", null, "Empresa", "EMPRESA" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "787882fb-fff3-4b47-9441-b0244fa8704a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7efc7065-12f4-4cb2-a678-65b1740e2eda");
        }
    }
}
