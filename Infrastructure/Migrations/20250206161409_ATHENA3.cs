using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Ptd_linjir",
                table: "PreAtendimentoPlantao",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Ptd_verjir",
                table: "PreAtendimentoPlantao",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ptd_linjir",
                table: "PreAtendimentoPlantao");

            migrationBuilder.DropColumn(
                name: "Ptd_verjir",
                table: "PreAtendimentoPlantao");
        }
    }
}
