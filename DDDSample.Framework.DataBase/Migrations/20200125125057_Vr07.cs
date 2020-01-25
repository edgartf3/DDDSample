using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDDSample.Framework.DataBase.Migrations
{
    public partial class Vr07 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "ProdutoId",
                table: "Endereco",
                type: "uniqueidentifier",
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
    }
}
