using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class SoilTypeRepository : ISoilTypeRepository
    {
        private IConnection _connection;

        public SoilTypeRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<SoilTypeEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID        AS {nameof(SoilTypeEntity.Id)},
                                       NOME      AS {nameof(SoilTypeEntity.Nome)},
                                       TEXTURA   AS {nameof(SoilTypeEntity.Textura)},
                                       DESCRICAO AS {nameof(SoilTypeEntity.Descricao)}
                                FROM   TIPOSOLO
                ";
                IEnumerable<SoilTypeEntity> soilTypeList = await con.QueryAsync<SoilTypeEntity>(sql);
                return soilTypeList;
            }
        }
        public async Task Insert(SoilTypeInsertDTO soilType)
        {
            string sql = @$"
                 INSERT INTO TIPOSOLO (NOME, TEXTURA, DESCRICAO)
                             VALUES   (@Nome, @Textura, @Descricao)                                     
            ";
            await _connection.Execute(sql, soilType);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM TIPOSOLO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<SoilTypeEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID        AS {nameof(SoilTypeEntity.Id)},
                                       NOME      AS {nameof(SoilTypeEntity.Nome)},
                                       TEXTURA   AS {nameof(SoilTypeEntity.Textura)},
                                       DESCRICAO AS {nameof(SoilTypeEntity.Descricao)}
                                FROM   TIPOSOLO
                                WHERE ID = @Id
                              
                            ";
                SoilTypeEntity soilType = await con.QueryFirstAsync<SoilTypeEntity>(sql, new { id });
                return soilType;
            }
        }
        public async Task Update(SoilTypeEntity soilType)
        {
            string sql = @$"
                            UPDATE TIPOSOLO
                            SET    NOME      = @Nome,
                                   TEXTURA   = @Textura,
                                   DESCRICAO = @Descricao
                            WHERE  ID        = @Id
                          ";
            await _connection.Execute(sql, soilType);
        }
    }
}