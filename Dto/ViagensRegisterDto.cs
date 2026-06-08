using System.ComponentModel.DataAnnotations;

namespace BusControl.Dto
{
    public class ViagensRegisterDto
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Informe o motorista.")]
        public int motoristaId { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de passageiros.")]
        public int? quantidadePassageiros { get; set; }

        [Required(ErrorMessage = "Digite o nome do ônibus.")]
        public int veiculoId { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de passageiros.")]
        public int quantidadeParadas { get; set; }

        [Required(ErrorMessage = "Digite o destino da viagem")]
        public string destino { get; set; }

        [Required(ErrorMessage = "Digite o valor da viagem.")]
        public decimal? valorViagem { get; set; }
    }
}