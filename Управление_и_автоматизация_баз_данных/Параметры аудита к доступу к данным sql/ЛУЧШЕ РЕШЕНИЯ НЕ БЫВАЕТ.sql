CREATE DATABASE Audit1
use Audit1

CREATE TABLE Employee
(EmployeeID int primary key ,
Salary decimal (18,2) not null
)

CREATE TABLE EmployeeSalaryAudit
(EmployeeID int primary key,
OldSalary decimal (18,2) not null,
NewSalary decimal (18,2) not null,
UpdatedBy nvarchar(50) not null ,
UpdatedAt nvarchar(50) not null
)

use Audit1
go
CREATE TRIGGER TR_Employee_Salary_UPDATE
ON [dbo].[Employee]
FOR UPDATE
AS BEGIN   SET NOCOUNT ON;
IF UPDATE(Salary) BEGIN
INSERT dbo.EmployeeSalaryAudit (EmployeeID, OldSalary, NewSalary, UpdatedBy, UpdatedAt) 
    SELECT i.EmployeeID, d.Salary, i.Salary, SUSER_NAME(), GETDATE() 
    FROM inserted AS i     
    JOIN deleted AS d     
    ON i.EmployeeID = d.EmployeeID;   
  END;
 END;
 GO


 
use Audit1
CREATE TABLE dbo.Employee2 (   
EmployeeID int NOT NULL PRIMARY KEY CLUSTERED,   
ManagerID int NULL,   
FirstName varchar(50) NOT NULL,   
LastName varchar(50) NOT NULL,   SysStartTime datetime2 GENERATED ALWAYS AS ROW START NOT NULL,   
SysEndTime datetime2 GENERATED ALWAYS AS ROW END NOT NULL,   
PERIOD FOR SYSTEM_TIME (SysStartTime,SysEndTime)
) WITH (SYSTEM_VERSIONING = ON (HISTORY_TABLE = dbo.EmployeeHistory)); 
GO

USE [master]
GO

CREATE SERVER AUDIT SPECIFICATION [SuperMegaAuditTheBestofTheBest_spec]
FOR SERVER AUDIT [SuperMegaAuditTheBestofTheBest]
ADD (DATABASE_ROLE_MEMBER_CHANGE_GROUP),
ADD (AUDIT_CHANGE_GROUP),
ADD (FAILED_LOGIN_GROUP),
ADD (SUCCESSFUL_LOGIN_GROUP),
ADD (DATABASE_CHANGE_GROUP)
WITH (STATE = ON)
GO

exec sp_addrole 'TestForAudit'
EXEC sp_addlogin 'Ivanik-Admin','Ivan12345','Audit1'
EXEC sp_adduser 'Ivanik-Admin','Ivanik-Admin'
EXEC sp_addrolemember 'TestForAudit','Ivanik-Admin'



SELECT * FROM sys.fn_get_audit_file ('\\support\zaporozhec.a\Исходники 20ИС3-3\SuperMegaAuditTheBestofTheBest_22DB1FED-61AF-40EB-891A-F022A24D508B_0_133114331140450000.sqlaudit',default,default);



