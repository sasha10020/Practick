Create Table BOOKS    
(  
 name_book varchar(200) not null,  
 date_book date not null  
)  
  
Create Table AUTHORS   
(  
 name_a varchar(100) not null,  
 last_name varchar(100) not null  
)  
Create Table DELIVERIES   
(  
 what varchar(100) not null,  
 date_w date not null  
) 
  
  
EXEC sp_addrole 'LIBRAR'  
  
EXEC sp_addrole 'READER' 

GRANT DELETE, INSERT, UPDATE, SELECT ON BOOKS TO LIBRAR

GRANT DELETE, INSERT, UPDATE, SELECT ON AUTHORS TO LIBRAR

GRANT DELETE, INSERT, UPDATE, SELECT ON DELIVERIES TO LIBRAR

GRANT EXECUTE TO LIBRAR


GRANT SELECT ON BOOKS TO READER

GRANT SELECT ON AUTHORS TO READER

GRANT SELECT ON DELIVERIES TO READER
  
  
Exec sp_addlogin 'Ivanov_Lib','Ivanov', 'Demo_DataBase'

use Demo_DataBase

Exec sp_adduser 'Ivanov_Lib','Ivanov_Lib'

EXEC sp_addrolemember 'LIBRAR', 'Ivanov_Lib'


 
Exec sp_addlogin 'Petrov_Read','Petrov', 'Demo_DataBase'

Exec sp_adduser 'Petrov_Read','Petrov_Read'

EXEC sp_addrolemember 'READER', 'Petrov_Read'

EXEC sp_droprolemember 'READER', 'Petrov_Read'


  
ALTER LOGIN Lizka  
WITH CHECK_POLICY = OFF, CHECK_EXPIRATION = OFF;  
  
  
ALTER LOGIN Petrov_Read  
With PASSWORD = '12345';  
  
Alter Login be Disable;  
Drop Login Petrov_Read;  