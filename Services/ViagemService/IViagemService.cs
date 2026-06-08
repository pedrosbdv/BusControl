using BusControl.Dto;
using BusControl.Models;

namespace BusControl.Services.VeiculoService
{
    public interface IViagemService
    {
        Task<ResponseModel<ViagemModel>> CadastrarViagem(ViagensRegisterDto viagemRegisterDto);
        List<ViagemModel> ConsultarViagem(string destino, int motorista, int veiculo);
        ResponseModel<bool> ExcluirViagem(int id);
    }
}
