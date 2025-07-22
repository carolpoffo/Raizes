using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class PlantingRepository : IPlantingRepository
    {
        private IConnection _connection;

        public PlantingRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<PlantingEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                             SELECT ID                AS {nameof(PlantingEntity.Id)},
                                    ESPECIEID         AS {nameof(PlantingEntity.EspecieId)},
                                    PROPRIEDADEID     AS {nameof(PlantingEntity.PropriedadeId)},
                                    DATAINICIO        AS {nameof(PlantingEntity.DataInicio)},
                                    DATAFIM           AS {nameof(PlantingEntity.DataFim)},
                                    AREAPLANTADA      AS {nameof(PlantingEntity.AreaPlantada)},
                                    MUDAS             AS {nameof(PlantingEntity.Mudas)},
                                    DESCRICAO         AS {nameof(PlantingEntity.Descricao)},
                                    UNIDADEMEDIDAID   AS {nameof(PlantingEntity.UnidadeMedidaId)}
                               FROM PLANTIO
                ";
                IEnumerable<PlantingEntity> plantingList = await con.QueryAsync<PlantingEntity>(sql);
                return plantingList;
            }
        }
        public async Task Insert(PlantingInsertDTO planting)
        {
            string sql = @$"
                 INSERT INTO PLANTIO (ESPECIEID, PROPRIEDADEID, DATAINICIO, DATAFIM, AREAPLANTADA, MUDAS, DESCRICAO, UNIDADEMEDIDAID)
                      VALUES (@EspecieId, @PropriedadeId, @DataInicio, @DataFim, @AreaPlantada, @Mudas, @Descricao, @UnidadeMedidaId)                                     
            ";
            await _connection.Execute(sql, planting);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM PLANTIO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<PlantingEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                             SELECT ID                AS {nameof(PlantingEntity.Id)},
                                    ESPECIEID         AS {nameof(PlantingEntity.EspecieId)},
                                    PROPRIEDADEID     AS {nameof(PlantingEntity.PropriedadeId)},
                                    DATAINICIO        AS {nameof(PlantingEntity.DataInicio)},
                                    DATAFIM           AS {nameof(PlantingEntity.DataFim)},
                                    AREAPLANTADA      AS {nameof(PlantingEntity.AreaPlantada)},
                                    MUDAS             AS {nameof(PlantingEntity.Mudas)},
                                    DESCRICAO         AS {nameof(PlantingEntity.Descricao)},
                                    UNIDADEMEDIDAID   AS {nameof(PlantingEntity.UnidadeMedidaId)}
                               FROM PLANTIO
                               WHERE ID = @Id
                              
                            ";
                PlantingEntity planting = await con.QueryFirstAsync<PlantingEntity>(sql, new { id });
                return planting;
            }
        }
        public async Task Update(PlantingEntity planting)
        {
            string sql = @$"
                             UPDATE  PLANTIO
                             SET     ESPECIEID         = @EspecieId,
                                     PROPRIEDADEID     = @PropriedadeId,
                                     DATAINICIO        = @DataInicio,
                                     DATAFIM           = @DataFim,
                                     AREAPLANTADA      = @AreaPlantada,
                                     MUDAS             = @Mudas,
                                     DESCRICAO         = @Descricao,
                                     UNIDADEMEDIDAID   = @UnidadeMedidaId
                             WHERE   ID                = @Id
                          ";
            await _connection.Execute(sql, planting);
        }
    }
}