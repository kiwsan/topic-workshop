using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Topic.Extentions;
using Topic.Utils;

namespace Topic.Data
{
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
            if (DbConnection.State == ConnectionState.Closed)
            {
                DbConnection.Open(); //executeReader require open connection
            }

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
            if (DbConnection.State == ConnectionState.Open)
            {
                DbConnection.Close();
            }

            DbConnection.Dispose();
            DbSqlCommand.Dispose();
        }
    }
}