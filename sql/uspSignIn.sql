CREATE PROCEDURE uspSignIn
  @username nvarchar(256),
  @password nvarchar(256)
AS
BEGIN
  SELECT TOP 1 * FROM users WHERE username = @username AND password = @password;
END
go

