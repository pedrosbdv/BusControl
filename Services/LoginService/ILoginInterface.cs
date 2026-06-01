using BusControl.Dto;
using BusControl.Models;

namespace BusControl.Services.LoginService
{
    public interface ILoginInterface
    {
        Task<ResponseModel<UsuarioModel>> RegistrarUsuario(UsuarioRegisterDto usuarioRegisterDto);
    }
}
