using Dapper;
using SistemaClientes.Services.DATA.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes.Services.DATA.Repositories
{
    public class ClienteRepository
    {
        private string _connectionString => "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BDSistemaClientes;Integrated Security=True;";

        public void Inserir(Cliente cliente)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"
                INSERT INTO CLIENTE(ID, NOME, CPF, TELEFONE, EMAIL, DATANASCIMENTO)
                VALUES(@ID, @NOME, @CPF, @TELEFONE, @EMAIL, @DATANASCIMENTO)

                ", new
                {
                 @ID = cliente.Id,
                 @NOME = cliente.Nome,
                 @CPF = cliente.Cpf,
                 @TELEFONE = cliente.Telefone,
                 @EMAIL = cliente.Email,
                 @DATANASCIMENTO = cliente.DataNascimento

                });
            }
        }

        public void Atualizar(Cliente cliente)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"
                UPDATE CLIENTE
                SET NOME = @NOME, CPF = @CPF, TELEFONE = @TELEFONE, EMAIL = @EMAIL, DATANASCIMENTO = @DATANASCIMENTO
                WHERE ID = @ID

                ", new
                {
                 @ID = cliente.Id,
                 @NOME = cliente.Nome,
                 @CPF = cliente.Cpf,
                 @TELEFONE = cliente.Telefone,
                 @EMAIL = cliente.Email,
                 @DATANASCIMENTO = cliente.DataNascimento

                });
            }
        }

        public void Excluir(Cliente cliente)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                connection.Execute(@"
                UPDATE CLIENTE
                SET ATIVO = 0
                WHERE ID = @ID

                ", new
                {
                 @ID = cliente.Id

                });
            }
        }

        public List<Cliente> GetAll()
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>(@"
                 SELECT * FROM CLIENTE
                 WHERE ATIVO = 1
                 ORDER BY NOME

                 ").ToList();
            }
        }

        public Cliente? GetById(Guid id)
        {
            using(var connection = new SqlConnection(_connectionString))
            {
                return connection.Query<Cliente>(@"
                 SELECT * FROM CLIENTE
                 WHERE ATIVO = 1 AND ID = @ID

                 ", new
                {
                    @ID = id

                }).FirstOrDefault();
            }
        }
    }
}
