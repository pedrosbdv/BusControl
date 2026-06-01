using System.ComponentModel.DataAnnotations;

namespace BusControl.ViewModels
{
    public class ViagensViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Digite o nome do motorista.")]
        public string nomeMotorista { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de passageiros.")]
        public int? quantidadePassageiros { get; set; }

        [Required(ErrorMessage = "Digite o nome do ônibus.")]
        public string nomeOnibus { get; set; }

        [Required(ErrorMessage = "Digite a rota da viagem.")]
        public int? rotaViagem { get; set; }

        [Required(ErrorMessage = "Digite o destino da viagem.")]
        public string destinoViagem { get; set; }

        [Required(ErrorMessage = "Digite o valor da viagem.")]
        public decimal? valorViagem { get; set; }

        [Required(ErrorMessage = "Digite a data/hora de saída.")]
        public DateTime? diaHoraSaida { get; set; }

        [Required(ErrorMessage = "Digite a data/hora de chegada.")]
        public DateTime? diaHoraChegada { get; set; }
    }
}
