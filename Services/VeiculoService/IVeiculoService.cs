using BusControl.Dto;
using BusControl.Enums;
using BusControl.Models;

namespace BusControl.Services.VeiculoService
{
    public interface IVeiculoService
    {
        Task<ResponseModel<VeiculoModel>> CadastrarVeiculo(VeiculoRegisterDto veiculoRegisterDto);
        List<VeiculoModel> ConsultarVeiculo(string nome, string placa, string categoria);
        ResponseModel<bool> ExcluirVeiculo(int id);
    }
}
