using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;


namespace ApiRaizes.Repository
{
    public class PlantingRawMaterialRepository : IPlantingRawMaterialRepository
    {
        private IConnection _connection;

        public PlantingRawMaterialRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM PLANTIOINSUMO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<PlantingRawMaterialEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                        SELECT ID AS {nameof(PlantingRawMaterialEntity.Id)},
                                PlantioId AS {nameof(PlantingRawMaterialEntity.PlantioId)},
                                InsumoId AS {nameof(PlantingRawMaterialEntity.InsumoId)},
                                Quantidade AS {nameof(PlantingRawMaterialEntity.Quantidade)},
                                DataAplicacao AS {nameof(PlantingRawMaterialEntity.DataAplicacao)}
                                FROM PLANTIOINSUMO
                    ";


                var plantingRawMateriallist = await con.QueryAsync<PlantingRawMaterialEntity>(sql);
                return plantingRawMateriallist;
            }
        }

        public async Task<PlantingRawMaterialEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {


                string sql = @$"
                     SELECT ID AS {nameof(PlantingRawMaterialEntity.Id)},
                                PlantioId AS {nameof(PlantingRawMaterialEntity.PlantioId)},
                                InsumoId AS {nameof(PlantingRawMaterialEntity.InsumoId)},
                                Quantidade AS {nameof(PlantingRawMaterialEntity.Quantidade)},
                                DataAplicacao AS {nameof(PlantingRawMaterialEntity.DataAplicacao)}
                                FROM PLANTIOINSUMO    
                                    WHERE ID = @id

            ";
                var plantingRawMateriallist = await con.QueryFirstAsync<PlantingRawMaterialEntity>(sql, new { id });
                return plantingRawMateriallist;

            }

        }

        public async Task Insert(PlantingRawMaterialInsertDTO plantingRawMaterial)
        {
            string sql = @"
                INSERT INTO PLANTIOINSUMO (PlantioId, InsumoId, Quantidade, DataAplicacao)
                            VALUE (@PlantioId, @InsumoId, @Quantidade, @DataAplicacao)
            ";

            await _connection.Execute(sql, plantingRawMaterial);
        }

        public async Task Update(PlantingRawMaterialEntity plantingRawMaterial)
        {
            string sql = @"
                UPDATE PLANTIOINSUMO
                   SET PlantioId = @PlantioId,
                   InsumoId = @InsumoId,
                  Quantidade = @Quantidade,
                  DataAplicacao = @DataAplicacao
                 WHERE ID = @Id
            ";

            await _connection.Execute(sql, plantingRawMaterial);
        }
    }


}