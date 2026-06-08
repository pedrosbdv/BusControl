using BusControl.Dto;
using BusControl.Models;

namespace BusControl.Services.MotoristaService
{
    public interface IMotoristaService
    {
        Task<ResponseModel<MotoristaModel>> CadastrarMotorista(MotoristaRegisterDto motoristaRegisterDto);
        List<MotoristaModel> ConsultarMotoristas(string nome, string status);
        List<MotoristaModel> ConsultarMotoristasComViagens(string nome, string status);
        ResponseModel<bool> ExcluirMotorista(int id);
    }
}
