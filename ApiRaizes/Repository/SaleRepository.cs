using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    class SaleRepository : ISaleRepository
    {
        private IConnection _connection;

        public SaleRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<SaleEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                          SELECT ID AS {nameof(SaleEntity.Id)},
                         COLHEITAID AS {nameof(SaleEntity.ColheitaId)},
                         QUANTIDADE AS {nameof(SaleEntity.Quantidade)},
                      PRECOUNITARIO AS {nameof(SaleEntity.PrecoUnitario)},
                         PRECOTOTAL AS {nameof(SaleEntity.PrecoTotal)},
                        COMPRADOR   AS {nameof(SaleEntity.Comprador)},
                    UNIDADEMEDIDAID AS {nameof(SaleEntity.UnidadeMedidaId)},
                          DATAVENDA AS {nameof(SaleEntity.DataVenda)}
                                      FROM VENDA
                ";
                IEnumerable<SaleEntity> saleList = await con.QueryAsync<SaleEntity>(sql);
                return saleList;
            }
        }
        public async Task Insert(SaleInsertDTO sale)
        {
            string sql = @$"
                INSERT INTO VENDA (COLHEITAID,QUANTIDADE,PRECOUNITARIO,COMPRADOR,UNIDADEMEDIDAID,DATAVENDA)
                VALUES (@ColheitaId,@Quantidade,@PrecoUnitario,@Comprador,@UnidadeMedidaId,@DataVenda)                                                         
            ";
            await _connection.Execute(sql, sale);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM VENDA WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<SaleEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                             SELECT ID AS {nameof(SaleEntity.Id)},
                         COLHEITAID AS {nameof(SaleEntity.ColheitaId)},
                         QUANTIDADE AS {nameof(SaleEntity.Quantidade)},
                      PRECOUNITARIO AS {nameof(SaleEntity.PrecoUnitario)},
                         PRECOTOTAL AS {nameof(SaleEntity.PrecoTotal)},
                        COMPRADOR AS {nameof(SaleEntity.Comprador)},
                    UNIDADEMEDIDAID AS {nameof(SaleEntity.UnidadeMedidaId)},
                          DATAVENDA AS {nameof(SaleEntity.DataVenda)}
                                      FROM VENDA
                                WHERE ID = @Id
                              
                            ";
                SaleEntity venda = await con.QueryFirstAsync<SaleEntity>(sql, new { id });
                return venda;
            }
        }
        public async Task Update(SaleEntity venda)
        {
            string sql = @$"
                                         UPDATE   VENDA
                                 SET COLHEITAID = @ColheitaId,
                                     QUANTIDADE = @Quantidade,
                                  PRECOUNITARIO = @PrecoUnitario,
                                    COMPRADOR = @Comprador,
                                UNIDADEMEDIDAID = @UnidadeMedidaId,
                                      DATAVENDA = @DataVenda
                                       WHERE ID = @Id;
                          ";
            await _connection.Execute(sql, venda);
        }
    }
}
