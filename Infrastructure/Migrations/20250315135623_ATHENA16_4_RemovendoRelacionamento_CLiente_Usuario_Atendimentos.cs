using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA16_4_RemovendoRelacionamento_CLiente_Usuario_Atendimentos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropForeignKey(
                name: "Atd_usu_identi",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropIndex(
                name: "IX_AtendimentoPlantao_Atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropIndex(
                name: "IX_AtendimentoPlantao_Atd_usu_identi",
                schema: "Athena",
                table: "AtendimentoPlantao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_Atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_cli_identi");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_Atd_usu_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_usu_identi");

            migrationBuilder.AddForeignKey(
                name: "Atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_cli_identi",
                principalTable: "Cliente",
                principalColumn: "Cli_identi",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "Atd_usu_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_usu_identi",
                principalTable: "Usuario",
                principalColumn: "Usu_identi",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
