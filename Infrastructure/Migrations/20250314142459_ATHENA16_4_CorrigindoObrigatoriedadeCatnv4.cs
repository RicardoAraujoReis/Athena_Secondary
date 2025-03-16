using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA16_4_CorrigindoObrigatoriedadeCatnv4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Atd_catnv4",
                schema: "Athena",
                table: "AtendimentoPlantao",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(65)",
                oldMaxLength: 65);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Atd_catnv4",
                schema: "Athena",
                table: "AtendimentoPlantao",
                type: "nvarchar(65)",
                maxLength: 65,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(65)",
                oldMaxLength: 65,
                oldNullable: true);
        }
    }
}
