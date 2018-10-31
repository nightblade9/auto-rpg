using System.Data.SqlClient;

namespace AutoRpg.DatabaseMediator
{
    /// <summary>
    /// Manages simple low-level database things like running queries
    /// </summary>
    public class DatabaseMediator : IDatabaseMediator
    {
        private string connectionString;

        public DatabaseMediator(ConnectionStrings connectionStrings)
        {
            this.connectionString = connectionStrings.DefaultConnection;
        }

        public T ExecuteScalar<T>(string query, object parameters = null)
        {
            if (parameters == null)
            {
                parameters = new { };
            }

            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();

                var command = connection.CreateCommand();
                command.CommandType = System.Data.CommandType.Text;
                command.CommandText = query;

                var paramsType = parameters.GetType();
                foreach (var field in paramsType.GetFields(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public))
                {
                    var name = field.Name;
                    var value = field.GetValue(parameters);

                    var sqlParameter = new SqlParameter(name, value);
                    command.Parameters.Add(sqlParameter);
                }

                T result = (T)command.ExecuteScalar();
                return result;
            }
        }
    }
}
