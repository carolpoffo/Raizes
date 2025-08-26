using Dapper;
using ApiRaizes.Contracts.Infrastructure;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Infrastructure
{
    public class Connection : IConnection
    {

        protected string connectionString = "Server=localhost;Database=Raizes;User=root;Password=1234";
        public MySqlConnection GetConnection()
        {
            return new MySqlConnection(connectionString);
        }
        public async Task<int> Execute(string sql, object obj)
        {
            using (MySqlConnection con = GetConnection())
            {
                return await con.ExecuteAsync(sql, obj);
            }
        }
    }
}
