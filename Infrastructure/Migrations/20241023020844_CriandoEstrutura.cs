using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class CriandoEstrutura : Migration
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
                    cat_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cat_catpai = table.Column<int>(type: "int", maxLength: 10, nullable: false, comment: "ID da Categoria referência no nível anterior"),
                    cat_nivel = table.Column<int>(type: "int", maxLength: 1, nullable: false, comment: "Nível da Categoria"),
                    cat_valor = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false, comment: "Valor da Categoria"),
                    cat_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    cat_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    cat_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    cat_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cat_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriaAtendimento", x => x.cat_identi);
                });

            migrationBuilder.CreateTable(
                name: "Departamento",
                columns: table => new
                {
                    dpt_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dpt_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome do Departamento"),
                    dpt_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Indica se o Departamento está ativo ou não (S - SIM / N - NÃO)"),
                    dpt_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    dpt_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    dpt_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    dpt_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dpt_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departamento", x => x.dpt_identi);
                });

            migrationBuilder.CreateTable(
                name: "Funcao",
                columns: table => new
                {
                    fnc_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    fnc_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Descrição da Função"),
                    fnc_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Indica se a Função está ativa ou não (S - SIM / N - NÃO)"),
                    fnc_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    fnc_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    fnc_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    fnc_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    fnc_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Funcao", x => x.fnc_identi);
                });

            migrationBuilder.CreateTable(
                name: "LinhaNegocio",
                columns: table => new
                {
                    lhn_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    lhn_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Descrição da Linha de Negócio"),
                    lhn_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Indica se a Linha de Negócio está ativa ou não (S - SIM / N - NÃO)"),
                    lhn_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    lhn_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    lhn_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    lhn_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    lhn_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LinhaNegocio", x => x.lhn_identi);
                });

            migrationBuilder.CreateTable(
                name: "TipoDadosListas",
                columns: table => new
                {
                    tid_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    tid_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Descrição do tipo de dados de listas"),
                    tid_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    tid_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tid_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    tid_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    tid_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDadosListas", x => x.tid_identi);
                });

            migrationBuilder.CreateTable(
                name: "Usuario",
                columns: table => new
                {
                    usu_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    usu_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Nome completo do usuário"),
                    usu_login = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Login do usuário"),
                    usu_senha = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: false, comment: "Senha do usuário"),
                    usu_email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "E-mail do usuário"),
                    usu_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Indica se o usuário está ativo ou não (S - SIM / N - NÃO)"),
                    usu_status = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Indica se o usuário está bloqueado (S - SIM / N - NÃO)"),
                    usu_master = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Indica se o usuário é super usuário (S - SIM / N - NÃO)"),
                    usu_tipusu = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Tipo do usuário (N1 - 0, N2 - 1, ADM - 2)"),
                    usu_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    usu_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    usu_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    usu_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    usu_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuario", x => x.usu_identi);
                });

            migrationBuilder.CreateTable(
                name: "Cliente",
                columns: table => new
                {
                    cli_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cli_descri = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Descrição do Cliente"),
                    cli_ativo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Indica se o Cliente está ativo ou não (S - SIM / N - NÃO)"),
                    cli_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    cli_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    cli_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    cli_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cli_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    cli_lhn_identi = table.Column<int>(type: "int", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cliente", x => x.cli_identi);
                    table.ForeignKey(
                        name: "cli_lhn_identi",
                        column: x => x.cli_lhn_identi,
                        principalTable: "LinhaNegocio",
                        principalColumn: "lhn_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DadosListas",
                columns: table => new
                {
                    dal_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dal_tid_identi = table.Column<int>(type: "int", nullable: false),
                    dal_valor = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false, comment: "Valor a ser exibido no campo de lista"),
                    dal_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    dal_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dal_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dal_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    dal_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DadosListas", x => x.dal_identi);
                    table.ForeignKey(
                        name: "dal_tid_identi",
                        column: x => x.dal_tid_identi,
                        principalTable: "TipoDadosListas",
                        principalColumn: "tid_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "DepFunc",
                columns: table => new
                {
                    dfc_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    dfc_dpt_identi = table.Column<int>(type: "int", nullable: false),
                    dfc_fnc_identi = table.Column<int>(type: "int", nullable: false),
                    dfc_usu_identi = table.Column<int>(type: "int", nullable: false),
                    dfc_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    dfc_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    dfc_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    dfc_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    dfc_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepFunc", x => x.dfc_identi);
                    table.ForeignKey(
                        name: "dfc_dpt_identi",
                        column: x => x.dfc_dpt_identi,
                        principalTable: "Departamento",
                        principalColumn: "dpt_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "dfc_fnc_identi",
                        column: x => x.dfc_fnc_identi,
                        principalTable: "Funcao",
                        principalColumn: "fnc_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "dfc_usu_identi",
                        column: x => x.dfc_usu_identi,
                        principalTable: "Usuario",
                        principalColumn: "usu_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuLhn",
                columns: table => new
                {
                    uln_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    uln_usu_identi = table.Column<int>(type: "int", nullable: false),
                    uln_lhn_identi = table.Column<int>(type: "int", nullable: false),
                    uln_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    uln_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    uln_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    uln_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    uln_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuLhn", x => x.uln_identi);
                    table.ForeignKey(
                        name: "uln_lhn_identi",
                        column: x => x.uln_lhn_identi,
                        principalTable: "LinhaNegocio",
                        principalColumn: "lhn_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "uln_usu_identi",
                        column: x => x.uln_usu_identi,
                        principalTable: "Usuario",
                        principalColumn: "usu_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "PreAtendimentoPlantao",
                columns: table => new
                {
                    ptd_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ptd_datptd = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data do Pré Atendimento"),
                    ptd_usu_identi = table.Column<int>(type: "int", nullable: false),
                    ptd_cli_identi = table.Column<int>(type: "int", nullable: false),
                    ptd_tipptd = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Tipo do Pré Atendimento (DÚVIDA / SOLICITAÇÃO / PROBLEMA)"),
                    ptd_critic = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Criticidade do Tema (B - BAIXO / M - MÉDIO / A - ALTO / C - CRÍTICO)"),
                    ptd_resumo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Resumo do Tema"),
                    ptd_numcha = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Número do chamado"),
                    ptd_jirarl = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Existe Jira relacionado? (S - SIM / N - NÃO)"),
                    ptd_numjir = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Número do Jira"),
                    ptd_diagn1 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Análise realizada pelo N1"),
                    ptd_status = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: true, comment: "Status do Pré Atendimento"),
                    ptd_reton2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Resposta do N2"),
                    ptd_observ = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Observação"),
                    ptd_nomal1 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Nome do analista N1 caso não seja o mesmo usuário a preencher o formulário"),
                    ptd_numatd = table.Column<int>(type: "int", maxLength: 10, nullable: false, comment: "Número do Atendimento gerado (se houver)"),
                    ptd_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    ptd_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ptd_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ptd_usucri = table.Column<int>(type: "int", nullable: false),
                    ptd_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PreAtendimentoPlantao", x => x.ptd_identi);
                    table.ForeignKey(
                        name: "ptd_cli_identi",
                        column: x => x.ptd_cli_identi,
                        principalTable: "Cliente",
                        principalColumn: "cli_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "ptd_usu_identi",
                        column: x => x.ptd_usu_identi,
                        principalTable: "Usuario",
                        principalColumn: "usu_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AtendimentoPlantao",
                schema: "Athena",
                columns: table => new
                {
                    atd_identi = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    atd_usu_identi = table.Column<int>(type: "int", nullable: false),
                    atd_ptd_identi = table.Column<int>(type: "int", nullable: false),
                    atd_cli_identi = table.Column<int>(type: "int", nullable: false),
                    atd_tipatd = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Tipo do Atendimento (DÚVIDA / SOLICITAÇÃO / PROBLEMA)"),
                    atd_cat_identi = table.Column<int>(type: "int", nullable: false),
                    atd_resumo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Resumo do Tema"),
                    atd_respn2 = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false, comment: "Resposta do N2 ao Tema"),
                    atd_crijir = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Indica se foi criado Jira a partir deste Atendimento (1 - SIM / 0 - NÃO)"),
                    atd_issue = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Número do JIRA"),
                    atd_critic = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Criticidade do Tema (B - BAIXO / M - MÉDIO / A - ALTO / C - CRÍTICO)"),
                    atd_resplt = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Tema resolvido no mesmo plantão? (1 - SIM / 0 - NÃO)"),
                    atd_ren1hm = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Resolveria se o N1 tivesse testado em HOM? (1 - SIM / 0 - NÃO)"),
                    atd_resn1 = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: false, comment: "Resolveria N1? (1 - SIM / 0 - NÃO)"),
                    atd_evoln1 = table.Column<string>(type: "nvarchar(65)", maxLength: 65, nullable: true, comment: "Tema em que o N1 precisa evoluir"),
                    atd_observ = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true, comment: "Observação"),
                    atd_usubdd = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    atd_datatd = table.Column<DateTime>(type: "datetime2", nullable: false, comment: "Data do Plantão"),
                    atd_nomal2 = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true, comment: "Nome do analista N2 caso não seja o mesmo usuário a preencher o formulário"),
                    atd_status = table.Column<string>(type: "nvarchar(35)", maxLength: 35, nullable: false, comment: "Status do Atendimento"),
                    atd_usucri = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    atd_usualt = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    atd_datcri = table.Column<DateTime>(type: "datetime2", nullable: false),
                    atd_datalt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AtendimentoPlantao", x => x.atd_identi);
                    table.ForeignKey(
                        name: "atd_cat_identi",
                        column: x => x.atd_cat_identi,
                        principalTable: "CategoriaAtendimento",
                        principalColumn: "cat_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "atd_cli_identi",
                        column: x => x.atd_cli_identi,
                        principalTable: "Cliente",
                        principalColumn: "cli_identi",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "atd_ptd_identi",
                        column: x => x.atd_ptd_identi,
                        principalTable: "PreAtendimentoPlantao",
                        principalColumn: "ptd_identi");
                    table.ForeignKey(
                        name: "atd_usu_identi",
                        column: x => x.atd_usu_identi,
                        principalTable: "Usuario",
                        principalColumn: "usu_identi",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_atd_cat_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "atd_cat_identi");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_atd_cli_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "atd_cli_identi");

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_atd_ptd_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "atd_ptd_identi",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AtendimentoPlantao_atd_usu_identi",
                schema: "Athena",
                table: "AtendimentoPlantao",
                column: "atd_usu_identi");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_cli_lhn_identi",
                table: "Cliente",
                column: "cli_lhn_identi");

            migrationBuilder.CreateIndex(
                name: "IX_DadosListas_dal_tid_identi",
                table: "DadosListas",
                column: "dal_tid_identi");

            migrationBuilder.CreateIndex(
                name: "IX_DepFunc_dfc_dpt_identi",
                table: "DepFunc",
                column: "dfc_dpt_identi");

            migrationBuilder.CreateIndex(
                name: "IX_DepFunc_dfc_fnc_identi",
                table: "DepFunc",
                column: "dfc_fnc_identi");

            migrationBuilder.CreateIndex(
                name: "IX_DepFunc_dfc_usu_identi",
                table: "DepFunc",
                column: "dfc_usu_identi");

            migrationBuilder.CreateIndex(
                name: "IX_PreAtendimentoPlantao_ptd_cli_identi",
                table: "PreAtendimentoPlantao",
                column: "ptd_cli_identi");

            migrationBuilder.CreateIndex(
                name: "IX_PreAtendimentoPlantao_ptd_usu_identi",
                table: "PreAtendimentoPlantao",
                column: "ptd_usu_identi");

            migrationBuilder.CreateIndex(
                name: "IX_UsuLhn_uln_lhn_identi",
                table: "UsuLhn",
                column: "uln_lhn_identi");

            migrationBuilder.CreateIndex(
                name: "IX_UsuLhn_uln_usu_identi",
                table: "UsuLhn",
                column: "uln_usu_identi");
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
