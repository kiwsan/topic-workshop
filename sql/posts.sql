create table posts
(
	id int identity
		constraint posts_pk
			primary key nonclustered,
	title nvarchar(500),
	content ntext,
	status_id int
		constraint posts_status_type_id_fk
			references status_type,
	created_date datetime,
	updated_date datetime,
	author_id int
		constraint posts_users_id_fk
			references users,
	is_published bit
)
go

