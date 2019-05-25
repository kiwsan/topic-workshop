using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using Data.Abstracts;

namespace Data
{
    public class DbContextWithDataAdapter : DbContextBase, IDisposable
    {
        public SqlDataAdapter DbSqlDataAdapter { get; private set; }

        public DbContextWithDataAdapter(string connectionString) : base(connectionString)
        {
            DbSqlDataAdapter = new SqlDataAdapter();
        }

        protected override IEnumerable<TEntity> ToMap<TEntity>(SqlCommand sqlCommand)
        {
            //using datatable
            using (var dataTable = new DataTable())
            {
                DbSqlDataAdapter.SelectCommand = sqlCommand;
                //fill
                DbSqlDataAdapter.Fill(dataTable);

                var item = dataTable.CreateDataReader();
                var items = new List<TEntity>();
                //fetch record
                while (item.Read()) items.Add(MapToItem<TEntity>(item));

                return items;
            }
        }

        public new void Dispose()
        {
            base.Dispose();

            DbSqlDataAdapter.Dispose();
        }
    }
}