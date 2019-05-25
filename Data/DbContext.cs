using System;
using System.Data;
using System.Data.SqlClient;
using System.Collections.Generic;
using Data.Abstracts;
using Data.Extensions;
using Data.Utils;

namespace Data
{
    public class DbContext : DbContextBase
    {
        public DbContext(string connectionString) : base(connectionString)
        {
        }
        
        //map object
        protected override IEnumerable<TEntity> ToMap<TEntity>(SqlCommand sqlCommand)
        {
            //open connection
            if (DbSqlConnection.State == ConnectionState.Closed)
            {
                DbSqlConnection.Open();
            }

            //using command
            using (var item = sqlCommand.ExecuteReader())
            {
                var items = new List<TEntity>();

                //fetch record
                while (item.Read()) items.Add(MapToItem<TEntity>(item));

                return items;
            }
        }
        
    }
}