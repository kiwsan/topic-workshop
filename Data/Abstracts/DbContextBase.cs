using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Data.Extensions;
using Data.Utils;

namespace Data.Abstracts
{
    public abstract class DbContextBase : IDisposable
    {
        public string ConnectionString { get; private set; }
        public SqlConnection DbSqlConnection { get; private set; }
        public SqlCommand DbSqlCommand { get; private set; }

        public DbContextBase(string connectionString)
        {
            ConnectionString = connectionString;
            DbSqlConnection = new SqlConnection(ConnectionString);
            DbSqlCommand = DbSqlConnection.CreateCommand();
        }

        protected abstract IEnumerable<TEntity> ToMap<TEntity>(SqlCommand sqlCommand);

        //map property
        protected TEntity MapToItem<TEntity>(IDataRecord record)
        {
            //create instance
            var instance = Activator.CreateInstance<TEntity>();

            foreach (var property in typeof(TEntity).GetProperties())
            {
                //default name
                var name = property.Name;
                //custom attribute
                foreach (var attribute in property.GetCustomAttributes(true))
                {
                    var customAttribute = attribute as NameAttribute;

                    name = customAttribute == null ? property.Name : customAttribute.Name;
                }

                //set value to property
                if (record.HasColumn(name) && !record.IsDBNull(record.GetOrdinal(name)))
                {
                    property.SetValue(instance, record[name]);
                }
            }

            return instance;
        }

        //execute store procedure
        public IEnumerable<TEntity> ExecuteProc<TEntity>(string name, params SqlParameter[] parameters)
        {
            //setting command
            DbSqlCommand.Parameters.Clear();
            DbSqlCommand.CommandText = name;
            DbSqlCommand.CommandType = CommandType.StoredProcedure;

            //add params
            if (parameters?.Length > 0)
            {
                DbSqlCommand.Parameters.AddRange(parameters);
            }

            //map to object list
            return ToMap<TEntity>(DbSqlCommand);
        }

        public void Dispose()
        {
            if (DbSqlConnection.State == ConnectionState.Open)
            {
                DbSqlConnection.Close();
            }

            DbSqlCommand.Dispose();
            DbSqlConnection.Dispose();
        }
    }
}