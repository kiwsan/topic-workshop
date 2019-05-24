CREATE PROCEDURE postpFindById
 @id int
AS 
BEGIN 
  SELECT TOP 1 * FROM posts WHERE id = @id;
END
go

