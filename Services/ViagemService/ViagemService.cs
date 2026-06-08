using BusControl.Data;
using BusControl.Dto;
using BusControl.Models;
using BusControl.Services.VeiculoService;
using Microsoft.EntityFrameworkCore;


namespace BusControl.Services.ViagemService
{
    public class ViagemService : IViagemService
    {
        private readonly ApplicationDbContext _context;

        public ViagemService(ApplicationDbContext context)
        {
            _context = context;

        }

        //Cadastra a viagem
        public async Task<ResponseModel<ViagemModel>> CadastrarViagem(ViagensRegisterDto viagemRegisterDto)
        {

            ResponseModel<ViagemModel> response = new ResponseModel<ViagemModel>();

            try
            {
               
                var viagem = new ViagemModel()
                {
                    destino = viagemRegisterDto.destino,
                    quantidadeParadas = viagemRegisterDto.quantidadeParadas,
                    quantidadePassageiros = viagemRegisterDto.quantidadePassageiros,
                    motoristaId = viagemRegisterDto.motoristaId,
                    veiculoId = viagemRegisterDto.veiculoId,
                    valorViagem = viagemRegisterDto.valorViagem
                };

                _context.Add(viagem);
                await _context.SaveChangesAsync();

                response.Mensagem = "Viagem cadastrada com sucesso";

                return response;


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        //Consulta a viagem
        public List<ViagemModel> ConsultarViagem(string destino, int motorista, int veiculo)
        {
            var query = _context.Viagens.Include(x => x.motorista).Include(x => x.veiculo).AsQueryable();

            if (!string.IsNullOrEmpty(destino))
            {
                query = query.Where(x => x.destino.Contains(destino));
            }

            if (motorista > 0)
            {
                query = query.Where(x => x.motorista.id == motorista);
            }

            if (veiculo > 0)
            {
                query = query.Where(x => x.veiculo.id == veiculo);
            }

            return query.ToList();
        }

        //Exclui a viagem
        public ResponseModel<bool> ExcluirViagem(int id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();

            try
            {
                var viagem = _context.Viagens.FirstOrDefault(x => x.id == id);

                if (viagem == null)
                {
                    response.Status = false;
                    response.Mensagem = "Viagem não encontrado.";
                    return response;
                }

                _context.Viagens.Remove(viagem);
                _context.SaveChanges();

                response.Status = true;
                response.Mensagem = "Viagem excluído com sucesso.";

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
