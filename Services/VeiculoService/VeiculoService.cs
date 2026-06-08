using BusControl.Data;
using BusControl.Dto;
using BusControl.Enums;
using BusControl.Models;
using System.Net.NetworkInformation;


namespace BusControl.Services.VeiculoService
{
    public class VeiculoService : IVeiculoService
    {
        private readonly ApplicationDbContext _context;

        public VeiculoService(ApplicationDbContext context)
        {
            _context = context;

        }

        //Cadastra o veiculo
        public async Task<ResponseModel<VeiculoModel>> CadastrarVeiculo(VeiculoRegisterDto veiculoRegisterDto)
        {

            ResponseModel<VeiculoModel> response = new ResponseModel<VeiculoModel>();

            try
            {
               
                var veiculo = new VeiculoModel()
                {
                    placaVeiculo = veiculoRegisterDto.placaVeiculo,
                    nomeVeiculo = veiculoRegisterDto.nomeVeiculo,
                    categoria = veiculoRegisterDto.categoria,
                    marcaVeiculo = veiculoRegisterDto.marcaVeiculo
                };

                _context.Add(veiculo);
                await _context.SaveChangesAsync();

                response.Mensagem = "Veiculo cadastrado com sucesso";

                return response;


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        //Consulta o veiculo
        public List<VeiculoModel> ConsultarVeiculo(string nome, string placa, string categoria)
        {
            var query = _context.Veiculos.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => x.nomeVeiculo.Contains(nome));
            }

            if (!string.IsNullOrEmpty(placa))
            {
                query = query.Where(x => x.placaVeiculo.Contains(placa));
            }

            if (!string.IsNullOrEmpty(categoria) && int.TryParse(categoria, out int categoriaInt))
            {
                var categoriaEnum = (CategoriaVeiculo)categoriaInt;

                query = query.Where(x => x.categoria == categoriaEnum);
            }



            return query.ToList();
        }

        //Exclui o veiculo
        public ResponseModel<bool> ExcluirVeiculo(int id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();

            try
            {
                var veiculo = _context.Veiculos.FirstOrDefault(x => x.id == id);

                if (veiculo == null)
                {
                    response.Status = false;
                    response.Mensagem = "Veiculo não encontrado.";
                    return response;
                }

                _context.Veiculos.Remove(veiculo);
                _context.SaveChanges();

                response.Status = true;
                response.Mensagem = "Veiculo excluído com sucesso.";

                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        
        
    }
}
