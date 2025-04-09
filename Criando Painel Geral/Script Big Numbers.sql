--TOTAL ATENDIMENTOS
SELECT 
   COUNT(*)   
   FROM 
      Athena.AtendimentoPlantao;

--TOTAL DE ATENDIMENTOS DO MÊS
SELECT
   COUNT(*)
   FROM
      Athena.AtendimentoPlantao
   WHERE 1=1
      AND MONTH(Atd_datatd) = MONTH(CURRENT_TIMESTAMP);

--MEDIA MENSAL DOS ATENDIMENTOS
SELECT AVG(QUANTIDADE) FROM 
(
	SELECT 
	   COUNT(*) AS QUANTIDADE   
	   FROM 
		  Athena.AtendimentoPlantao
	   GROUP BY YEAR(Atd_datatd), MONTH(Atd_datatd)
) AS MEDIA;

--RESOLVIDOS NO PLANTÃO
SELECT
   COUNT(*)
   FROM
      Athena.AtendimentoPlantao
   WHERE 1=1
      AND Atd_resplt = 'S';

--ISSUES ABERTOS
SELECT
   COUNT(*)
   FROM
      Athena.AtendimentoPlantao
   WHERE 1=1
      AND Atd_crijir = 'S';

--ISSUES RELACIONADOS
SELECT
   COUNT(*)
   FROM
      Athena.AtendimentoPlantao
   WHERE 1=1
      AND Atd_jirarl = 'S';