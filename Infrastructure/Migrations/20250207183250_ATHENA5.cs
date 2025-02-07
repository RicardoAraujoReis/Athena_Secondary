using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Atd_linjir",
                schema: "Athena",
                table: "AtendimentoPlantao",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Atd_verjir",
                schema: "Athena",
                table: "AtendimentoPlantao",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atd_linjir",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropColumn(
                name: "Atd_verjir",
                schema: "Athena",
                table: "AtendimentoPlantao");
        }
    }
}
