using Microsoft.EntityFrameworkCore.Migrations;

namespace DDDSample.Framework.DataBase.Migrations
{
    public partial class Vr04 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CNPJ",
                table: "Fabricantes",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CNPJ",
                table: "Fabricantes");
        }
    }
}
