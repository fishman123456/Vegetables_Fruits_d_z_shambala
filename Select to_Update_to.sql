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

-- запрос показать кол-во овощей

 select  count(*)
from Veg_Fru_t
where Type_f like 'овощь'

-- запрос показать кол-во овощей и фруктов заданного цвета 

select  count(*), Color_f
from Veg_Fru_t
where Color_f = 'черный'
Group by Color_f

-- запрос показать кол-во овощей и фруктов каждого цвета 
select  count(*), Color_f
from Veg_Fru_t
Group by Color_f

--  Показать овощи и фрукты с калорийностью менее указанной;
select *
from Veg_Fru_t v
where v.Сalories_f <10
