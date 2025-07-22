using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class CityRepository : ICityRepository
    {
        private IConnection _connection;

        public CityRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<CityEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID     AS {nameof(CityEntity.Id)},
                                       NOME   AS {nameof(CityEntity.Nome)},
                                       ESTADO AS {nameof(CityEntity.Estado)},
                                       REGIAO AS {nameof(CityEntity.Regiao)},
                                       PAIS   AS {nameof(CityEntity.Pais)}
                                FROM   CIDADE
                ";
                IEnumerable<CityEntity> cityList = await con.QueryAsync<CityEntity>(sql);
                return cityList;
            }
        }
        public async Task Insert(CityInsertDTO city)
        {
            string sql = @$"
                 INSERT INTO CIDADE (NOME, ESTADO, REGIAO, PAIS)
                             VALUES (@Nome, @Estado, @Regiao, @Pais)                                     
            ";
            await _connection.Execute(sql, city);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM CIDADE WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<CityEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID      AS {nameof(CityEntity.Id)},
                                       NOME    AS {nameof(CityEntity.Nome)},
                                       ESTADO  AS {nameof(CityEntity.Estado)},
                                       REGIAO  AS {nameof(CityEntity.Regiao)},
                                       PAIS    AS {nameof(CityEntity.Pais)}
                                FROM CIDADE
                                WHERE ID = @Id
                              
                            ";
                CityEntity city = await con.QueryFirstAsync<CityEntity>(sql, new { id });
                return city;
            }
        }
        public async Task Update(CityEntity city)
        {
            string sql = @$"
                            UPDATE CIDADE
                            SET    NOME   = @Nome,
                                   ESTADO = @Estado,
                                   REGIAO = @Regiao,
                                   PAIS   = @Pais
                            WHERE  ID     = @Id
                          ";
            await _connection.Execute(sql, city);
        }
    }
}