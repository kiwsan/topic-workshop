CREATE PROCEDURE postpGetAll
AS
BEGIN
  SELECT * FROM posts WHERE is_published = 1;
END
go

