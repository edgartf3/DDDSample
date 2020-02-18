using Microsoft.EntityFrameworkCore.Migrations;

namespace DDDSample.Framework.DataBase.Migrations
{
    public partial class Vr03 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "RamosAtividade",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cpf_CNPJ",
                table: "Pessoas",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Fabricantes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "unqRamoAtividadeDescricao",
                table: "RamosAtividade",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unqProdutoDescricao",
                table: "Produtos",
                column: "Descricao",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "unqPessoaCpf_Cnpj",
                table: "Pessoas",
                column: "Cpf_CNPJ",
                unique: true,
                filter: "[Cpf_CNPJ] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "unqFabricanteDescricao",
                table: "Fabricantes",
                column: "Descricao",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "unqRamoAtividadeDescricao",
                table: "RamosAtividade");

            migrationBuilder.DropIndex(
                name: "unqProdutoDescricao",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "unqPessoaCpf_Cnpj",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "unqFabricanteDescricao",
                table: "Fabricantes");

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "RamosAtividade",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Produtos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "Cpf_CNPJ",
                table: "Pessoas",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Descricao",
                table: "Fabricantes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
