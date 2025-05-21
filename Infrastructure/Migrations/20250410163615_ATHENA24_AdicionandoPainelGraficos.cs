using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class ATHENA24_AdicionandoPainelGraficos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "PainelGeralGraficos",
                schema: "Athena",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ChartName = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    Index = table.Column<int>(type: "int", nullable: false),
                    Width = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Height = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Series = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Labels = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PainelGeralGraficos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PainelGeralGraficos",
                schema: "Athena");
        }
    }
}
