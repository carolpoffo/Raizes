using ApiRaizes.Contracts.Infrastructure;
using ApiRaizes.Contracts.Repository;
using ApiRaizes.DTO;
using ApiRaizes.Entity;
using Dapper;
using MySql.Data.MySqlClient;

namespace ApiRaizes.Repository
{
    public class SupplierRepository : ISupplierRepository
    {
        private IConnection _connection;

        public SupplierRepository(IConnection connection)
        {
            _connection = connection;
        }
        public async Task Delete(int id)
        {
            string sql = "DELETE FROM FORNECEDOR WHERE ID = @id";

            await _connection.Execute(sql, new { id });
        }

        public async Task<IEnumerable<SupplierEntity>> GetAll()
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = $@"
                    SELECT Id AS {nameof(SupplierEntity.Id)},
                            Nome AS {nameof(SupplierEntity.Nome)},
                            CNPJ AS {nameof(SupplierEntity.CNPJ)},
                            Telefone AS {nameof(SupplierEntity.Telefone)},
                            Email AS {nameof(SupplierEntity.Email)}
                    FROM FORNECEDOR
                ";
                IEnumerable<SupplierEntity> supplierlist = await con.QueryAsync<SupplierEntity>(sql);
                return supplierlist;
            }

        }

        public async Task<SupplierEntity> GetById(int id)
        {
            using (MySqlConnection con = _connection.GetConnection())
            {
                string sql = @$"
                    SELECT Id AS {nameof(SupplierEntity.Id)},
                            Nome AS {nameof(SupplierEntity.Nome)},
                            CNPJ AS {nameof(SupplierEntity.CNPJ)},
                            Telefone AS {nameof(SupplierEntity.Telefone)},
                            Email AS {nameof(SupplierEntity.Email)}
                    FROM FORNECEDOR
                    WHERE ID = @id
                ";

                SupplierEntity supplier = await con.QueryFirstAsync<SupplierEntity>(sql, new { id });
                return supplier;
            }

        }

        public async Task Insert(SupplierInsertDTO supplier)
        {
            string sql = @"
                INSERT INTO FORNECEDOR(NOME,CNPJ,TELEFONE,EMAIL)
                                    VALUES(@Nome,@CNPJ,@Telefone,@Email)
            ";
            await _connection.Execute(sql, supplier);
        }

        public async Task Update(SupplierEntity supplier)
        {
            string sql = @"
                UPDATE FORNECEDOR
                SET Nome = @Nome,
                    CNPJ = @CNPJ,
                    Telefone = @Telefone,
                    Email = @Email
                WHERE ID = @id
            ";
            await _connection.Execute(sql, supplier);
        }
    }
}