CREATE PROCEDURE uspIsExisted
 @email nvarchar(256),
 @username nvarchar(256)
AS 
BEGIN 
  SELECT TOP 1 * FROM users WHERE email = @email OR username = @username;
END
go

