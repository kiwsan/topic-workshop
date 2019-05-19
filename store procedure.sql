SELECT *
FROM users

CREATE PROCEDURE uspAdd
  @username nvarchar(250),
  @password nvarchar(250),
  @email nvarchar(250),
  @displayName nvarchar(250)
AS
BEGIN
  INSERT INTO users (username, password, email, display_name) VALUES (@username, @password, @email, @displayName);
END

CREATE PROCEDURE uspFindById
  @id int
AS
BEGIN
  SELECT TOP 1 * FROM users WHERE id = @id;
END

CREATE PROCEDURE uspSignIn
  @username nvarchar(256),
  @password nvarchar(256)
AS
BEGIN
  SELECT TOP 1 * FROM users WHERE username = @username AND password = @password;
END

ALTER PROCEDURE postpGetAll
AS
BEGIN
  SELECT * FROM posts WHERE is_published = 1;
END

ALTER PROCEDURE postpAdd
  @title nvarchar(256),
  @content nvarchar(256),
  @authorId int,
  @statusId int,
  @createdDate DATETIME,
  @updatedDate DATETIME,
  @isPublished bit
AS
BEGIN
  INSERT INTO posts (title, content, status_id, created_date, updated_date, author_id, is_published)
  VALUES (@title, @content, @statusId, @createdDate, @updatedDate, @authorId, @isPublished);
END

CREATE PROCEDURE postpFindById
 @id int
AS
BEGIN
  SELECT TOP 1 * FROM posts WHERE id = @id;
END

CREATE PROCEDURE uspSignUp
  @username nvarchar(256),
  @password nvarchar(256),
  @displayName nvarchar(256),
  @email nvarchar(256)
AS
BEGIN
  INSERT INTO users (username, password, email, display_name) VALUES (@username, @password, @email, @displayName);
END

CREATE PROCEDURE uspIsExisted
 @email nvarchar(256),
 @username nvarchar(256)
AS
BEGIN
  SELECT TOP 1 * FROM users WHERE email = @email OR username = @username;
END

CREATE PROCEDURE commentpFindByPostId
  @postId int
AS
BEGIN
  SELECT TOP 1 * FROM comments WHERE post_id = @postId;
END

CREATE PROCEDURE commentpAdd
  @content TEXT,
  @authorId int,
  @statusId int,
  @url nvarchar(256),
  @postId int,
  @createdDate DATETIME,
  @updatedDate DATETIME
AS
BEGIN
  INSERT INTO comments (content, status_id, created_date, updated_date, author_id, url, post_id)
  VALUES (@content, @statusId, @createdDate, @updatedDate, @authorId, @url, @postId);
END

CREATE PROCEDURE postpIsPublished
  @id int,
  @isPublished bit
AS
BEGIN
  UPDATE posts SET is_published = @isPublished WHERE id = @id;
END
