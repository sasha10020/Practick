

Create table Country
(
��� int Primary key not null,
������ nvarchar(50) not null
)
insert into Country
(
���,������
)
values
('1','��������'),
('2','�����'),
('3','�����')


Create table Hotel
(
��� int Primary key Identity(1,1),
��� nvarchar(20) not null,
����������_����� int not null,
���_������ int not null


Foreign Key (���_������) References Country (���) 
On Update Cascade  
On Delete Cascade 
)
insert into Hotel
(

��� ,
����������_����� ,
���_������
)
values
('������','3','1'),
('4������','5','2'),
('�����','2','3')

Create table HotelImage
(
��� int Primary key not null,
���_����� int not null,
��������_����������� nvarchar(100),
foreign key (���_�����) references Hotel(���)
On Update Cascade 
On Delete Cascade 
)
insert into HotelImage
(
���,
���_����� ,
��������_����������� )
values
('1','564','������'),
('2','234','������'),
('3','987','������')
Create table Tour
(
��� int Primary key not null,
����������_������� int not null,
��� nvarchar(20) not null,
�������� nvarchar(200) null,
���� int not null,
����_��������_���� image null,
��������� bit not null,
foreign key (���) references Hotel(���)
On Update Cascade 
On Delete Cascade 
)
insert into Tour
(
���,
����������_������� ,
��� ,
��������,
���� ,
����_��������_����,
��������� 
)
values
('1','3','���������','���-�� ��������','5940',null,'1'),
('2','2','��������',null,'3960',null,'0'),
('3','1','���������','���������� ��������','1980',null,'1')
Create table Type
(
��� int Primary key not null,
��� nvarchar(20) not null,
�������� nvarchar(200) null,
foreign key (���) references Tour(���)
On Update Cascade 
On Delete Cascade 
)
insert into Type
(
���,
��� ,
�������� 
)
values
('1','Bvz','���������� ��������'),
('2','name','������� ��������'),
('3','fjdi',null)