using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDDSample.Framework.DataBase.Migrations
{
    public partial class Vr09 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "FabricanteId",
                table: "Produtos",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FabricanteId",
                table: "Produtos",
                column: "FabricanteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Produtos_Fabricantes_FabricanteId",
                table: "Produtos",
                column: "FabricanteId",
                principalTable: "Fabricantes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Produtos_Fabricantes_FabricanteId",
                table: "Produtos");

            migrationBuilder.DropIndex(
                name: "IX_Produtos_FabricanteId",
                table: "Produtos");

            migrationBuilder.DropColumn(
                name: "FabricanteId",
                table: "Produtos");
        }
    }
}
