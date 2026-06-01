using System.ComponentModel.DataAnnotations;

namespace BusControl.Dto
{
    public class UsuarioRegisterDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Digite o email!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Digite a senha")]
        public string Senha { get; set; }

        [
            Required(ErrorMessage = "Digite a confirmação da senha"),
            Compare("Senha", ErrorMessage="As senhas não são iguais") 
        ]
        public string ConfirmarSenha { get; set; }
    }
}
