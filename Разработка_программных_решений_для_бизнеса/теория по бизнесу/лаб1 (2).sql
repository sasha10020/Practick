

Create table Country
(
код int Primary key not null,
страна nvarchar(50) not null
)
insert into Country
(
код,страна
)
values
('1','Бразилия'),
('2','Индия'),
('3','Китай')


Create table Hotel
(
код int Primary key Identity(1,1),
имя nvarchar(20) not null,
количество_звезд int not null,
код_страны int not null


Foreign Key (код_страны) References Country (код) 
On Update Cascade  
On Delete Cascade 
)
insert into Hotel
(

имя ,
количество_звезд ,
код_страны
)
values
('Апломб','3','1'),
('4сезона','5','2'),
('Фондю','2','3')

Create table HotelImage
(
код int Primary key not null,
код_отеля int not null,
источник_изображения nvarchar(100),
foreign key (код_отеля) references Hotel(код)
On Update Cascade 
On Delete Cascade 
)
insert into HotelImage
(
код,
код_отеля ,
источник_изображения )
values
('1','564','ссылка'),
('2','234','ссылка'),
('3','987','ссылка')
Create table Tour
(
код int Primary key not null,
количество_билетов int not null,
имя nvarchar(20) not null,
описание nvarchar(200) null,
цена int not null,
пред_просмотр_изоб image null,
актуально bit not null,
foreign key (код) references Hotel(код)
On Update Cascade 
On Delete Cascade 
)
insert into Tour
(
код,
количество_билетов ,
имя ,
описание,
цена ,
пред_просмотр_изоб,
актуально 
)
values
('1','3','Екатерина','что-то написано','5940',null,'1'),
('2','2','Виктория',null,'3960',null,'0'),
('3','1','Елизавета','интересное описание','1980',null,'1')
Create table Type
(
код int Primary key not null,
имя nvarchar(20) not null,
описание nvarchar(200) null,
foreign key (код) references Tour(код)
On Update Cascade 
On Delete Cascade 
)
insert into Type
(
код,
имя ,
описание 
)
values
('1','Bvz','интересное описание'),
('2','name','краткое описание'),
('3','fjdi',null)