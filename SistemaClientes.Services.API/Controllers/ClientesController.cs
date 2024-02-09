using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SistemaClientes.Services.API.Models;
using SistemaClientes.Services.DATA.Entities;
using SistemaClientes.Services.DATA.Repositories;

namespace SistemaClientes.Services.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post(ClientesPostModel model)
        {
            try
            {
                var cliente = new Cliente
                {
                    Id = Guid.NewGuid(),
                    Nome = model.Nome,
                    Cpf = model.Cpf,
                    Telefone = model.Telefone,
                    Email = model.Email,
                    DataNascimento = DateTime.Parse(model.DataNascimento),
                    Ativo = 1
                };

                var clienteRepository = new ClienteRepository();
                clienteRepository.Inserir(cliente);

                return StatusCode(201, new
                {
                    Message = "Cliente cadastrado com sucesso!",
                    cliente
                });
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpPut]
        public IActionResult Put(ClientesPutModel model)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.GetById(model.Id);

                if (cliente != null)
                {
                    cliente.Nome = model.Nome;
                    cliente.Cpf = model.Cpf;
                    cliente.Telefone = model.Telefone;
                    cliente.Email = model.Email;
                    cliente.DataNascimento = DateTime.Parse(model.DataNascimento);

                    clienteRepository.Atualizar(cliente);

                    return StatusCode(201, new
                    {
                        Message = "Cliente atualizado com sucesso!",
                        cliente
                    });

                }
                else
                {
                    return StatusCode(400, new
                    {
                        Message = "Cliente não encontrado, verifique o Id."
                    });
                }

            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.GetById(id);

                if(cliente != null)
                {
                    clienteRepository.Excluir(cliente);

                    return StatusCode(200, new
                    {
                        Message = "Cliente excluído com sucesso!",
                        cliente
                    });
                }
                else
                {

                    return StatusCode(400, new
                    {
                        Message = "Cliente não encontrado, verifique o Id."
                    });
                }

            }
            catch(Exception e) 
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.GetAll();

                return StatusCode(200, cliente);
                 
            }
            catch (Exception e)
            {
                return StatusCode(500, e.Message);
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var clienteRepository = new ClienteRepository();
                var cliente = clienteRepository.GetById(id);

                if(cliente != null)
                {
                    return StatusCode(200, new
                    {
                        Message = "Cliente encontrado",
                        cliente
                    });
                }
                else
                {
                    return StatusCode(400, new
                    {
                        Message = "Cliente não encontrado, verifique o Id."
                    });
                }
            }
            catch( Exception e )
            {
                return StatusCode(500, e.Message);
            }

        }
    }
}
