using BusControl.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusControl.Models
{
    public class VeiculoModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Digite a placa do veiculo!")]
        public string placaVeiculo { get; set; }

        [Required(ErrorMessage = "Digite o nome do veiculo")]
        public string nomeVeiculo { get; set; }

        [Required(ErrorMessage = "Digite a marca do veiculo!")]
        public string marcaVeiculo { get; set; }

        [Required(ErrorMessage = "Informe a categoria!")]
        public CategoriaVeiculo categoria { get; set; }

        public int status { get; set; }

        public DateTime dataHoraRegistro { get; set; } = DateTime.Now;
    }
}
