CREATE TABLE [Users] (
	Id int PRIMARY KEY not null identity,
	UserName varchar(255) not null,
	EmailAddress varchar(255) not null,
	HashedPassword char(60) not null -- BCrypt hash
)
