using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class RecriandoEstrutura : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "Athena");

            migrationBuilder.CreateTable(
                name: "CategoriaAtendimento",
                columns: table => new
                {
                    Cat_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cat_catpai = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Cat_nivel = table.Column<int>(type: "int", maxLength: 1, nullable: false),
                    Cat_valor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cat_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cat_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Cat_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Cat_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cat_datalt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaAtendimento", x => x.Cat_identi);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    Dpt_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dpt_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dpt_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Dpt_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Dpt_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Dpt_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Dpt_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dpt_datalt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.Dpt_identi);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    Fnc_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Fnc_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Fnc_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Fnc_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Fnc_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Fnc_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Fnc_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Fnc_datalt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.Fnc_identi);
                });

            migrationBuilder.CreateTable(
                name: "LinhaNegocio",
                columns: table => new
                {
                    Lhn_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Lhn_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Lhn_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Lhn_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Lhn_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Lhn_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Lhn_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Lhn_datalt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaNegocio", x => x.Lhn_identi);
                });

            migrationBuilder.CreateTable(
                name: "TipoDadosListas",
                columns: table => new
                {
                    Tid_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Tid_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tid_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Tid_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tid_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Tid_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Tid_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDadosListas", x => x.Tid_identi);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    Usu_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Usu_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Usu_login = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Usu_senha = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false),
                    Usu_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Usu_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Usu_status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Usu_master = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Usu_tipusu = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Usu_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Usu_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Usu_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Usu_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Usu_datalt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.Usu_identi);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    Cli_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cli_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Cli_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Cli_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Cli_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Cli_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Cli_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cli_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Cli_lhn_identi = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.Cli_identi);
                    table.ForeignKey(
                        name: "Cli_lhn_identi",
                        column: x => x.Cli_lhn_identi,
                        principalTable: "LinhaNegocio",
                        principalColumn: "Lhn_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DadosListas",
                columns: table => new
                {
                    Dal_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dal_tid_identi = table.Column<int>(type: "int", nullable: false),
                    Dal_valor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Dal_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Dal_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dal_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dal_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Dal_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosListas", x => x.Dal_identi);
                    table.ForeignKey(
                        name: "Dal_tid_identi",
                        column: x => x.Dal_tid_identi,
                        principalTable: "TipoDadosListas",
                        principalColumn: "Tid_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepFunc",
                columns: table => new
                {
                    Dfc_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Dfc_dpt_identi = table.Column<int>(type: "int", nullable: false),
                    Dfc_fnc_identi = table.Column<int>(type: "int", nullable: false),
                    Dfc_usu_identi = table.Column<int>(type: "int", nullable: false),
                    Dfc_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Dfc_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Dfc_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Dfc_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Dfc_datalt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepFunc", x => x.Dfc_identi);
                    table.ForeignKey(
                        name: "Dfc_dpt_identi",
                        column: x => x.Dfc_dpt_identi,
                        principalTable: "Departamento",
                        principalColumn: "Dpt_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Dfc_fnc_identi",
                        column: x => x.Dfc_fnc_identi,
                        principalTable: "Funcao",
                        principalColumn: "Fnc_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Dfc_usu_identi",
                        column: x => x.Dfc_usu_identi,
                        principalTable: "Usuario",
                        principalColumn: "Usu_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuLhn",
                columns: table => new
                {
                    Uln_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Uln_usu_identi = table.Column<int>(type: "int", nullable: false),
                    Uln_lhn_identi = table.Column<int>(type: "int", nullable: false),
                    Uln_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Uln_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Uln_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Uln_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Uln_datalt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuLhn", x => x.Uln_identi);
                    table.ForeignKey(
                        name: "Uln_lhn_identi",
                        column: x => x.Uln_lhn_identi,
                        principalTable: "LinhaNegocio",
                        principalColumn: "Lhn_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Uln_usu_identi",
                        column: x => x.Uln_usu_identi,
                        principalTable: "Usuario",
                        principalColumn: "Usu_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreAtendimentoPlantao",
                columns: table => new
                {
                    Ptd_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ptd_datptd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ptd_usu_identi = table.Column<int>(type: "int", nullable: false),
                    Ptd_cli_identi = table.Column<int>(type: "int", nullable: false),
                    Ptd_tipptd = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Ptd_critic = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Ptd_resumo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ptd_numcha = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Ptd_jirarl = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Ptd_numjir = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Ptd_diagn1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Ptd_status = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true),
                    Ptd_reton2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ptd_observ = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Ptd_nomal1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Ptd_numatd = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Ptd_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Ptd_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ptd_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Ptd_usucri = table.Column<int>(type: "int", nullable: false),
                    Ptd_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreAtendimentoPlantao", x => x.Ptd_identi);
                    table.ForeignKey(
                        name: "Ptd_cli_identi",
                        column: x => x.Ptd_cli_identi,
                        principalTable: "Cliente",
                        principalColumn: "Cli_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Ptd_usu_identi",
                        column: x => x.Ptd_usu_identi,
                        principalTable: "Usuario",
                        principalColumn: "Usu_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentoPlantao",
                schema: "Athena",
                columns: table => new
                {
                    Atd_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Atd_usu_identi = table.Column<int>(type: "int", nullable: false),
                    Atd_ptd_identi = table.Column<int>(type: "int", nullable: false),
                    Atd_cli_identi = table.Column<int>(type: "int", nullable: false),
                    Atd_tipatd = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Atd_cat_identi = table.Column<int>(type: "int", nullable: false),
                    Atd_resumo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Atd_respn2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Atd_crijir = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Atd_issue = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Atd_critic = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Atd_resplt = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Atd_ren1hm = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Atd_resn1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false),
                    Atd_evoln1 = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true),
                    Atd_observ = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    Atd_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Atd_datatd = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Atd_nomal2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Atd_status = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false),
                    Atd_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Atd_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Atd_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Atd_datalt = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoPlantao", x => x.Atd_identi);
                    table.ForeignKey(
                        name: "Atd_cat_identi",
                        column: x => x.Atd_cat_identi,
                        principalTable: "CategoriaAtendimento",
                        principalColumn: "Cat_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Atd_cli_identi",
                        column: x => x.Atd_cli_identi,
                        principalTable: "Cliente",
                        principalColumn: "Cli_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "Atd_ptd_identi",
                        column: x => x.Atd_ptd_identi,
                        principalTable: "PreAtendimentoPlantao",
                        principalColumn: "Ptd_identi");
                    table.ForeignKey(
                        name: "Atd_usu_identi",
                        column: x => x.Atd_usu_identi,
                        principalTable: "Usuario",
                        principalColumn: "Usu_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_Atd_cat_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_cat_identi");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_Atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_cli_identi");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_Atd_ptd_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_ptd_identi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_Atd_usu_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "Atd_usu_identi");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_Cli_lhn_identi",
                table: "Cliente",
                column: "Cli_lhn_identi");

            migrationBuilder.CreateIndex(
                name: "IX_DadosListas_Dal_tid_identi",
                table: "DadosListas",
                column: "Dal_tid_identi");

            migrationBuilder.CreateIndex(
                name: "IX_DepFunc_Dfc_dpt_identi",
                table: "DepFunc",
                column: "Dfc_dpt_identi");

            migrationBuilder.CreateIndex(
                name: "IX_DepFunc_Dfc_fnc_identi",
                table: "DepFunc",
                column: "Dfc_fnc_identi");

            migrationBuilder.CreateIndex(
                name: "IX_DepFunc_Dfc_usu_identi",
                table: "DepFunc",
                column: "Dfc_usu_identi");

            migrationBuilder.CreateIndex(
                name: "IX_PreAtendimentoPlantao_Ptd_cli_identi",
                table: "PreAtendimentoPlantao",
                column: "Ptd_cli_identi");

            migrationBuilder.CreateIndex(
                name: "IX_PreAtendimentoPlantao_Ptd_usu_identi",
                table: "PreAtendimentoPlantao",
                column: "Ptd_usu_identi");

            migrationBuilder.CreateIndex(
                name: "IX_UsuLhn_Uln_lhn_identi",
                table: "UsuLhn",
                column: "Uln_lhn_identi");

            migrationBuilder.CreateIndex(
                name: "IX_UsuLhn_Uln_usu_identi",
                table: "UsuLhn",
                column: "Uln_usu_identi");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AtendimentoPlantao",
                schema: "Athena");

            migrationBuilder.DropTable(
                name: "DadosListas");

            migrationBuilder.DropTable(
                name: "DepFunc");

            migrationBuilder.DropTable(
                name: "UsuLhn");

            migrationBuilder.DropTable(
                name: "CategoriaAtendimento");

            migrationBuilder.DropTable(
                name: "PreAtendimentoPlantao");

            migrationBuilder.DropTable(
                name: "TipoDadosListas");

            migrationBuilder.DropTable(
                name: "Departamento");

            migrationBuilder.DropTable(
                name: "Funcao");

            migrationBuilder.DropTable(
                name: "Cliente");

            migrationBuilder.DropTable(
                name: "Usuario");

            migrationBuilder.DropTable(
                name: "LinhaNegocio");
        }
    }
}
