using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Marcado.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeparandoDataHora : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DataHora",
                table: "Agendamentos",
                newName: "Data");

            migrationBuilder.AddColumn<int>(
                name: "Hora",
                table: "Agendamentos",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hora",
                table: "Agendamentos");

            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Agendamentos",
                newName: "DataHora");
        }
    }
}
