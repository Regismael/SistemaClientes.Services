using System.ComponentModel.DataAnnotations;

namespace SistemaClientes.Services.API.Models
{
    public class ClientesPostModel
    {
        [MaxLength(150,ErrorMessage = "O nome deve conter, no máximo, {1} caracteres")]
        [MinLength(8,ErrorMessage = "O nome deve conter, no mínimo, {1} caracteres.")]
        [Required(ErrorMessage = "O nome é de preechimento obrigatório.")]
        public string Nome { get; set; }

        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter, exatamente, 11 dígitos.")]
        [Required(ErrorMessage = "O CPF é de preechimento obrigatório.")]
        public string Cpf { get; set; }

        [RegularExpression(@"^\(\d{2}\) \d{5}-\d{4}$", ErrorMessage = "O telefone deve ser escrito neste formato: '(00) 00000-0000'.")]
        [Required(ErrorMessage = "O telefone é de preechimento obrigatório.")]
        public string Telefone { get; set; }

        [EmailAddress(ErrorMessage = "Escreva um email com formato válido.")]
        [Required(ErrorMessage = "O email é de preechimento obrigatório.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A data de nascimento é de preechimento obrigatório.")]
        public string DataNascimento { get; set; }
    }
}
