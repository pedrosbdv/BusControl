using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusControl.Models
{
    public class UsuarioModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Digite o email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public byte[] SenhaHash { get; set; }

        public byte[] SenhaSalt { get; set; }


    }
}
