using BusControl.Data;
using BusControl.Dto;
using BusControl.Models;
using BusControl.Services.MotoristaService;
using BusControl.Services.VeiculoService;
using BusControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BusControl.Controllers
{
    public class ViagensController : Controller
    {

        private readonly IViagemService _viagemInterface;
        private readonly IMotoristaService _motoristaInterface;
        private readonly IVeiculoService _veiculoInterface;

        public ViagensController(IViagemService viagemInterface, IMotoristaService motoristaInterface, IVeiculoService veiculoInterface)
        {
            _viagemInterface = viagemInterface;
            _motoristaInterface = motoristaInterface;
            _veiculoInterface = veiculoInterface;
        }


        public async Task<IActionResult> Index(string destino, int motorista, int veiculo)
        {
            var viagens = _viagemInterface.ConsultarViagem(destino, motorista, veiculo);

            ViewBag.Destino = destino;
            ViewBag.MotoristaId = motorista;
            ViewBag.VeiculoId = veiculo;

            ViewBag.Motoristas = _motoristaInterface.ConsultarMotoristas(null, null);
            ViewBag.Veiculos = _veiculoInterface.ConsultarVeiculo(null, null, null);

            return View(viagens);
        }

        //Cadastra a viagem
        [HttpPost]
        public async Task<IActionResult> CadastrarViagem(ViagensRegisterDto viagensRegisterDto)
        {
            if (ModelState.IsValid)
            {
                var motorista = await _viagemInterface.CadastrarViagem(viagensRegisterDto);

                if (motorista.Status)
                {
                    return Json(new
                    {
                        sucesso = true,
                        mensagem = motorista.Mensagem
                    });
                }
                else
                {
                    return Json(new
                    {
                        sucesso = true,
                        mensagem = motorista.Mensagem
                    });
                }

                
            }
            else
            {
                return View(viagensRegisterDto);
            }


        }

       


        //Exclui a viagem
        [HttpPost]
        public JsonResult ExcluirViagem(int id)
        {
            var resultado = _viagemInterface.ExcluirViagem(id);

            return Json(new
            {
                sucesso = resultado.Status,
                mensagem = resultado.Mensagem
            });
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}
