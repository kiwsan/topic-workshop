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
  WHERE DisplayName LIKE '%'+@displayName+'%'
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
#### DbContext
```C#
public class DbContext : IDisposable
    {
        public string ConnectionString { get; private set; }
        public SqlConnection DbConnection { get; private set; }
        public SqlCommand DbSqlCommand { get; private set; }

        public DbContext(string connectionString)
        {
            ConnectionString = connectionString;
            DbConnection = new SqlConnection(ConnectionString);
            DbSqlCommand = DbConnection.CreateCommand();
        }

        public IEnumerable<TEntity> ExecuteProc<TEntity>(string name, params SqlParameter[] parameters)
        {
            DbSqlCommand.Parameters.Clear();
            DbSqlCommand.CommandText = name;
            DbSqlCommand.CommandType = CommandType.StoredProcedure;

            if (parameters?.Length > 0)
            {
                DbSqlCommand.Parameters.AddRange(parameters);
            }

            return Mapping<TEntity>(DbSqlCommand);
        }

        private IEnumerable<TEntity> Mapping<TEntity>(SqlCommand command)
        {
            DbConnection.Open(); //executeReader require open connection

            using (var item = command.ExecuteReader())
            {
                var items = new List<TEntity>();
                while (item.Read()) items.Add(Map<TEntity>(item));

                return items;
            }
        }

        private TEntity Map<TEntity>(IDataReader item)
        {
            var instance = Activator.CreateInstance<TEntity>();
            foreach (var property in typeof(TEntity).GetProperties())
            {
                //default property name
                var name = property.Name;
                //get property name
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    var nameAttribute = attribute as NameAttribute;

                    name = nameAttribute != null ? nameAttribute.PropertyName : property.Name;
                }

                //set value to property
                if (item.HasColumn(name) && !item.IsDBNull(item.GetOrdinal(name)))
                {
                    property.SetValue(instance, item[name]);
                }
            }

            return instance;
        }

        public void Dispose()
        {
            DbConnection.Close();

            DbConnection.Dispose();
            DbSqlCommand.Dispose();
        }
    }
    
```
#### Mapping
```C#
    public static bool HasColumn(this IDataRecord dr, string columnName)
        {
            for (var i = 0; i < dr.FieldCount; i++)
                if (dr.GetName(i).Equals(columnName, StringComparison.InvariantCultureIgnoreCase))
                    return true;
            return false;
        }
```
    
