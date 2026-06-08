using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BusControl.Models
{
    public class ViagemModel
    {
        public int id { get; set; }

        // 🔴 FOREIGN KEYS (colunas do banco)
        [Column("motorista")]
        public int motoristaId { get; set; }

        [Column("veiculo")]
        public int veiculoId { get; set; }

        // 🔵 NAVEGAÇÃO (objetos completos)
        [ForeignKey("motoristaId")]
        public MotoristaModel motorista { get; set; }

        [ForeignKey("veiculoId")]
        public VeiculoModel veiculo { get; set; }

        // 📌 DADOS NORMAIS
        [Required(ErrorMessage = "Digite a quantidade de passageiros.")]
        public int? quantidadePassageiros { get; set; }

        [Required(ErrorMessage = "Digite a quantidade de passageiros.")]
        public int quantidadeParadas { get; set; }

        [Required(ErrorMessage = "Digite o destino da viagem")]
        public string destino { get; set; }

        [Required(ErrorMessage = "Digite o valor da viagem.")]
        public decimal? valorViagem { get; set; }
    }
}