CREATE PROCEDURE postpAdd
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
go

