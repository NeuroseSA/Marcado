using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marcado.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddConfiguracaoHorario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConfiguracoesHorario",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    UsuarioId = table.Column<int>(type: "INTEGER", nullable: false),
                    HoraInicio = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    HoraFim = table.Column<TimeSpan>(type: "TEXT", nullable: false),
                    IntervaloSlots = table.Column<int>(type: "INTEGER", nullable: false),
                    SegundaAtiva = table.Column<bool>(type: "INTEGER", nullable: false),
                    TercaAtiva = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuartaAtiva = table.Column<bool>(type: "INTEGER", nullable: false),
                    QuintaAtiva = table.Column<bool>(type: "INTEGER", nullable: false),
                    SextaAtiva = table.Column<bool>(type: "INTEGER", nullable: false),
                    SabadoAtiva = table.Column<bool>(type: "INTEGER", nullable: false),
                    DomingoAtiva = table.Column<bool>(type: "INTEGER", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "TEXT", nullable: false),
                    DataAtualizacao = table.Column<DateTime>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConfiguracoesHorario", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConfiguracoesHorario_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConfiguracoesHorario_UsuarioId",
                table: "ConfiguracoesHorario",
                column: "UsuarioId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConfiguracoesHorario");
        }
    }
}
