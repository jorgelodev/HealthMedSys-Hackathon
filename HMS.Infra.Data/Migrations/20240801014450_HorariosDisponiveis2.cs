using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HMS.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class HorariosDisponiveis2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_HorariosDisponiveis_HorarioDisponivelId",
                table: "Consultas");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_HorariosDisponiveis_HorarioDisponivelId",
                table: "Consultas",
                column: "HorarioDisponivelId",
                principalTable: "HorariosDisponiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_HorariosDisponiveis_HorarioDisponivelId",
                table: "Consultas");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_HorariosDisponiveis_HorarioDisponivelId",
                table: "Consultas",
                column: "HorarioDisponivelId",
                principalTable: "HorariosDisponiveis",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
