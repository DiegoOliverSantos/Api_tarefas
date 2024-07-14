using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class AtualizarColunaEIncluirNova : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Data",
                table: "Tarefas",
                newName: "Data_Criacao");

            migrationBuilder.AddColumn<DateTime>(
                name: "Data_Atualizacao",
                table: "Tarefas",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Data_Atualizacao",
                table: "Tarefas");

            migrationBuilder.RenameColumn(
                name: "Data_Criacao",
                table: "Tarefas",
                newName: "Data");
        }
    }
}
