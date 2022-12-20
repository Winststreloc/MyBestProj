create database BookLibrary;

use BookLibrary;

create table Authors(
	Id uniqueidentifier not null primary key,
	FirsName varchar(255),
	LastName varchar(255),
	Country varchar(255),
	BirthDate date);

create table Books(
	Id uniqueidentifier not null primary key,
	Name varchar(255),
	AuthorId uniqueidentifier foreign key references Authors(Id)on delete cascade,
	Year int);

create table Users(
	Id uniqueidentifier not null primary key,
	FirsName varchar(255),
	LastName varchar(255),
	Email varchar(255),
	BirthDate date,
	Age int,
	Address varchar,
	ExpiredDate date);

create table UserBooks(
	Id uniqueidentifier not null primary key,
	UserId uniqueidentifier foreign key references Users(Id)on delete cascade,
	BookId uniqueidentifier foreign key references Books(Id)on delete cascade,
	CreatedDate datetime);


--Добавить триггер для таблицы UserBooks, чтобы при добавлении записи в колонку 
--CreatedDate для добавленных записей записывалась текущая дата. 
--Триггер должен работать также для ситуации, когда добавляется больше чем 1 запись
--Подсказка: используйте GETDATE().

create trigger CreatedDate on UserBooks
	for insert
	as
	update UserBooks 
	set CreatedDate = GetDate()

--Добавить триггер для таблицы Users, чтобы при добавлении записи в колонку, 
--ExpiredDate для добавленных записей записывалась как текущая дата + 1 год.

create trigger ExpiredDate on Users
	for insert
	as 
	update Users set ExpiredDate = DATEADD(yy, 1, current_timestamp)

--Добавить триггер для таблицы Users, чтобы при добавлении или обновлении для этих записей 
--высчитывался возраст юзера и записывалась в колонку Age. Подсказка: используйте DATEDIFF().

create trigger AgeUser on Users
after insert, update
as
update Users set Age = DATEDIFF(year, BirthDate, CURRENT_TIMESTAMP)

--Создайте ограничение на уникальность на колонки (UserId, BookId), 
--чтобы не было возможности у юзера взять две одинаковые книги за раз. 
--Также без этого ограничения M-to-M отношение не будет валидно.

ALTER TABLE UserBooks  
ADD CONSTRAINT AK_UserBooks UNIQUE (UserId, BookId);   

--Добавить INSERT-скрипты, которые заполнят таблицы правдоподобными, 
--связанными данными. При заполнении связанных таблиц используйте
--подзапросы для получения значений ключей.

insert into Authors
values('c37a07b6-b7aa-40d9-9f7a-27e2c5bba4e5', 'Mark','Krajcik', 'Belgium', '1983-08-22');
insert into Authors
values('ff6586b9-f356-4bce-8224-3a3ec43cabc9', 'Misty', 'Pokich', 'Russian', '1944-12-12');
insert into Authors
values('a5ae0f3e-ffe2-46f0-a31a-05384f56f42e', 'Jack', 'Stroman', 'Germany', '1965-08-16');

insert into Books
values('b1f70061-fe86-4915-a1b7-645a2cd99159', 'Who want to be millionire', (select Authors.Id from Authors
where Authors.FirsName = 'Mark'), 1999);
insert into Books
values('6b08f570-750f-4227-8625-44404c321983', 'I want to be millionire', (select Authors.Id from Authors
where Authors.FirsName = 'Misty'), 2002);
insert into Books
values('7b69ac14-eb48-4349-a375-9ebfa323fde4', 'Well done', (select Authors.Id from Authors
where Authors.FirsName = 'Jack'), 2019);

insert into Users(Id, FirsName, LastName, Email, BirthDate, Address)
values('53aa2f16-88c0-4ca3-98c7-73a42a8e98e1', 'Clara', 'Moen', 'moen@gmail.com', '1986-03-14', 'New-York');
insert into Users(Id, FirsName, LastName, Email, BirthDate, Address)
values('f4bdf18b-21cb-4675-9f60-d6058f5e8fc4', 'Sheldon', 'Gowell', 'gowel@gmail.com', '1991-03-14', 'Berlin');
insert into Users(Id, FirsName, LastName, Email, BirthDate, Address)
values('1a1f01cb-2cbf-4b5b-8bdf-914d39d4453c', 'Ricky', 'Thompson', 'thompson@gmail.com', '1985-03-14', 'Los-Angeles');

insert into UserBooks(Id, BookId, UserId)
values('cfd08876-dbf6-4a73-b390-6c6c175188bb', 
		(select Id from Books 
		where Books.Name = 'I want to be millionire'), 
		(select Id from Users 
		where Users.FirsName = 'Clara'));
insert into UserBooks(Id, BookId, UserId)
values('f602a24d-da1b-4854-9749-0e931cee58f6', 
		(select Id from Books 
		where Books.Name = 'Who want to be millionire'), 
		(select Id from Users 
		where Users.FirsName = 'Ricky'));
insert into UserBooks(Id, BookId, UserId)
values('95c872b0-8025-4bd0-bed7-38eb9ee395b5', 
		(select Id from Books 
		where Books.Name = 'Well done'), 
		(select Id from Users 
		where Users.FirsName = 'Sheldon'));

--Добавить представление UsersInfo, которое будет выводить нам пользователей и взятые ими книги. 
--Помните, что юзер может и не иметь книг, но он тоже должен быть включён в выборку.
--Представление должно содержать следующие колонки:
--UserId
--UserFullName
--UserAge
--AuthorFullName
--BookName
--BookYear

create view UserInfo as
select Users.Id as UserId,
		Users.FirsName + ' ' + Users.LastName as UserFullName,
		Users.Age as UserAge,
		Authors.FirsName + ' ' + Authors.LastName as AuthorFullName,
		Books.Name as BookName,
		Books.Year as BooksYear
from Users inner join UserBooks on Users.Id = UserBooks.UserId
inner join Books on UserBooks.BookId = Books.Id
inner join Authors on Authors.Id = Books.AuthorId

--Добавить хранимую процедуру DeleteUsersByExpiredDate, которая будет удалять юзеров,
--у которых ExpiredDate меньше текущей даты. Учтите следующие требования:
--1.Если у юзера всё ещё есть книги, то вместо удаления нужно напечатать сообщение, 
--что такой-то юзер всё ещё имеет книги. Подсказка: для этого можете использовать созданное 
--представление и команду PRINT.
--2.Если у юзера нет книг, то просто удаляем его.

create procedure DeleteUsersByExpiredDate as

	if not exists(select top(1) 1 from Users join UserBooks on Users.Id = UserBooks.BookId )
		print 'Задолжность по книгам'
	else 
		delete from Users join UserBooks on Users.Id != UserBooks.BookId
		where join UserBooks on Users.Id = UserBooks.BookId

exec DeleteUsersByExpiredDate

--Процедура не сделана 
