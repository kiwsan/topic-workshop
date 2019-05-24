CREATE PROCEDURE uspSignUp
  @username nvarchar(256),
  @password nvarchar(256),
  @displayName nvarchar(256),
  @email nvarchar(256)
AS
BEGIN
  INSERT INTO users (username, password, email, display_name) VALUES (@username, @password, @email, @displayName);
END
go

