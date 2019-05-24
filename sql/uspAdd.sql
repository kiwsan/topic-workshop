CREATE PROCEDURE uspAdd
  @username nvarchar(250),
  @password nvarchar(250),
  @email nvarchar(250),
  @displayName nvarchar(250)
AS
BEGIN
  INSERT INTO users (username, password, email, display_name) VALUES (@username, @password, @email, @displayName);
END
go

