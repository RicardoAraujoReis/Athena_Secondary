CREATE OR ALTER PROCEDURE ATUALIZA_PAINEL_GERAL_BIGNUMBERS
AS
BEGIN
    UPDATE Athena.PainelGeralBigNumbers
	SET
	   Icon = '@Icons.Material.Filled.ShowChart',
	   Value = (SELECT COUNT(*) AS TOTAL_ATENDIMENTOS FROM Athena.AtendimentoPlantao),
	   DataAtualizacao = CURRENT_TIMESTAMP
	WHERE 1=1
	   AND Label = 'Total de Atendimentos';

	UPDATE Athena.PainelGeralBigNumbers
	SET
	   Icon = '@Icons.Material.Filled.People',
	   Value = (SELECT COUNT(*) AS TOTAL_ATENDIMENTOS_MES FROM Athena.AtendimentoPlantao WHERE MONTH(Atd_datatd) = MONTH(CURRENT_TIMESTAMP)),
	   DataAtualizacao = CURRENT_TIMESTAMP
	WHERE 1=1
	   AND Label = 'Total de Atendimentos / Mês';

	UPDATE Athena.PainelGeralBigNumbers
	SET
	   Icon = '@Icons.Material.Filled.ShoppingCart',
	   Value = (SELECT AVG(QUANTIDADE) AS MEDIA_MENSAL_ATENDIMENTOS FROM (
						SELECT COUNT(*) AS QUANTIDADE
						FROM Athena.AtendimentoPlantao
						GROUP BY YEAR(Atd_datatd), MONTH(Atd_datatd)
					) AS MEDIA),
	   DataAtualizacao = CURRENT_TIMESTAMP
	WHERE 1=1
	   AND Label = 'Média Mensal';

	UPDATE Athena.PainelGeralBigNumbers
	SET
	   Icon = '@Icons.Material.Filled.AttachMoney',
	   Value = (SELECT COUNT(*) AS RESOLVIDOS_PLANTAO FROM Athena.AtendimentoPlantao WHERE Atd_resplt = 'S'),
	   DataAtualizacao = CURRENT_TIMESTAMP
	WHERE 1=1
	   AND Label = 'Resolvidos no Plantão';

	UPDATE Athena.PainelGeralBigNumbers
	SET
	   Icon = '@Icons.Material.Filled.ThumbUp',
	   Value = (SELECT COUNT(*) AS ISSUES_ABERTOS FROM Athena.AtendimentoPlantao WHERE Atd_crijir = 'S'),
	   DataAtualizacao = CURRENT_TIMESTAMP
	WHERE 1=1
	   AND Label = 'Issues Abertos';

	UPDATE Athena.PainelGeralBigNumbers
	SET
	   Icon = '@Icons.Material.Filled.ThumbUp',
	   Value = (SELECT COUNT(*) AS ISSUES_RELACIONADOS FROM Athena.AtendimentoPlantao WHERE Atd_jirarl = 'S'),
	   DataAtualizacao = CURRENT_TIMESTAMP
	WHERE 1=1
	   AND Label = 'Issues relacionados';
END;
