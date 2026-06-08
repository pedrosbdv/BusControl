using BusControl.Dto;
using BusControl.Models;
using BusControl.Services.LoginService;
using BusControl.Services.MotoristaService;
using BusControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;

namespace BusControl.Controllers
{
    public class MotoristaController : Controller
    {

        private readonly IMotoristaService _motoristaInterface;
        public MotoristaController(IMotoristaService motoristaInterface)
        {
            _motoristaInterface = motoristaInterface;
        }

        public IActionResult Index(string nomeMotorista, string status)
        {
            var motoristas = _motoristaInterface.ConsultarMotoristas(nomeMotorista, status);

            ViewBag.Motorista = nomeMotorista;
            ViewBag.Status = status;

            return View(motoristas);
            
        }

        
        [HttpPost]
        public async Task<IActionResult> CadastrarMotorista(MotoristaRegisterDto motoristaRegisterDto)
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
                var motorista = await _motoristaInterface.CadastrarMotorista(motoristaRegisterDto);

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
                        sucesso = false,
                        mensagem = motorista.Mensagem
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

        public IActionResult ConsultarMotoristasComViagens(string nome, string status)
        {
            var motoristas = _motoristaInterface.ConsultarMotoristasComViagens(nome, status);

            ViewBag.Motorista = nome;

            return View(motoristas);
        }


        [HttpPost]
        public JsonResult Excluir(int id)
        {
            var resultado = _motoristaInterface.ExcluirMotorista(id);

            return Json(new
            {
                sucesso = resultado.Status,
                mensagem = resultado.Mensagem
            });
        }

    }
}
