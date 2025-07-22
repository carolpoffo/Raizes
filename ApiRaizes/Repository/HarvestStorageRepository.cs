using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;


namespace ApiRaizes.Repository
{
    class HarvestStorageRepository : IHarvestStorageRepository
    {
        private IConnection _connection;

        public HarvestStorageRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<HarvestStorageEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                               SELECT ID                    AS {nameof(HarvestStorageEntity.Id)},
                                      COLHEITAID            AS {nameof(HarvestStorageEntity.ColheitaId)},
                                      QUANTIDADEDISPONIVEL  AS {nameof(HarvestStorageEntity.QuantidadeDisponivel)},
                                      LOCALARMAZENAMENTO    AS {nameof(HarvestStorageEntity.LocalArmazenamento)},
                                      DATAENTRADA           AS {nameof(HarvestStorageEntity.DataEntrada)},
                                      DATAULTIMAATUALIZACAO AS {nameof(HarvestStorageEntity.DataUltimaAtualizacao)},
                                      STATUS                AS {nameof(HarvestStorageEntity.Status)}
                               FROM   ARMAZENAMENTOCOLHEITA
                ";
                IEnumerable<HarvestStorageEntity> harvestStorageList = await con.QueryAsync<HarvestStorageEntity>(sql);
                return harvestStorageList;
            }
        }
        public async Task Insert(HarvestStorageInsertDTO harvestStorage)
        {
            string sql = @$"
                INSERT INTO ARMAZENAMENTOCOLHEITA (COLHEITAID,QUANTIDADEDISPONIVEL,LOCALARMAZENAMENTO,DATAENTRADA,DATAULTIMAATUALIZACAO,STATUS)
                            VALUES                (@ColheitaId,@QuantidadeDisponivel,@LocalArmazenamento,@DataEntrada,@DataUltimaAtualizacao,@Status)                                                         
            ";
            await _connection.Execute(sql, harvestStorage);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM ARMAZENAMENTOCOLHEITA WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<HarvestStorageEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID                    AS {nameof(HarvestStorageEntity.Id)},
                                       COLHEITAID            AS {nameof(HarvestStorageEntity.ColheitaId)},
                                       QUANTIDADEDISPONIVEL  AS {nameof(HarvestStorageEntity.QuantidadeDisponivel)},
                                       LOCALARMAZENAMENTO    AS {nameof(HarvestStorageEntity.LocalArmazenamento)},
                                       DATAENTRADA           AS {nameof(HarvestStorageEntity.DataEntrada)},
                                       DATAULTIMAATUALIZACAO AS {nameof(HarvestStorageEntity.DataUltimaAtualizacao)},
                                       STATUS                AS {nameof(HarvestStorageEntity.Status)}
                                FROM   ARMAZENAMENTOCOLHEITA
                                WHERE ID = @Id
                              
                            ";
                HarvestStorageEntity harvestStorage = await con.QueryFirstAsync<HarvestStorageEntity>(sql, new { id });
                return harvestStorage;
            }
        }
        public async Task Update(HarvestStorageEntity harvestStorage)
        {
            string sql = @$"
                            UPDATE   ARMAZENAMENTOCOLHEITA
                            SET      COLHEITAID            = @ColheitaId,
                                     QUANTIDADEDISPONIVEL  = @QuantidadeDisponivel,
                                     LOCALARMAZENAMENTO    = @LocalArmazenamento,
                                     DATAENTRADA           = @DataEntrada,
                                     DATAULTIMAATUALIZACAO = @DataUltimaAtualizacao,
                                     STATUS                = @Status
                            WHERE    ID                    = @Id;
                          ";
            await _connection.Execute(sql, harvestStorage);
        }
    }
}
