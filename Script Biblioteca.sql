/****** Script for SelectTopNRows command from SSMS  ******/
SELECT TOP (1000) [Id]
      ,[DataInicio]
      ,[DataFim]
      ,[Devolvido]
      ,[IdRequisitor]
      ,[IdLivro]
  FROM [BibliotecaISLA].[dbo].[Requisicao]