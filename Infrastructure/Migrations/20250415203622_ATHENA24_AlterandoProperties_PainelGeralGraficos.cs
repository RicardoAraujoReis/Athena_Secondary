using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA24_AlterandoProperties_PainelGeralGraficos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Height",
                schema: "Athena",
                table: "PainelGeralGraficos");

            migrationBuilder.DropColumn(
                name: "Labels",
                schema: "Athena",
                table: "PainelGeralGraficos");

            migrationBuilder.DropColumn(
                name: "Series",
                schema: "Athena",
                table: "PainelGeralGraficos");

            migrationBuilder.DropColumn(
                name: "Width",
                schema: "Athena",
                table: "PainelGeralGraficos");

            migrationBuilder.RenameColumn(
                name: "Index",
                schema: "Athena",
                table: "PainelGeralGraficos",
                newName: "Quantidade");

            migrationBuilder.RenameColumn(
                name: "ChartName",
                schema: "Athena",
                table: "PainelGeralGraficos",
                newName: "NomeCliente");

            migrationBuilder.AddColumn<int>(
                name: "Ano",
                schema: "Athena",
                table: "PainelGeralGraficos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Mes",
                schema: "Athena",
                table: "PainelGeralGraficos",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Ano",
                schema: "Athena",
                table: "PainelGeralGraficos");

            migrationBuilder.DropColumn(
                name: "Mes",
                schema: "Athena",
                table: "PainelGeralGraficos");

            migrationBuilder.RenameColumn(
                name: "Quantidade",
                schema: "Athena",
                table: "PainelGeralGraficos",
                newName: "Index");

            migrationBuilder.RenameColumn(
                name: "NomeCliente",
                schema: "Athena",
                table: "PainelGeralGraficos",
                newName: "ChartName");

            migrationBuilder.AddColumn<string>(
                name: "Height",
                schema: "Athena",
                table: "PainelGeralGraficos",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Labels",
                schema: "Athena",
                table: "PainelGeralGraficos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Series",
                schema: "Athena",
                table: "PainelGeralGraficos",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Width",
                schema: "Athena",
                table: "PainelGeralGraficos",
                type: "nvarchar(35)",
                maxLength: 35,
                nullable: false,
                defaultValue: "");
        }
    }
}
