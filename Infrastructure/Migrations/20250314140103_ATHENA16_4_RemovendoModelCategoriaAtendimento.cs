using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA16_4_RemovendoModelCategoriaAtendimento : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "Atd_cat_identi",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropTable(
                name: "CategoriaAtendimento");

            migrationBuilder.DropIndex(
                name: "IX_AtendimentoPlantao_Atd_cat_identi",
                schema: "Athena",
                table: "AtendimentoPlantao");

            migrationBuilder.DropColumn(
                name: "Atd_cat_identi",
                schema: "Athena",
                table: "AtendimentoPlantao");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Atd_cat_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "CategoriaAtendimento",
                columns: table => new
                {
                    Cat_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Cat_catpai = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    Cat_datalt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cat_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cat_despai = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Cat_nivel = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Cat_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    Cat_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cat_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Cat_valor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaAtendimento", x => x.Cat_identi);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_Atd_cat_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_cat_identi");

            migrationBuilder.AddForeignKey(
                name: "Atd_cat_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_cat_identi",
                principalTable: "CategoriaAtendimento",
                principalColumn: "Cat_identi",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
