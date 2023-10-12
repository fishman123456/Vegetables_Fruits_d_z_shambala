USE [Vegetables_Fruits]
GO

INSERT INTO [dbo].[Veg_Fru_t]
           ([Name_f]
           ,[Type_f]
           ,[Color_f]
           ,[�alories_f])
     VALUES
           (<Name_f, nvarchar(30),>
           ,<Type_f, nvarchar(30),>
           ,<Color_f, nvarchar(20),>
           ,<�alories_f, int,>)
GO


USE [Vegetables_Fruits]
GO

UPDATE [dbo].[Veg_Fru_t]
   SET [Name_f] = <Name_f, nvarchar(30),>
      ,[Type_f] = <Type_f, nvarchar(30),>
      ,[Color_f] = <Color_f, nvarchar(20),>
      ,[�alories_f] = <�alories_f, int,>
 WHERE <Search Conditions,,>
GO

-- ������ �� ������������ �������� �� ���� �������

select  Name_f, Type_f,Color_f,�alories_f
from Veg_Fru_t 
order by �alories_f desc
 OFFSET 0 ROWS
 FETCH NEXT 1 ROWS ONLY;

-- ������ �������� ���-�� ������

 select  count(*)
from Veg_Fru_t
where Type_f like '�����'

-- ������ �������� ���-�� ������ � ������� ��������� ����� 

select  count(*), Color_f
from Veg_Fru_t
where Color_f = '������'
Group by Color_f

-- ������ �������� ���-�� ������ � ������� ������� ����� 
select  count(*), Color_f
from Veg_Fru_t
Group by Color_f

--  �������� ����� � ������ � ������������� ����� ���������;
select *
from Veg_Fru_t v
where v.�alories_f <10
