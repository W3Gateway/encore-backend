using Encore.Domain.Core.Validations;
using Encore.Domain.Services.Esus.DTOs.Cabecalho;
using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaCadastroDomiciliarTerritorial
{
    internal class CadastroDomiciliar
    {
        [MaxItems(4, ErrorMessage = "Excedeu limite da lista")]
        public List<long> AnimaisNoDomicilio { get; set; }

        public CondicaoMoradia CondicaoMoradia { get; set; }

        public EnderecoLocalPermanencia EnderecoLocalPermanencia { get; set; }

        public List<FamiliaRow> Familias { get; set; }

        [Required]
        public bool FichaAtualizada { get; set; }

        [StringLength(2, ErrorMessage = "Fora do limite de caracteres de 0 a 2", MinimumLength = 0)]
        public string QuantosAnimaisNoDomicilio { get; set; }

        public bool StAnimaisNoDomicilio { get; set; }

        public bool StatusTermoRecusa { get; set; }

        [Required]
        public int TpCdsOrigem { get; set; }

        [Required]
        [StringLength(44, ErrorMessage = "Fora do limite de caracteres de 36 a 44", MinimumLength = 36)]
        public string Uuid { get; set; }

        [Required]
        [StringLength(44, ErrorMessage = "Fora do limite de caracteres de 36 a 44", MinimumLength = 36)]
        public string UuidFichaOriginadora { get; set; }

        [Required]
        public long TipoDeImovel { get; set; }

        public InstituicaoPermanencia InstituicaoPermanencia { get; set; }

        [Required]
        public UnicaLotacaoHeader HeaderTransport { get; set; }

        [Range(0, 9999999999, ErrorMessage = "Fora do limite de 0 a 9999999999")]
        public double Latitude { get; set; }

        [Range(0, 99999999999, ErrorMessage = "Fora do limite de 0 a 99999999999")]
        public double Longitude { get; set; }
    }
}
