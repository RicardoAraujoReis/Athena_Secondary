using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA16_4_AdicionandoPropertiesCategoriasModelAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Atd_catnv1",
                schema: "Athena",
                table: "AtendimentoPlantao",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Atd_catnv2",
                schema: "Athena",
                table: "AtendimentoPlantao",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Atd_catnv3",
                schema: "Athena",
                table: "AtendimentoPlantao",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Atd_catnv4",
                schema: "Athena",
                table: "AtendimentoPlantao",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Atd_catnv1",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropColumn(
                name: "Atd_catnv2",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropColumn(
                name: "Atd_catnv3",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropColumn(
                name: "Atd_catnv4",
                schema: "Athena",
                table: "AtendimentoPlantao");
        }
    }
}
