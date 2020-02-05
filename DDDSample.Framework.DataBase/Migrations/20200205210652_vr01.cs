using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DDDSample.Framework.DataBase.Migrations
{
    public partial class vr01 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fabricantes",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fabricantes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RamosAtividade",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RamosAtividade", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Produtos",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Preco = table.Column<double>(nullable: false),
                    FabricanteId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produtos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Produtos_Fabricantes_FabricanteId",
                        column: x => x.FabricanteId,
                        principalTable: "Fabricantes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Pessoas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    Cpf_CNPJ = table.Column<string>(nullable: true),
                    Faturamento_Logradouro = table.Column<string>(nullable: true),
                    Faturamento_Numero = table.Column<string>(nullable: true),
                    Faturamento_Complemento = table.Column<string>(nullable: true),
                    Faturamento_CEP = table.Column<string>(nullable: true),
                    Faturamento_Bairro = table.Column<string>(nullable: true),
                    Faturamento_Cidade = table.Column<string>(nullable: true),
                    Faturamento_UF = table.Column<string>(nullable: true),
                    Entrega_Logradouro = table.Column<string>(nullable: true),
                    Entrega_Numero = table.Column<string>(nullable: true),
                    Entrega_Complemento = table.Column<string>(nullable: true),
                    Entrega_CEP = table.Column<string>(nullable: true),
                    Entrega_Bairro = table.Column<string>(nullable: true),
                    Entrega_Cidade = table.Column<string>(nullable: true),
                    Entrega_UF = table.Column<string>(nullable: true),
                    RamoAtividadeId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pessoas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pessoas_RamosAtividade_RamoAtividadeId",
                        column: x => x.RamoAtividadeId,
                        principalTable: "RamosAtividade",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CaracteristicaFisica",
                columns: table => new
                {
                    PessoaId = table.Column<Guid>(nullable: false),
                    CorOlhos = table.Column<string>(nullable: true),
                    CorCabelo = table.Column<string>(nullable: true),
                    Peso = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CaracteristicaFisica", x => x.PessoaId);
                    table.ForeignKey(
                        name: "FK_CaracteristicaFisica_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Dependente",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    Nome = table.Column<string>(nullable: true),
                    CPF = table.Column<string>(nullable: true),
                    PessoaId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dependente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Dependente_Pessoas_PessoaId",
                        column: x => x.PessoaId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Vendas",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    Numero = table.Column<int>(nullable: false),
                    Data = table.Column<DateTime>(nullable: false),
                    ClienteId = table.Column<Guid>(nullable: true),
                    ValorMercadoria = table.Column<double>(nullable: false),
                    ValorDesconto = table.Column<double>(nullable: false),
                    ValorTotal = table.Column<double>(nullable: false),
                    Entrega_Logradouro = table.Column<string>(nullable: true),
                    Entrega_Numero = table.Column<string>(nullable: true),
                    Entrega_Complemento = table.Column<string>(nullable: true),
                    Entrega_CEP = table.Column<string>(nullable: true),
                    Entrega_Bairro = table.Column<string>(nullable: true),
                    Entrega_Cidade = table.Column<string>(nullable: true),
                    Entrega_UF = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendas", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vendas_Pessoas_ClienteId",
                        column: x => x.ClienteId,
                        principalTable: "Pessoas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Itens",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    CriadoEm = table.Column<DateTime>(nullable: true),
                    ProdutoId = table.Column<Guid>(nullable: true),
                    Quantidade = table.Column<double>(nullable: false),
                    Preco = table.Column<double>(nullable: false),
                    SubTotal = table.Column<double>(nullable: false),
                    ValorDesconto = table.Column<double>(nullable: false),
                    Total = table.Column<double>(nullable: false),
                    VendaId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Itens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Itens_Produtos_ProdutoId",
                        column: x => x.ProdutoId,
                        principalTable: "Produtos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Itens_Vendas_VendaId",
                        column: x => x.VendaId,
                        principalTable: "Vendas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Dependente_PessoaId",
                table: "Dependente",
                column: "PessoaId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_ProdutoId",
                table: "Itens",
                column: "ProdutoId");

            migrationBuilder.CreateIndex(
                name: "IX_Itens_VendaId",
                table: "Itens",
                column: "VendaId");

            migrationBuilder.CreateIndex(
                name: "IX_Pessoas_RamoAtividadeId",
                table: "Pessoas",
                column: "RamoAtividadeId");

            migrationBuilder.CreateIndex(
                name: "IX_Produtos_FabricanteId",
                table: "Produtos",
                column: "FabricanteId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendas_ClienteId",
                table: "Vendas",
                column: "ClienteId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CaracteristicaFisica");

            migrationBuilder.DropTable(
                name: "Dependente");

            migrationBuilder.DropTable(
                name: "Itens");

            migrationBuilder.DropTable(
                name: "Produtos");

            migrationBuilder.DropTable(
                name: "Vendas");

            migrationBuilder.DropTable(
                name: "Fabricantes");

            migrationBuilder.DropTable(
                name: "Pessoas");

            migrationBuilder.DropTable(
                name: "RamosAtividade");
        }
    }
}
