using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Topic.Options;

namespace Topic.Data
{
    public class DbContext
    {
        public string ConnectionString { get; private set; }
        public SqlConnection DbConnection { get; private set; }
        public SqlCommand DbSqlCommand { get; private set; }

        public DbContext(string _sqlConnectionString)
        {
            ConnectionString = _sqlConnectionString;
            DbConnection = new SqlConnection();
            DbSqlCommand = DbConnection.CreateCommand();
        }

        private SqlParameter[] Parameters(params ParameterOptions[] parameters)
            => parameters.Select(x => new SqlParameter()
            {
                ParameterName = x.Name,
                Value = x.Value
            }).ToArray();

        public virtual DataTable ExecuteProc(string name, params ParameterOptions[] parameters)
        {
            DbSqlCommand.Parameters.Clear();
            DbSqlCommand.CommandText = name;
            DbSqlCommand.CommandType = CommandType.StoredProcedure;

            if (parameters?.Length > 0)
            {
                DbSqlCommand.Parameters.AddRange(Parameters(parameters));
            }

            DataTable dbResult = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter(DbSqlCommand);
            sqlDataAdapter.Fill(dbResult);

            return dbResult;
        }
    }
}