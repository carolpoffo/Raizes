using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class TaskRepository : ITaskRepository
    {
        private IConnection _connection;

        public TaskRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task<IEnumerable<TaskEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID         AS {nameof(TaskEntity.Id)},
                                       USUARIOID  AS {nameof(TaskEntity.UsuarioId)},
                                       TITULO     AS {nameof(TaskEntity.Titulo)},
                                       DESCRICAO  AS {nameof(TaskEntity.Descricao)},
                                       STATUS  AS {nameof(TaskEntity.Status)}
                                FROM   TAREFA
                ";
                IEnumerable<TaskEntity> taskList = await con.QueryAsync<TaskEntity>(sql);
                return taskList;
            }
        }
        public async Task Insert(TaskInsertDTO Task)
        {
            string sql = @$"
                 INSERT INTO TAREFA (USUARIOID, TITULO, DESCRICAO,STATUS)
                             VALUES (@UsuarioId, @Titulo, @Descricao,@Status)                                     
            ";
            await _connection.Execute(sql, Task);
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM TAREFA WHERE ID = @id";
            await _connection.Execute(sql, new { id });
        }
        public async Task<TaskEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                                SELECT ID         AS {nameof(TaskEntity.Id)},
                                       USUARIOID  AS {nameof(TaskEntity.UsuarioId)},
                                       TITULO     AS {nameof(TaskEntity.Titulo)},
                                       DESCRICAO  AS {nameof(TaskEntity.Descricao)},
                                       STATUS  AS {nameof(TaskEntity.Status)}
                                FROM   TAREFA
                                WHERE  ID = @Id
                              
                            ";
                TaskEntity Task = await con.QueryFirstAsync<TaskEntity>(sql, new { id });
                return Task;
            }
        }
        public async Task Update(TaskEntity Task)
        {
            string sql = @$"
                            UPDATE TAREFA
                            SET    USUARIOID = @UsuarioId,
                                   TITULO    = @Titulo,
                                   DESCRICAO = @Descricao,
                                   STATUS = @Status
                            WHERE  ID        = @Id
                          ";
            await _connection.Execute(sql, Task);
        }
    }
}