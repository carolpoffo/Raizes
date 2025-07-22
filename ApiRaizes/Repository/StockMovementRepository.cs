using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class StockMovementRepository : IStockMovementRepository
    {
        private IConnection _connection;

        public StockMovementRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<StockMovementEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID                    AS {nameof(StockMovementEntity.Id)},
                                       ARMAZENAMENTOID       AS {nameof(StockMovementEntity.ArmazenamentoId)},
                                       TIPOMOVIMENTACAO      AS {nameof(StockMovementEntity.TipoMovimento)},
                                       QUANTIDADE            AS {nameof(StockMovementEntity.Quantidade)},
                                       DATAMOVIMENTACAO      AS {nameof(StockMovementEntity.DataMovimentacao)},
                                       OBSERVACOES           AS {nameof(StockMovementEntity.Observacoes)}
                                FROM   MOVIMENTOARMAZENAMENTO
                ";
                IEnumerable<StockMovementEntity> stockMovementList = await con.QueryAsync<StockMovementEntity>(sql);
                return stockMovementList;
            }
        }
        public async Task Insert(StockMovementInsertDTO stockMovement)
        {
            string sql = @$"
                 INSERT INTO MOVIMENTOARMAZENAMENTO (ARMAZENAMENTOID, TIPOMOVIMENTACAO, QUANTIDADE, DATAMOVIMENTACAO, OBSERVACOES)
                             VALUES                 (@ArmazenamentoId, @TipoMovimentacao, @Quantidade, @DataMovimentacao, @Observacoes)                                     
            ";
            await _connection.Execute(sql, stockMovement);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM MOVIMENTOARMAZENAMENTO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<StockMovementEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID                    AS {nameof(StockMovementEntity.Id)},
                                       ARMAZENAMENTOID       AS {nameof(StockMovementEntity.ArmazenamentoId)},
                                       TIPOMOVIMENTACAO      AS {nameof(StockMovementEntity.TipoMovimento)},
                                       QUANTIDADE            AS {nameof(StockMovementEntity.Quantidade)},
                                       DATAMOVIMENTACAO      AS {nameof(StockMovementEntity.DataMovimentacao)},
                                       OBSERVACOES           AS {nameof(StockMovementEntity.Observacoes)}
                                FROM   MOVIMENTOARMAZENAMENTO
                                WHERE ID = @Id
                              
                            ";
                StockMovementEntity stockMovement = await con.QueryFirstAsync<StockMovementEntity>(sql, new { id });
                return stockMovement;
            }
        }
        public async Task Update(StockMovementEntity stockMovement)
        {
            string sql = @$"
                            UPDATE MOVIMENTOARMAZENAMENTO
                            SET    ARMAZENAMENTOID        = @ArmazenamentoId,
                                   TIPOMOVIMENTACAO       = @TipoMovimentacao,
                                   QUANTIDADE             = @Quantidade,
                                   DATAMOVIMENTACAO       = @DataMovimentacao,
                                   OBSERVACOES            = @Observacoes
                            WHERE  ID                     = @Id
                          ";
            await _connection.Execute(sql, stockMovement);
        }
    }
}