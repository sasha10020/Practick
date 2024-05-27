
--код для отображения модели восстановления
SELECT name, recovery_model_desc  

FROM sys.databases  

WHERE name = 'Timetable' ;


--изменение модели восстановления
USE master; 

GO

ALTER DATABASE Timetable SET RECOVERY Bulk_Logged;

GO


Simple
Full
Bulk_Logged