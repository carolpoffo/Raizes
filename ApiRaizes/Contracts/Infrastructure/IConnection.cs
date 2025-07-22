using MySql.Data.MySqlClient;

namespace ApiRaizes.Contracts.Infrastructure
{
    public interface IConnection
    {
        public MySqlConnection GetConnection();
        public Task<int> Execute(string sql, object obj);
    }
}
