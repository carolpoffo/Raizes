using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class PlantingEquipmentRepository : IPlantingEquipmentRepository
    {
        private IConnection _connection;

        public PlantingEquipmentRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<PlantingEquipmentEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID                 AS {nameof(PlantingEquipmentEntity.Id)},
                                       PLANTIOID          AS {nameof(PlantingEquipmentEntity.PlantioId)},
                                       EQUIPAMENTOID      AS {nameof(PlantingEquipmentEntity.EquipamentoId)},
                                       QUANTIDADE         AS {nameof(PlantingEquipmentEntity.Quantidade)},
                                       DATAAPLICACAO      AS {nameof(PlantingEquipmentEntity.DataAplicacao)}
                                FROM   PLANTIOEQUIPAMENTO
                ";
                IEnumerable<PlantingEquipmentEntity> plantingEquipmentList = await con.QueryAsync<PlantingEquipmentEntity>(sql);
                return plantingEquipmentList;
            }
        }
        public async Task Insert(PlantingEquipmentInsertDTO plantingEquipment)
        {
            string sql = @$"
                 INSERT INTO PLANTIOEQUIPAMENTO (PLANTIOID, EQUIPAMENTOID, QUANTIDADE, DATAAPLICACAO)
                             VALUES             (@PlantioId, @EquipamentoId, @Quantidade, @DataAplicacao)                                     
            ";
            await _connection.Execute(sql, plantingEquipment);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM PLANTIOEQUIPAMENTO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<PlantingEquipmentEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID                 AS {nameof(PlantingEquipmentEntity.Id)},
                                       PLANTIOID          AS {nameof(PlantingEquipmentEntity.PlantioId)},
                                       EQUIPAMENTOID      AS {nameof(PlantingEquipmentEntity.EquipamentoId)},
                                       QUANTIDADE         AS {nameof(PlantingEquipmentEntity.Quantidade)},
                                       DATAAPLICACAO      AS {nameof(PlantingEquipmentEntity.DataAplicacao)}
                                FROM   PLANTIOEQUIPAMENTO
                                WHERE ID = @Id
                              
                            ";
                PlantingEquipmentEntity plantingEquipment = await con.QueryFirstAsync<PlantingEquipmentEntity>(sql, new { id });
                return plantingEquipment;
            }
        }
        public async Task Update(PlantingEquipmentEntity plantingEquipment)
        {
            string sql = @$"
                            UPDATE PLANTIOEQUIPAMENTO
                            SET    PLANTIOID       = @PlantioId,
                                   EQUIPAMENTOID   = @EquipamentoId,
                                   QUANTIDADE      = @Quantidade,
                                   DATAAPLICACAO   = @DataAplicacao
                            WHERE  ID              = @Id
                          ";
            await _connection.Execute(sql, plantingEquipment);
        }
    }
}