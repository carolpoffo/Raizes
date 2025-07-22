using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class EventRepository : IEventRepository
    {
        private IConnection _connection;

        public EventRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<EventEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID          AS {nameof(EventEntity.Id)},
                                       USUARIOID   AS {nameof(EventEntity.UsuarioId)},
                                       TITULO      AS {nameof(EventEntity.Titulo)},
                                       LOCAL       AS {nameof(EventEntity.Local)},
                                       DATAINICIO  AS {nameof(EventEntity.DataInicio)},
                                       DATAFIM     AS {nameof(EventEntity.DataFim)},
                                       DESCRICAO   AS {nameof(EventEntity.Descricao)}
                                FROM   EVENTO
                ";
                IEnumerable<EventEntity> eventList = await con.QueryAsync<EventEntity>(sql);
                return eventList;
            }
        }
        public async Task Insert(EventInsertDTO Event)
        {
            string sql = @$"
                 INSERT INTO EVENTO (USUARIOID, TITULO, LOCAL, DATAINICIO, DATAFIM, DESCRICAO)
                             VALUES (@UsuarioId, @Titulo, @Local, @DataInicio, @DataFim, @Descricao)                                     
            ";
            await _connection.Execute(sql, Event);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM EVENTO WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<EventEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID          AS {nameof(EventEntity.Id)},
                                       USUARIOID   AS {nameof(EventEntity.UsuarioId)},
                                       TITULO      AS {nameof(EventEntity.Titulo)},
                                       LOCAL       AS {nameof(EventEntity.Local)},
                                       DATAINICIO  AS {nameof(EventEntity.DataInicio)},
                                       DATAFIM     AS {nameof(EventEntity.DataFim)},
                                       DESCRICAO   AS {nameof(EventEntity.Descricao)}
                                FROM   EVENTO
                                WHERE ID = @Id
                              
                            ";
                EventEntity Event = await con.QueryFirstAsync<EventEntity>(sql, new { id });
                return Event;
            }
        }
        public async Task Update(EventEntity Event)
        {
            string sql = @$"
                            UPDATE EVENTO
                            SET    USUARIOID  = @UsuarioId,
                                   TITULO     = @Titulo,
                                   LOCAL      = @Local,
                                   DATAINICIO = @DataInicio,
                                   DATAFIM    = @DataFim,
                                   DESCRICAO  = @Descricao
                            WHERE  ID         = @Id
                          ";
            await _connection.Execute(sql, Event);
        }
    }
}