-- прозрачное шифрование данных
Use [master]
go


-- создаем DMK и сертификат сервера в базе данных master
create master key encryption by
password = '$tr0ng$$w0rd1'
go

Create certificate Archeology
with subject = 'Certificate to encrypt EncrypteDB3_0'

--Use [master]
go
create database encryption key
with algorithm = AES_256
Encryption by server certificate Archeology


-- узнаем состояние шифрование всех баз данных на сервере
use [master]
go
select db.[name]
,db.[is_encrypted]
, dm.[encryption_state]
, dm.[percent_complete]
, dm.[key_algorithm]
, dm.[key_length]
, db.[is_encrypted]from [sys].[databases] db
left outer join [sys].[dm_database_encryption_keys] dm
on db.[database_id] = dm.[database_id]
go





