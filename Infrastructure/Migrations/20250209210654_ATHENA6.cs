using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ComentariosAtendimentoPlantao",
                schema: "Athena",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cap_coment = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cap_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Cap_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cap_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: true),
                    Cap_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cap_datalt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Cap_atd_identi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentariosAtendimentoPlantao", x => x.Id);
                    table.ForeignKey(
                        name: "Cap_atd_identi",
                        column: x => x.Cap_atd_identi,
                        principalSchema: "Athena",
                        principalTable: "AtendimentoPlantao",
                        principalColumn: "Atd_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComentariosAtendimentoPlantao_Cap_atd_identi",
                schema: "Athena",
                table: "ComentariosAtendimentoPlantao",
                column: "Cap_atd_identi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ComentariosAtendimentoPlantao",
                schema: "Athena");
        }
    }
}
