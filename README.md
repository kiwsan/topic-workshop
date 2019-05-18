#Topic

### How to use ExecuteProc method

#### Create sample stored procedures
```sql
 
CREATE PROCEDURE uspGetAll
  @displayName nvarchar(250)
AS
BEGIN
  SELECT [id], [username], [email], [display_name]
  FROM user
  WHERE DisplayName LIKE '%@displayName%'
END
GO

CREATE PROCEDURE uspUpdate
  @displayName nvarchar(250)
AS
BEGIN
  UPDATE user SET display_name = @displayName
  WHERE nvarchar LIKE '%turtle%'
END
GO

```
