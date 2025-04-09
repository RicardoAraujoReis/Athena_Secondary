CREATE OR ALTER VIEW BIG_NUMBERS
WITH SCHEMABINDING
AS
WITH 
ID AS (SELECT 1 FROM Athena.AtendimentoPlantao WHERE 1=1),
TotalAtendimentos AS (
    SELECT COUNT(*) AS TOTAL_ATENDIMENTOS
    FROM Athena.AtendimentoPlantao
),
TotalAtendimentosMes AS (
    SELECT COUNT(*) AS TOTAL_ATENDIMENTOS_MES
    FROM Athena.AtendimentoPlantao
    WHERE MONTH(Atd_datatd) = MONTH(CURRENT_TIMESTAMP)
),
MediaMensalAtendimentos AS (
    SELECT AVG(QUANTIDADE) AS MEDIA_MENSAL_ATENDIMENTOS
    FROM (
        SELECT COUNT(*) AS QUANTIDADE
        FROM Athena.AtendimentoPlantao
        GROUP BY YEAR(Atd_datatd), MONTH(Atd_datatd)
    ) AS MEDIA
),
ResolvidosPlantao AS (
    SELECT COUNT(*) AS RESOLVIDOS_PLANTAO
    FROM Athena.AtendimentoPlantao
    WHERE Atd_resplt = 'S'
),
IssuesAbertos AS (
    SELECT COUNT(*) AS ISSUES_ABERTOS
    FROM Athena.AtendimentoPlantao
    WHERE Atd_crijir = 'S'
),
IssuesRelacionados AS (
    SELECT COUNT(*) AS ISSUES_RELACIONADOS
    FROM Athena.AtendimentoPlantao
    WHERE Atd_jirarl = 'S'
)
SELECT 
    ID,
    total_atd.TOTAL_ATENDIMENTOS,
    total_atd_mes.TOTAL_ATENDIMENTOS_MES,
    media_mensal_atd.MEDIA_MENSAL_ATENDIMENTOS,
    resolvido_plantal.RESOLVIDOS_PLANTAO,
    issues_aberto.ISSUES_ABERTOS,
    issues_relacionados.ISSUES_RELACIONADOS
FROM 
    TotalAtendimentos total_atd,
    TotalAtendimentosMes total_atd_mes,
    MediaMensalAtendimentos media_mensal_atd,
    ResolvidosPlantao resolvido_plantal,
    IssuesAbertos issues_aberto,
    IssuesRelacionados issues_relacionados;