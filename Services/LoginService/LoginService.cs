using BusControl.Data;
using BusControl.Dto;
using BusControl.Models;
using BusControl.Services.SenhaService;

namespace BusControl.Services.LoginService
{
    public class LoginService : ILoginInterface
    {

        private readonly ApplicationDbContext _context;
        private readonly ISenhaInterface _senhaInterface;
        public LoginService(ApplicationDbContext context, ISenhaInterface senhaInterface)
        {
            _context = context;
            _senhaInterface = senhaInterface;
        }

        public async Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto)
        {

            ResponseModel<UsuarioModel> response = new ResponseModel<UsuarioModel>();

            try
            {
                if (VerificarSeEmailExiste(usuarioRegisterDto))
                {
                    response.Mensagem = "Email já cadastrado";
                    response.Status = false;
                    return response;
                }

                _senhaInterface.CriarSenhaHash(usuarioRegisterDto.Senha, out byte[] senhaHash, out byte[] senhaSalt);

                var usuario = new UsuarioModel()
                {
                    Email = usuarioRegisterDto.Email,
                    SenhaHash = senhaHash,
                    SenhaSalt = senhaSalt
                    
                };

                _context.Add(usuario);
                await _context.SaveChangesAsync();

                response.Mensagem = "Usuario cadastrado com sucesso";

                return response;


            }
            catch (Exception ex) 
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        private bool VerificarSeEmailExiste(UsuarioRegisterDto usuarioRegisterDto)
        {
            var usuario = _context.Usuarios.FirstOrDefault(x => x.Email == usuarioRegisterDto.Email);

            if(usuario == null)
            {
                return false;
            }

            return true;
        }
    }
}
