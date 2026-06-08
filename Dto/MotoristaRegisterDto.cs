using BusControl.Enums;
using System.ComponentModel.DataAnnotations;

namespace BusControl.Dto
{
    public class MotoristaRegisterDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Digite o email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite o nome do motorista")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite a data de nascimento")]
        public DateOnly DataNascimento { get; set; }

        public StatusMotorista Status {  get; set; }

    }
}
