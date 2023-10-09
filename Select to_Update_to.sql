USE [Vegetables_Fruits]
GO

INSERT INTO [dbo].[Veg_Fru_t]
           ([Name_f]
           ,[Type_f]
           ,[Color_f]
           ,[Ñalories_f])
     VALUES
           (<Name_f, nvarchar(30),>
           ,<Type_f, nvarchar(30),>
           ,<Color_f, nvarchar(20),>
           ,<Ñalories_f, int,>)
GO


USE [Vegetables_Fruits]
GO

UPDATE [dbo].[Veg_Fru_t]
   SET [Name_f] = <Name_f, nvarchar(30),>
      ,[Type_f] = <Type_f, nvarchar(30),>
      ,[Color_f] = <Color_f, nvarchar(20),>
      ,[Ñalories_f] = <Ñalories_f, int,>
 WHERE <Search Conditions,,>
GO
