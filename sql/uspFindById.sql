CREATE PROCEDURE uspFindById
  @id int
AS
BEGIN
  SELECT TOP 1 * FROM users WHERE id = @id;
END
go

