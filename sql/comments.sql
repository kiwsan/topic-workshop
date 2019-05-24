create table comments
(
	id int identity
		constraint comments_pk
			primary key nonclustered,
	content text,
	status_id int
		constraint comments_status_type_id_fk
			references status_type,
	created_date datetime,
	updated_date datetime,
	author_id int,
	url nvarchar(256),
	post_id int
		constraint comments_posts_id_fk
			references posts
)
go

