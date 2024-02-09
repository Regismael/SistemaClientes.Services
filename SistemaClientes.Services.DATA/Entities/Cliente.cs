using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaClientes.Services.DATA.Entities
{
    public class Cliente
    {
        private Guid? _id;
        private string? _nome;
        private string? _cpf;
        private string? _telefone;
        private string? _email;
        private DateTime? _dataNascimento;
        private int? _ativo;

        public Guid? Id { get => _id; set => _id = value; }
        public string? Nome { get => _nome; set => _nome = value; }
        public string? Cpf { get => _cpf; set => _cpf = value; }
        public string? Telefone { get => _telefone; set => _telefone = value; }
        public string? Email { get => _email; set => _email = value; }
        public DateTime? DataNascimento { get => _dataNascimento; set => _dataNascimento = value; }
        public int? Ativo { get => _ativo; set => _ativo = value; }
    }
}
