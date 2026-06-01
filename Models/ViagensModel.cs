using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusControl.Models
{
    public class ViagensModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Digite o nome do motorista!")]
        public string nomeMotorista { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de passageiros")]
        public int quantidadePassageiros { get; set; }

        [Required(ErrorMessage = "Digite o nome do onibus!")]
        public string nomeOnibus { get; set; }

        [Required(ErrorMessage = "Digite á rota da viagem!")]
        public int rotaViagem { get; set; }

        [Required(ErrorMessage = "Digite o destino da viagem!")]
        public string destinoViagem { get; set; }

        [Required(ErrorMessage = "Digite o valor da viagem!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal valorViagem { get; set; }

        [Required(ErrorMessage = "Digite o dia/hora da saida!")]
        public DateTime diaHoraSaida { get; set; }

        [Required(ErrorMessage = "Digite o dia/hora da chegada")]
        public DateTime diaHoraChegada { get; set; }

        public DateTime dataHoraRegistro { get; set; } = DateTime.Now;
    }
}
