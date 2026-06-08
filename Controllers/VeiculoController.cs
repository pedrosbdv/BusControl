using BusControl.Dto;
using BusControl.Enums;
using BusControl.Models;
using BusControl.Services.LoginService;
using BusControl.Services.MotoristaService;
using BusControl.Services.VeiculoService;
using BusControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net.NetworkInformation;

namespace BusControl.Controllers
{
    public class VeiculoController : Controller
    {

        private readonly IVeiculoService _veiculoInterface;
        public VeiculoController(IVeiculoService veiculoInterface)
        {
            _veiculoInterface = veiculoInterface;
        }

        public IActionResult Index(string nome, string placa, string categoria)
        {
            var motoristas = _veiculoInterface.ConsultarVeiculo(nome, placa, categoria);

            ViewBag.nome = nome;
            ViewBag.placa = placa;
            ViewBag.categoria = categoria;
            

            return View(motoristas);
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarVeiculo(VeiculoRegisterDto veiculoRegisterDto)
        {

            if (!ModelState.IsValid)
            {
                var erros = ModelState
                    .SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage)
                    .ToList();

                return Json(new
                {
                    sucesso = false,
                    mensagem = string.Join(" | ", erros)
                });
            }

            if (ModelState.IsValid)
            {
                var veiculo = await _veiculoInterface.CadastrarVeiculo(veiculoRegisterDto);

                if (veiculo.Status)
                {
                    return Json(new
                    {
                        sucesso = true,
                        mensagem = veiculo.Mensagem
                    });
                }
                else
                {
                    return Json(new
                    {
                        sucesso = true,
                        mensagem = veiculo.Mensagem
                    });
                }

                
            }
            else
            {
                return Json(new
                {
                    sucesso = false,
                    mensagem = "Preencha todos os campos obrigatórios."
                });
            }


        }



        [HttpPost]
        public JsonResult ExcluirVeiculo(int id)
        {
            var resultado = _veiculoInterface.ExcluirVeiculo(id);

            return Json(new
            {
                sucesso = resultado.Status,
                mensagem = resultado.Mensagem
            });
        }

    }
}
