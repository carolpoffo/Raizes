using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class RawMaterialStockRepository : IRawMaterialStockRepository
    {
        private IConnection _connection;

        public RawMaterialStockRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<RawMaterialStockEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT ID AS {nameof(RawMaterialStockEntity.Id)},
                                  PROPRIEDADEID AS {nameof(RawMaterialStockEntity.PropriedadeId)},
                                     INSUMOID AS {nameof(RawMaterialStockEntity.InsumoId)},
                                   QUANTIDADE AS {nameof(RawMaterialStockEntity.Quantidade)},
                               PRECOUNITARIO AS {nameof(RawMaterialStockEntity.PrecoUnitario)},
                                  PRECOTOTAL AS {nameof(RawMaterialStockEntity.PrecoTotal)},
                            DATAMOVIMENTACAO AS {nameof(RawMaterialStockEntity.DataMovimentacao)}
                    FROM INSUMOESTOQUE
";

                IEnumerable<RawMaterialStockEntity> rawMaterialStockList = await con.QueryAsync<RawMaterialStockEntity>(sql);
                return rawMaterialStockList;
            }
        }
        public async Task Insert(RawMaterialStockInsertDTO rawMaterialStock)
        {
            string sql = @$"
                 INSERT INTO INSUMOESTOQUE (PROPRIEDADEID, INSUMOID, QUANTIDADE, PRECOUNITARIO, DATAMOVIMENTACAO)
                                 VALUES (@PropriedadeId, @InsumoId, @Quantidade, @PrecoUnitario, @DataMovimentacao)                                                         
            ";

            await _connection.Execute(sql, rawMaterialStock);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM INSUMOESTOQUE WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<RawMaterialStockEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                      SELECT ID AS {nameof(RawMaterialStockEntity.Id)},
                             PROPRIEDADEID AS {nameof(RawMaterialStockEntity.PropriedadeId)},
                             INSUMOID AS {nameof(RawMaterialStockEntity.InsumoId)},
                             QUANTIDADE AS {nameof(RawMaterialStockEntity.Quantidade)},
                             PRECOUNITARIO AS {nameof(RawMaterialStockEntity.PrecoUnitario)},
                             PRECOTOTAL AS {nameof(RawMaterialStockEntity.PrecoTotal)},
                             DATAMOVIMENTACAO AS {nameof(RawMaterialStockEntity.DataMovimentacao)}
                        FROM INSUMOESTOQUE
                       WHERE ID = @Id
                ";

                RawMaterialStockEntity aeroporto = await con.QueryFirstAsync<RawMaterialStockEntity>(sql, new { id });
                return aeroporto;
            }
        }
        public async Task Update(RawMaterialStockEntity rawMaterialStock)
        {
            string sql = @$"
                               UPDATE INSUMOESTOQUE
                          SET PROPRIEDADEID = @PropriedadeId,
                              INSUMOID = @InsumoId,
                              QUANTIDADE = @Quantidade,
                              PRECOUNITARIO = @PrecoUnitario,
                              DATAMOVIMENTACAO = @DataMovimentacao
                            WHERE ID = @Id
                 ";

            await _connection.Execute(sql, rawMaterialStock);
        }
    }
}