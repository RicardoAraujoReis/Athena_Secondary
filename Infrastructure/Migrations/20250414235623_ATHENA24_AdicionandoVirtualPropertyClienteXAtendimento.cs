using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA24_AdicionandoVirtualPropertyClienteXAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_Atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_cli_identi");

            migrationBuilder.AddForeignKey(
                name: "Atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_cli_identi",
                principalTable: "Cliente",
                principalColumn: "Cli_identi",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropIndex(
                name: "IX_AtendimentoPlantao_Atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao");
        }
    }
}
