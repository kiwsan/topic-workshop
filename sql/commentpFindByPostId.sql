CREATE PROCEDURE commentpFindByPostId
  @postId int
AS
BEGIN
  SELECT TOP 1 * FROM comments WHERE post_id = @postId;
END
go

