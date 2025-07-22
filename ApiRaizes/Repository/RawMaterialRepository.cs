using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class RawMaterialRepository : IRawMaterialRepository
    {
        private IConnection _connection;

        public RawMaterialRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<RawMaterialEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                        SELECT ID AS {nameof(RawMaterialEntity.Id)},
                                Nome AS {nameof(RawMaterialEntity.Nome)},
                                Tipo AS{nameof(RawMaterialEntity.Tipo)},
                                DataDeValidade AS {nameof(RawMaterialEntity.DataDeValidade)},
                                Descricao AS{nameof(RawMaterialEntity.Descricao)},
                                FornecedorId AS{nameof(RawMaterialEntity.FornecedorId)}
                                FROM INSUMO
                    ";


                var rawMateriallist = await con.QueryAsync<RawMaterialEntity>(sql);
                return rawMateriallist;
            }

        }
        public async Task Insert(RawMaterialInsertDTO rawMaterial)
        {
            string sql = @"
                INSERT INTO INSUMO (NOME, Tipo, DataDeValidade, Descricao, FornecedorId)
                            VALUE (@Nome, @Tipo, @DataDeValidade, @Descricao, @FornecedorId)
            ";

            await _connection.Execute(sql, rawMaterial);


        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM INSUMO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<RawMaterialEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {


                string sql = @$"
                        SELECT ID AS {nameof(RawMaterialEntity.Id)},
                                Nome AS {nameof(RawMaterialEntity.Nome)},
                                Tipo AS{nameof(RawMaterialEntity.Tipo)},
                                DataDeValidade AS {nameof(RawMaterialEntity.DataDeValidade)},
                                Descricao AS{nameof(RawMaterialEntity.Descricao)},
                                FornecedorId AS{nameof(RawMaterialEntity.FornecedorId)}
                                 FROM INSUMO
                                 WHERE ID = @id

            ";
                RawMaterialEntity rawMaterial = await con.QueryFirstAsync<RawMaterialEntity>(sql, new { id });
                return rawMaterial;

            }



        }
        public async Task Update(RawMaterialEntity rawMaterial)
        {
            string sql = @"
                UPDATE INSUMO
                   SET NOME = @Nome,
                       Tipo = @Tipo,
                      DataDeValidade = @DataDeValidade,
                      Descricao = @Descricao,
                      FornecedorId = @FornecedorId
                 WHERE ID = @Id
            ";

            await _connection.Execute(sql, rawMaterial);
        }

    }
}