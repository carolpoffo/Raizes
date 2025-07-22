using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    class SoilHistoricRepository : ISoilHistoricRepository
    {
        private IConnection _connection;

        public SoilHistoricRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<SoilHistoricEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                          SELECT ID     AS {nameof(SoilHistoricEntity.Id)},
                          TIPOSOLOID AS {nameof(SoilHistoricEntity.TipoSoloId)},
                          DATALEITURA AS {nameof(SoilHistoricEntity.DataLeitura)},
                          UMIDADE AS {nameof(SoilHistoricEntity.Umidade)},
                          OBSERVACOES AS {nameof(SoilHistoricEntity.Observacoes)},
                          PROPRIEDADEID AS {nameof(SoilHistoricEntity.PropriedadeId)}
                                      FROM HISTORICOSOLO
                ";
                IEnumerable<SoilHistoricEntity> soilHistoric = await con.QueryAsync<SoilHistoricEntity>(sql);
                return soilHistoric;
            }
        }
        public async Task Insert(SoilHistoricInsertDTO sale)
        {
            string sql = @$"
                INSERT INTO HISTORICOSOLO (TIPOSOLOID,DATALEITURA,UMIDADE,OBSERVACOES,PROPRIEDADEID)
                VALUES (@TipoSoloId,@DataLeitura,@Umidade,@Observacoes,@PropriedadeId)                                                         
            ";
            await _connection.Execute(sql, sale);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM HISTORICOSOLO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<SoilHistoricEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                              SELECT ID     AS {nameof(SoilHistoricEntity.Id)},
                              TIPOSOLOID    AS {nameof(SoilHistoricEntity.TipoSoloId)},
                              DATALEITURA   AS {nameof(SoilHistoricEntity.DataLeitura)},
                              UMIDADE       AS {nameof(SoilHistoricEntity.Umidade)},
                              OBSERVACOES   AS {nameof(SoilHistoricEntity.Observacoes)},
                              PROPRIEDADEID AS {nameof(SoilHistoricEntity.PropriedadeId)}
                                            FROM HISTORICOSOLO
                                            WHERE ID = @Id
                              
                            ";
                SoilHistoricEntity soilHistoric = await con.QueryFirstAsync<SoilHistoricEntity>(sql, new { id });
                return soilHistoric;
            }
        }
        public async Task Update(SoilHistoricEntity soilHistoric)
        {
            string sql = @$"
                             UPDATE HISTORICOSOLO
                                 SET TIPOSOLOID   = @TipoSoloId,
                                      DATALEITURA = @DataLeitura,
                                     UMIDADE      = @Umidade,
                                  OBSERVACOES     = @Observacoes,
                                  PROPRIEDADEID   = @PropriedadeId
                                       WHERE ID   = @Id;
                          ";
            await _connection.Execute(sql, soilHistoric);
        }
    }
}
