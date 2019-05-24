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
go

