using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDDSample.Framework.DataBase.Migrations
{
    public partial class Vr05 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Pessoas",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_ProdutoId",
                table: "Pessoas",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pessoas_Produtos_ProdutoId",
                table: "Pessoas",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pessoas_Produtos_ProdutoId",
                table: "Pessoas");

            migrationBuilder.DropIndex(
                name: "IX_Pessoas_ProdutoId",
                table: "Pessoas");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Pessoas");
        }
    }
}
