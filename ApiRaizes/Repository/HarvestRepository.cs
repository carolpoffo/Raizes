using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    class HarvestRepository : IHarvestRepository
    {
        private IConnection _connection;

        public HarvestRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<HarvestEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID              AS {nameof(HarvestEntity.Id)},
                                       PLANTIOID       AS {nameof(HarvestEntity.PlantioId)},
                                       DATACOLHEITA    AS {nameof(HarvestEntity.DataColheita)},
                                       QUANTIDADE      AS {nameof(HarvestEntity.Quantidade)},
                                       UNIDADEMEDIDAID AS {nameof(HarvestEntity.UnidadeMedidaId)},
                                       OBSERVACAO      AS {nameof(HarvestEntity.Observacao)}
                                  FROM COLHEITA
                ";
                IEnumerable<HarvestEntity> harvestList = await con.QueryAsync<HarvestEntity>(sql);
                return harvestList;
            }
        }
        public async Task Insert(HarvestInsertDTO harvest)
        {
            string sql = @$"
                INSERT INTO COLHEITA (PLANTIOID,DATACOLHEITA,QUANTIDADE,UNIDADEMEDIDAID,OBSERVACAO)
                              VALUES (@PlantioId,@DataColheita,@Quantidade,@UnidadeMedidaId,@Observacao)                                                         
            ";
            await _connection.Execute(sql, harvest);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM COLHEITA WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<HarvestEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                 SELECT ID              AS {nameof(HarvestEntity.Id)},
                                        PLANTIOID       AS {nameof(HarvestEntity.PlantioId)},
                                        DATACOLHEITA    AS {nameof(HarvestEntity.DataColheita)},
                                        QUANTIDADE      AS {nameof(HarvestEntity.Quantidade)},
                                        UNIDADEMEDIDAID AS {nameof(HarvestEntity.UnidadeMedidaId)},
                                        OBSERVACAO      AS {nameof(HarvestEntity.Observacao)}
                                 FROM   COLHEITA
                                      WHERE ID = @Id
                              
                            ";
                HarvestEntity harvest = await con.QueryFirstAsync<HarvestEntity>(sql, new { id });
                return harvest;
            }
        }
        public async Task Update(HarvestEntity harvest)
        {
            string sql = @$"
                            UPDATE   COLHEITA
                            SET      PLANTIOID       = @PlantioId,
                                     DATACOLHEITA    = @DataColheita,
                                     QUANTIDADE      = @Quantidade,
                                     UNIDADEMEDIDAID = @UnidadeMedidaId,
                                     OBSERVACAO      = @Observacao
                           WHERE     ID              = @Id
                          ";
            await _connection.Execute(sql, harvest);
        }
    }
}
