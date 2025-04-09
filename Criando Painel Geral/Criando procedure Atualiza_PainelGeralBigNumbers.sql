CREATE OR ALTER PROCEDURE ATUALIZA_PAINEL_GERAL_BIGNUMBERS
AS
BEGIN
    INSERT INTO [Athena].[PainelGeralBigNumbers]
           ([Icon]
           ,[Value]
           ,[Label]
           ,[DataAtualizacao])
     VALUES
           (
			   ('@Icons.Material.Filled.ShowChart'),
			   (SELECT COUNT(*) AS TOTAL_ATENDIMENTOS FROM Athena.AtendimentoPlantao),
			   ('Total de Atendimentos'),
			   (CURRENT_TIMESTAMP)
		   );

INSERT INTO [Athena].[PainelGeralBigNumbers]
           ([Icon]
           ,[Value]
           ,[Label]
           ,[DataAtualizacao])
     VALUES
           (
			   ('@Icons.Material.Filled.People'),
			   (SELECT COUNT(*) AS TOTAL_ATENDIMENTOS_MES FROM Athena.AtendimentoPlantao WHERE MONTH(Atd_datatd) = MONTH(CURRENT_TIMESTAMP)),
			   ('Total de Atendimentos / Mês'),
			   (CURRENT_TIMESTAMP)
		   );

INSERT INTO [Athena].[PainelGeralBigNumbers]
           ([Icon]
           ,[Value]
           ,[Label]
           ,[DataAtualizacao])
     VALUES
           (
			   ('@Icons.Material.Filled.ShoppingCart'),
			   (SELECT AVG(QUANTIDADE) AS MEDIA_MENSAL_ATENDIMENTOS FROM (
					SELECT COUNT(*) AS QUANTIDADE
					FROM Athena.AtendimentoPlantao
					GROUP BY YEAR(Atd_datatd), MONTH(Atd_datatd)
				) AS MEDIA),
			   ('Média Mensal'),
			   (CURRENT_TIMESTAMP)
		   );

INSERT INTO [Athena].[PainelGeralBigNumbers]
           ([Icon]
           ,[Value]
           ,[Label]
           ,[DataAtualizacao])
     VALUES
           (
			   ('@Icons.Material.Filled.AttachMoney'),
			   (SELECT COUNT(*) AS RESOLVIDOS_PLANTAO FROM Athena.AtendimentoPlantao WHERE Atd_resplt = 'S'),
			   ('Resolvidos no Plantão'),
			   (CURRENT_TIMESTAMP)
		   );

INSERT INTO [Athena].[PainelGeralBigNumbers]
           ([Icon]
           ,[Value]
           ,[Label]
           ,[DataAtualizacao])
     VALUES
           (
			   ('@Icons.Material.Filled.ThumbUp'),
			   (SELECT COUNT(*) AS ISSUES_ABERTOS FROM Athena.AtendimentoPlantao WHERE Atd_crijir = 'S'),
			   ('Issues Abertos'),
			   (CURRENT_TIMESTAMP)
		   );

INSERT INTO [Athena].[PainelGeralBigNumbers]
           ([Icon]
           ,[Value]
           ,[Label]
           ,[DataAtualizacao])
     VALUES
           (
			   ('@Icons.Material.Filled.ThumbUp'),
			   (SELECT COUNT(*) AS ISSUES_RELACIONADOS FROM Athena.AtendimentoPlantao WHERE Atd_jirarl = 'S'),
			   ('Issues relacionados'),
			   (CURRENT_TIMESTAMP)
		   );
END;
