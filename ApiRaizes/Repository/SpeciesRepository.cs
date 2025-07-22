using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    class SpeciesRepository : ISpeciesRepository
    {
        private IConnection _connection;

        public SpeciesRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<SpeciesEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                          SELECT ID AS {nameof(SpeciesEntity.Id)},
                          NOMECOMUM AS {nameof(SpeciesEntity.NomeComum)},
                     NOMECIENTIFICO AS {nameof(SpeciesEntity.NomeCientifico)},
                          VARIEDADE AS {nameof(SpeciesEntity.Variedade)},
                     EPOCADEPLANTIO AS {nameof(SpeciesEntity.EpocaDePlantio)},
                    EPOCADECOLHEITA AS {nameof(SpeciesEntity.EpocaDeColheita)},
                    TEMPODECOLHEITA AS {nameof(SpeciesEntity.TempoDeColheita)},
                    TIPOSOLOIDEALID AS {nameof(SpeciesEntity.TipoSoloIdealId)},
                    IDEALUMIDADEMIN AS {nameof(SpeciesEntity.IdealUmidadeMin)},
                    IDEALUMIDADEMAX AS {nameof(SpeciesEntity.IdealUmidadeMax)},
                    CARACTERISTICAS AS {nameof(SpeciesEntity.Caracteristicas)}
                                       FROM ESPECIE
                ";
                IEnumerable<SpeciesEntity> especieList = await con.QueryAsync<SpeciesEntity>(sql);
                return especieList;
            }
        }
        public async Task Insert(SpeciesInsertDTO sale)
        {
            string sql = @$"
                INSERT INTO ESPECIE (NOMECOMUM,NOMECIENTIFICO,VARIEDADE,EPOCADEPLANTIO,EPOCADECOLHEITA,TEMPODECOLHEITA,TIPOSOLOIDEALID,IDEALUMIDADEMIN,IDEALUMIDADEMAX,CARACTERISTICAS)
                VALUES (@NomeComum,@NomeCientifico,@Variedade,@EpocaDePlantio,@EpocaDeColheita,@TempoDeColheita,@TipoSoloIdealId,@IdealUmidadeMin,@IdealUmidadeMax,@Caracteristicas)                                                         
            ";
            await _connection.Execute(sql, sale);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM ESPECIE WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<SpeciesEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                          SELECT ID AS {nameof(SpeciesEntity.Id)},
                          NOMECOMUM AS {nameof(SpeciesEntity.NomeComum)},
                     NOMECIENTIFICO AS {nameof(SpeciesEntity.NomeCientifico)},
                          VARIEDADE AS {nameof(SpeciesEntity.Variedade)},
                    EPOCADEPLANTIO AS {nameof(SpeciesEntity.EpocaDePlantio)},
                    EPOCADECOLHEITA AS {nameof(SpeciesEntity.EpocaDeColheita)},
                    TEMPODECOLHEITA AS {nameof(SpeciesEntity.TempoDeColheita)},
                    TIPOSOLOIDEALID AS {nameof(SpeciesEntity.TipoSoloIdealId)},
                    IDEALUMIDADEMIN AS {nameof(SpeciesEntity.IdealUmidadeMin)},
                    IDEALUMIDADEMAX AS {nameof(SpeciesEntity.IdealUmidadeMax)},
                    CARACTERISTICAS AS {nameof(SpeciesEntity.Caracteristicas)}
                                       FROM ESPECIE
                                WHERE ID = @Id
                              
                            ";
                SpeciesEntity especie = await con.QueryFirstAsync<SpeciesEntity>(sql, new { id });
                return especie;
            }
        }
        public async Task Update(SpeciesEntity especie)
        {
            string sql = @$"
                          UPDATE ESPECIE
                             SET NOMECOMUM       = @NomeComum,
                                 NOMECIENTIFICO  = @NomeCientifico,
                                 VARIEDADE       = @Variedade,
                                 EPOCADEPLANTIO  = @EpocaDePlantio,
                                 EPOCADECOLHEITA = @EpocaDeColheita,
                                 TEMPODECOLHEITA = @TempoDeColheita,
                                 TIPOSOLOIDEALID = @TipoSoloIdealId,
                                 IDEALUMIDADEMIN = @IdealUmidadeMin,
                                 IDEALUMIDADEMAX = @IdealUmidadeMax,
                                 CARACTERISTICAS = @Caracteristicas
                           WHERE ID              = @Id;
                          ";
            await _connection.Execute(sql, especie);
        }
    }
}
