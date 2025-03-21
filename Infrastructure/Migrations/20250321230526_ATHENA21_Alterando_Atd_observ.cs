using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA21_Alterando_Atd_observ : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Atd_observ",
                schema: "Athena",
                table: "AtendimentoPlantao",
                newName: "Atd_jusevo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Atd_jusevo",
                schema: "Athena",
                table: "AtendimentoPlantao",
                newName: "Atd_observ");
        }
    }
}
