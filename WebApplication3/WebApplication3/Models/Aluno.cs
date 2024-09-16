using System.ComponentModel.DataAnnotations;
using WebApplication3.Validation;

namespace WebApplication3.Models
{
    public class Aluno
    {
        [Required(ErrorMessage = "Obrigatório")]
        [MinLength(3, ErrorMessage = "Minimo 3 letras ")]
        [MaxLength(50, ErrorMessage = "Maximo 50 letras ")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [RaValidation]
        public string RA { get; set; }

        [Required(ErrorMessage = "Obrigatório")]
        [EmailAddress(ErrorMessage = "Email invalido")]
        public string Email { get; set; }

        [MinLength(11, ErrorMessage = "Minimo 11 letras ")]
        [MaxLength(11, ErrorMessage = "Maximo 11 letras ")]
        [Required(ErrorMessage = "Obrigatório")]
        public string Cpf { get; set; }
        public bool Ativo { get; set; }
    }
}
