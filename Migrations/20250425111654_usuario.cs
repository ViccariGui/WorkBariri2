using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace WorkBariri2.Migrations
{
    /// <inheritdoc />
    public partial class usuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoEmpresas_Empresas_EmpresasId",
                table: "AvaliacaoEmpresas");

            migrationBuilder.DropForeignKey(
                name: "FK_AvaliacaoUsuarios_Empresas_EmpresasId",
                table: "AvaliacaoUsuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Empresas_EmpresasId",
                table: "Vagas");

            migrationBuilder.DropTable(
                name: "Empresas");

            migrationBuilder.DropIndex(
                name: "IX_Vagas_EmpresasId",
                table: "Vagas");

            migrationBuilder.DropIndex(
                name: "IX_AvaliacaoUsuarios_EmpresasId",
                table: "AvaliacaoUsuarios");

            migrationBuilder.DropIndex(
                name: "IX_AvaliacaoEmpresas_EmpresasId",
                table: "AvaliacaoEmpresas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "787882fb-fff3-4b47-9441-b0244fa8704a");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7efc7065-12f4-4cb2-a678-65b1740e2eda");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "EmpresasId",
                table: "AvaliacaoUsuarios");

            migrationBuilder.DropColumn(
                name: "EmpresasId",
                table: "AvaliacaoEmpresas");

            migrationBuilder.RenameColumn(
                name: "EmpresasId",
                table: "Vagas",
                newName: "UsuariosId");

            migrationBuilder.AddColumn<int>(
                name: "UsuariosId1",
                table: "Vagas",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "0ae4e09f-1f5a-4f91-8f1a-91faafb55a39", null, "Freelancer", "FREELANCER" },
                    { "7e36c8d6-3de6-415d-b2f8-1a49643fb36d", null, "Empresa", "EMPRESA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_UsuariosId1",
                table: "Vagas",
                column: "UsuariosId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Usuarios_UsuariosId1",
                table: "Vagas",
                column: "UsuariosId1",
                principalTable: "Usuarios",
                principalColumn: "UsuariosId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vagas_Usuarios_UsuariosId1",
                table: "Vagas");

            migrationBuilder.DropIndex(
                name: "IX_Vagas_UsuariosId1",
                table: "Vagas");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "0ae4e09f-1f5a-4f91-8f1a-91faafb55a39");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "7e36c8d6-3de6-415d-b2f8-1a49643fb36d");

            migrationBuilder.DropColumn(
                name: "UsuariosId1",
                table: "Vagas");

            migrationBuilder.RenameColumn(
                name: "UsuariosId",
                table: "Vagas",
                newName: "EmpresasId");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresasId",
                table: "AvaliacaoUsuarios",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "EmpresasId",
                table: "AvaliacaoEmpresas",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    EmpresasId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CNPJ = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RamoEmpresa = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telefone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.EmpresasId);
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "787882fb-fff3-4b47-9441-b0244fa8704a", null, "Freelancer", "FREELANCER" },
                    { "7efc7065-12f4-4cb2-a678-65b1740e2eda", null, "Empresa", "EMPRESA" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vagas_EmpresasId",
                table: "Vagas",
                column: "EmpresasId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoUsuarios_EmpresasId",
                table: "AvaliacaoUsuarios",
                column: "EmpresasId");

            migrationBuilder.CreateIndex(
                name: "IX_AvaliacaoEmpresas_EmpresasId",
                table: "AvaliacaoEmpresas",
                column: "EmpresasId");

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoEmpresas_Empresas_EmpresasId",
                table: "AvaliacaoEmpresas",
                column: "EmpresasId",
                principalTable: "Empresas",
                principalColumn: "EmpresasId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_AvaliacaoUsuarios_Empresas_EmpresasId",
                table: "AvaliacaoUsuarios",
                column: "EmpresasId",
                principalTable: "Empresas",
                principalColumn: "EmpresasId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Vagas_Empresas_EmpresasId",
                table: "Vagas",
                column: "EmpresasId",
                principalTable: "Empresas",
                principalColumn: "EmpresasId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
