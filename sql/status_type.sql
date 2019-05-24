create table status_type
(
	id int identity
		constraint status_type_pk
			primary key nonclustered,
	name nvarchar(256)
)
go

