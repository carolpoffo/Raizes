using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class EquipmentRepository : IEquipmentRepository
    {
        private IConnection _connection;

        public EquipmentRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<EquipmentEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID             AS {nameof(EquipmentEntity.Id)},
                                       NOME           AS {nameof(EquipmentEntity.Nome)},
                                       TIPO           AS {nameof(EquipmentEntity.Tipo)},
                                       DESCRICAO      AS {nameof(EquipmentEntity.Descricao)},
                                       PRECOUNITARIO  AS {nameof(EquipmentEntity.PrecoUnitario)},
                                       FORNECEDORID   AS {nameof(EquipmentEntity.FornecedorId)},
                                       DATACOMPRA     AS {nameof(EquipmentEntity.DataCompra)}
                                FROM   EQUIPAMENTO
                ";
                IEnumerable<EquipmentEntity> equipmentList = await con.QueryAsync<EquipmentEntity>(sql);
                return equipmentList;
            }
        }
        public async Task Insert(EquipmentInsertDTO equipment)
        {
            string sql = @$"
                 INSERT INTO EQUIPAMENTO (NOME, TIPO, DESCRICAO, PRECOUNITARIO, FORNECEDORID, DATACOMPRA)
                             VALUES      (@Nome, @Tipo, @Descricao, @PrecoUnitario, @FornecedorId, @DataCompra)                                     
            ";
            await _connection.Execute(sql, equipment);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM EQUIPAMENTO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<EquipmentEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID             AS {nameof(EquipmentEntity.Id)},
                                       NOME           AS {nameof(EquipmentEntity.Nome)},
                                       TIPO           AS {nameof(EquipmentEntity.Tipo)},
                                       DESCRICAO      AS {nameof(EquipmentEntity.Descricao)},
                                       PRECOUNITARIO  AS {nameof(EquipmentEntity.PrecoUnitario)},
                                       FORNECEDORID   AS {nameof(EquipmentEntity.FornecedorId)},
                                       DATACOMPRA     AS {nameof(EquipmentEntity.DataCompra)}
                                FROM   EQUIPAMENTO
                                WHERE ID = @Id
                              
                            ";
                EquipmentEntity equipment = await con.QueryFirstAsync<EquipmentEntity>(sql, new { id });
                return equipment;
            }
        }
        public async Task Update(EquipmentEntity equipment)
        {
            string sql = @$"
                            UPDATE EQUIPAMENTO
                            SET    NOME          = @Nome,
                                   TIPO          = @Tipo,
                                   DESCRICAO     = @Descricao,
                                   PRECOUNITARIO = @PrecoUnitario,
                                   FORNECEDORID  = @FornecedorId,
                                   DATACOMPRA    = @DataCompra
                            WHERE  ID            = @Id
                          ";
            await _connection.Execute(sql, equipment);
        }
    }
}