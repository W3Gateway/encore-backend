using System.ComponentModel.DataAnnotations;

namespace Encore.Domain.Services.Esus.DTOs.FichaCadastroDomiciliarTerritorial
{
    public class CondicaoMoradia
    {
        public long AbastecimentoAgua { get; set; }

        public long AreaProducaoRural { get; set; }

        public long DestinoLixo { get; set; }

        public long FormaEscoamentoBanheiro { get; set; }

        [Required]
        public long Localizacao { get; set; }

        public long MaterialPredominanteParedesExtDomicilio { get; set; }

        [StringLength(2, ErrorMessage = "Fora do limite de caracteres de 0 a 2", MinimumLength = 0)]
        public string NuComodos { get; set; }

        [StringLength(4, ErrorMessage = "Fora do limite de caracteres de 0 a 4", MinimumLength = 0)]        
        public string NuMoradores { get; set; }

        [Required]
        public long SituacaoMoradiaPosseTerra { get; set; }

        public bool StDisponibilidadeEnergiaEletrica { get; set; }

        public long TipoAcessoDomicilio { get; set; }

        public long TipoDomicilio { get; set; }

        public long AguaConsumoDomicilio { get; set; }
    }
}
