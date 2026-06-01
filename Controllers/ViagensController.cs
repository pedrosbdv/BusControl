using BusControl.Data;
using BusControl.Models;
using BusControl.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace BusControl.Controllers
{
    public class ViagensController : Controller
    {

        readonly private ApplicationDbContext _db;

        public ViagensController(ApplicationDbContext db)
        {
            _db = db;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        public IActionResult Index(string motorista, string rota, string destino)
        {
            var viagens = _db.Viagens.AsQueryable();

            if (!string.IsNullOrEmpty(motorista))
            {
                viagens = viagens.Where(x => x.nomeMotorista.Contains(motorista));
            }


            if (!string.IsNullOrEmpty(rota))
            {
                viagens = viagens.Where(x => x.rotaViagem.ToString().Contains(rota));

            }

            if (!string.IsNullOrEmpty(destino))
            {
                viagens = viagens.Where(x => x.destinoViagem.Contains(destino));
            }

            ViewBag.Motorista = motorista;
            ViewBag.Rota = rota;
            ViewBag.Destino = destino;

            return View(viagens.ToList());
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Cadastrar(ViagensViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var viagem = new ViagensModel
            {
                nomeMotorista = model.nomeMotorista,
                quantidadePassageiros = model.quantidadePassageiros.Value,
                nomeOnibus = model.nomeOnibus,
                rotaViagem = model.rotaViagem.Value,
                destinoViagem = model.destinoViagem,
                valorViagem = model.valorViagem.Value,
                diaHoraSaida = model.diaHoraSaida.Value,
                diaHoraChegada = model.diaHoraChegada.Value,
                dataHoraRegistro = DateTime.Now
            };

            _db.Viagens.Add(viagem);
            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpGet]
        public IActionResult Editar(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var viagem = _db.Viagens.FirstOrDefault(x => x.id == id);

            if (viagem == null)
            {
                return NotFound();
            }

            var model = new ViagensViewModel
            {
                id = viagem.id,
                nomeMotorista = viagem.nomeMotorista,
                quantidadePassageiros = viagem.quantidadePassageiros,
                nomeOnibus = viagem.nomeOnibus,
                rotaViagem = viagem.rotaViagem,
                destinoViagem = viagem.destinoViagem,
                valorViagem = viagem.valorViagem,
                diaHoraSaida = viagem.diaHoraSaida,
                diaHoraChegada = viagem.diaHoraChegada
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Editar(ViagensViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var viagem = _db.Viagens.FirstOrDefault(x => x.id == model.id);

            if (viagem == null)
            {
                return NotFound();
            }

            viagem.nomeMotorista = model.nomeMotorista;
            viagem.quantidadePassageiros = model.quantidadePassageiros.Value;
            viagem.nomeOnibus = model.nomeOnibus;
            viagem.rotaViagem = model.rotaViagem.Value;
            viagem.destinoViagem = model.destinoViagem;
            viagem.valorViagem = model.valorViagem.Value;
            viagem.diaHoraSaida = model.diaHoraSaida.Value;
            viagem.diaHoraChegada = model.diaHoraChegada.Value;

            _db.SaveChanges();

            return RedirectToAction("Index");
        }

        [HttpPost]
        public JsonResult ExcluirConfirmado(int id)
        {
            try
            {
                var viagem = _db.Viagens.FirstOrDefault(x => x.id == id);

                if (viagem == null)
                {
                    return Json(new
                    {
                        sucesso = false,
                        mensagem = "Viagem não encontrada."
                    });
                }

                _db.Viagens.Remove(viagem);
                _db.SaveChanges();

                return Json(new
                {
                    sucesso = true,
                    mensagem = "Viagem excluída com sucesso."
                });
            }
            catch (Exception ex)
            {
                return Json(new
                {
                    sucesso = false,
                    mensagem = ex.Message
                });
            }
        }
    }
}
