create table users
(
	id int identity
		constraint users_pk
			primary key nonclustered,
	username nvarchar(250),
	password nvarchar(256),
	email nvarchar(126),
	display_name nvarchar(256)
)
go

create unique index users_username_uindex
	on users (username)
go

create unique index users_email_uindex
	on users (email)
go

