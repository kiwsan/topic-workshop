CREATE PROCEDURE postpIsPublished
  @id int,
  @isPublished bit
AS
BEGIN
  UPDATE posts SET is_published = @isPublished WHERE id = @id;
END
go

