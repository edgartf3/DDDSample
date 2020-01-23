using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDDSample.Framework.DataBase.Migrations
{
    public partial class Vr06 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Endereco",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Endereco_ProdutoId",
                table: "Endereco",
                column: "ProdutoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_Produtos_ProdutoId",
                table: "Endereco",
                column: "ProdutoId",
                principalTable: "Produtos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_Produtos_ProdutoId",
                table: "Endereco");

            migrationBuilder.DropIndex(
                name: "IX_Endereco_ProdutoId",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "ProdutoId",
                table: "Endereco");

            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Pessoas",
                type: "uniqueidentifier",
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
    }
}
