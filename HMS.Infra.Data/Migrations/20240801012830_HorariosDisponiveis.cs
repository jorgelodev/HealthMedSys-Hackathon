using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class HorariosDisponiveis : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_HorariosDisponiveis_Medicos_MedicoId",
                table: "HorariosDisponiveis");

            migrationBuilder.DropColumn(
                name: "DataHora",
                table: "Consultas");

            migrationBuilder.AddColumn<int>(
                name: "HorarioDisponivelId",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_HorarioDisponivelId",
                table: "Consultas",
                column: "HorarioDisponivelId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_HorariosDisponiveis_HorarioDisponivelId",
                table: "Consultas",
                column: "HorarioDisponivelId",
                principalTable: "HorariosDisponiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_HorariosDisponiveis_Medicos_MedicoId",
                table: "HorariosDisponiveis",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_HorariosDisponiveis_HorarioDisponivelId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_HorariosDisponiveis_Medicos_MedicoId",
                table: "HorariosDisponiveis");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_HorarioDisponivelId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "HorarioDisponivelId",
                table: "Consultas");

            migrationBuilder.AddColumn<DateTime>(
                name: "DataHora",
                table: "Consultas",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_HorariosDisponiveis_Medicos_MedicoId",
                table: "HorariosDisponiveis",
                column: "MedicoId",
                principalTable: "Medicos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
