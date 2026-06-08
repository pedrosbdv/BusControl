using BusControl.Data;
using BusControl.Dto;
using BusControl.Enums;
using BusControl.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace BusControl.Services.MotoristaService
{
    public class MotoristaService : IMotoristaService
    {

        private readonly ApplicationDbContext _context;
        
        public MotoristaService(ApplicationDbContext context)
        {
            _context = context;
            
        }

        //Cadastra o motorista
        public async Task<ResponseModel<MotoristaModel>> CadastrarMotorista(MotoristaRegisterDto motoristaRegisterDto)
        {

            ResponseModel<MotoristaModel> response = new ResponseModel<MotoristaModel>();

            try
            {
                if (VerificarSeEmailExiste(motoristaRegisterDto))
                {
                    response.Mensagem = "Email já cadastrado";
                    response.Status = false;
                    return response;
                }

                

                var motorista = new MotoristaModel()
                {
                    Email = motoristaRegisterDto.Email,
                    Nome = motoristaRegisterDto.Nome,
                    DataNascimento = motoristaRegisterDto.DataNascimento,
                    Status = motoristaRegisterDto.Status

                };

                _context.Add(motorista);
                await _context.SaveChangesAsync();

                response.Mensagem = "Motorista cadastrado com sucesso";

                return response;


            }
            catch (Exception ex)
            {
                response.Mensagem = ex.Message;
                response.Status = false;
                return response;
            }
        }

        //Consulta o motorista
        public List<MotoristaModel> ConsultarMotoristas(string nome, string status)
        {
            var query = _context.Motoristas.AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => x.Nome.Contains(nome));
            }


            if (!string.IsNullOrEmpty(status) && int.TryParse(status, out int statusInt))
            {
                var statusEnum = (StatusMotorista)statusInt;

                query = query.Where(x => x.Status == statusEnum);
            }

            return query.ToList();
        }

        //Consulta o motorista com viagem
        public List<MotoristaModel> ConsultarMotoristasComViagens(string nome, string status)
        {
            var query = _context.Motoristas
                .Include(x => x.Viagens)
                    .ThenInclude(v => v.veiculo)
                .AsQueryable();

            if (!string.IsNullOrEmpty(nome))
            {
                query = query.Where(x => x.Nome.Contains(nome));
            }

            if (!string.IsNullOrEmpty(status))
            {
                query = query.Where(x => x.Status.ToString().Contains(status));
            }

            query = query.Where(x => x.Viagens.Any());

            return query.ToList();
        }


        //Exclui o motorista
        public ResponseModel<bool> ExcluirMotorista(int id)
        {
            ResponseModel<bool> response = new ResponseModel<bool>();

            try
            {
                var motorista = _context.Motoristas.FirstOrDefault(x => x.id == id);

                if (motorista == null)
                {
                    response.Status = false;
                    response.Mensagem = "Motorista não encontrado.";
                    return response;
                }

                _context.Motoristas.Remove(motorista);
                _context.SaveChanges();

                response.Status = true;
                response.Mensagem = "Motorista excluído com sucesso.";

                return response;
            }
            catch (Exception ex)
            {
                response.Status = false;
                response.Mensagem = ex.Message;
                return response;
            }
        }

        //Verifica se o e-mail do motorista existe
        private bool VerificarSeEmailExiste(MotoristaRegisterDto motoristaRegisterDto)
        {
            var motorista = _context.Motoristas.FirstOrDefault(x => x.Email == motoristaRegisterDto.Email);

            if (motorista == null)
            {
                return false;
            }

            return true;
        }
    }
}
