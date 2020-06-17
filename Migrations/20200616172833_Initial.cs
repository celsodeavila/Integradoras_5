using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CaoLendario.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Animais",
                columns: table => new
                {
                    AnimalID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeAnimal = table.Column<string>(nullable: true),
                    Nascimento = table.Column<DateTime>(nullable: false),
                    Peso = table.Column<double>(nullable: false),
                    Sexo = table.Column<int>(nullable: false),
                    TipoPelagem = table.Column<int>(nullable: false),
                    Porte = table.Column<int>(nullable: false),
                    GostaBrincar = table.Column<bool>(nullable: false),
                    Temperamento = table.Column<string>(nullable: true),
                    RelacionaOutroCao = table.Column<bool>(nullable: false),
                    RelacionaGato = table.Column<bool>(nullable: false),
                    PossuiDeficiencia = table.Column<bool>(nullable: false),
                    HistoricoVida = table.Column<string>(nullable: true),
                    urlFoto = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animais", x => x.AnimalID);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nome = table.Column<string>(nullable: true),
                    email = table.Column<string>(nullable: true),
                    senha = table.Column<string>(nullable: true),
                    data_nascimento = table.Column<DateTime>(nullable: false),
                    endereco = table.Column<string>(nullable: true),
                    cep = table.Column<string>(nullable: true),
                    uf = table.Column<string>(nullable: true),
                    telefone = table.Column<string>(nullable: true),
                    Discriminator = table.Column<string>(nullable: false),
                    CRMV = table.Column<string>(nullable: true),
                    Data = table.Column<DateTime>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                });

            migrationBuilder.CreateTable(
                name: "Interesse",
                columns: table => new
                {
                    InteresseID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Data = table.Column<DateTime>(nullable: false),
                    Adotado = table.Column<bool>(nullable: false),
                    AnimalID = table.Column<int>(nullable: false),
                    AdotanteID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Interesse", x => x.InteresseID);
                    table.ForeignKey(
                        name: "FK_Interesse_Users_AdotanteID",
                        column: x => x.AdotanteID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Interesse_Animais_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animais",
                        principalColumn: "AnimalID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ProcedimentosPosAdocao",
                columns: table => new
                {
                    ProcedimentosPosAdocaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(nullable: true),
                    data = table.Column<DateTime>(nullable: false),
                    AnimalID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedimentosPosAdocao", x => x.ProcedimentosPosAdocaoID);
                    table.ForeignKey(
                        name: "FK_ProcedimentosPosAdocao_Animais_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animais",
                        principalColumn: "AnimalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedimentosPosAdocao_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProcedimentosPreAdocao",
                columns: table => new
                {
                    ProcedimentosPreAdocaoID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descricao = table.Column<string>(nullable: true),
                    data = table.Column<DateTime>(nullable: false),
                    AnimalID = table.Column<int>(nullable: false),
                    UserID = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcedimentosPreAdocao", x => x.ProcedimentosPreAdocaoID);
                    table.ForeignKey(
                        name: "FK_ProcedimentosPreAdocao_Animais_AnimalID",
                        column: x => x.AnimalID,
                        principalTable: "Animais",
                        principalColumn: "AnimalID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ProcedimentosPreAdocao_Users_UserID",
                        column: x => x.UserID,
                        principalTable: "Users",
                        principalColumn: "UserID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Interesse_AdotanteID",
                table: "Interesse",
                column: "AdotanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Interesse_AnimalID",
                table: "Interesse",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentosPosAdocao_AnimalID",
                table: "ProcedimentosPosAdocao",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentosPosAdocao_UserID",
                table: "ProcedimentosPosAdocao",
                column: "UserID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentosPreAdocao_AnimalID",
                table: "ProcedimentosPreAdocao",
                column: "AnimalID");

            migrationBuilder.CreateIndex(
                name: "IX_ProcedimentosPreAdocao_UserID",
                table: "ProcedimentosPreAdocao",
                column: "UserID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Interesse");

            migrationBuilder.DropTable(
                name: "ProcedimentosPosAdocao");

            migrationBuilder.DropTable(
                name: "ProcedimentosPreAdocao");

            migrationBuilder.DropTable(
                name: "Animais");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
