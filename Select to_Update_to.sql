USE [Vegetables_Fruits]
GO

INSERT INTO [dbo].[Veg_Fru_t]
           ([Name_f]
           ,[Type_f]
           ,[Color_f]
           ,[Сalories_f])
     VALUES
           (<Name_f, nvarchar(30),>
           ,<Type_f, nvarchar(30),>
           ,<Color_f, nvarchar(20),>
           ,<Сalories_f, int,>)
GO


USE [Vegetables_Fruits]
GO

UPDATE [dbo].[Veg_Fru_t]
   SET [Name_f] = <Name_f, nvarchar(30),>
      ,[Type_f] = <Type_f, nvarchar(30),>
      ,[Color_f] = <Color_f, nvarchar(20),>
      ,[Сalories_f] = <Сalories_f, int,>
 WHERE <Search Conditions,,>
GO

-- запрос на максимальное значение по полю калории

select  Name_f, Type_f,Color_f,Сalories_f
from Veg_Fru_t 
order by Сalories_f desc
 OFFSET 0 ROWS
 FETCH NEXT 1 ROWS ONLY;



