using Encore.Domain.Core.Validations;

namespace Encore.Domain.Services.Esus.DTOs.FichaAtendimentoIndividual
{
    public class ProblemaCondicaoAvaliacaoAI
    {
        [MaxItems(22, ErrorMessage = "Excedeu limite da lista")]
        public List<string> Ciaps { get; set; }

        public string OutroCiap1 { get; set; }

        public string OutroCiap2 { get; set; }

        public string Cid10 { get; set; }

        public string Cid10_2 { get; set; }
    }
}
